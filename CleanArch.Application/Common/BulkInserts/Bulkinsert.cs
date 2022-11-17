using Application.Common.Interfaces;
using Application.Common.Response;
using Application.Cqrs.OvertimePeriods.Commands;
using Application.Interfaces.User;
using CleanArchitecture.Application.Common.Interfaces;
using Domain.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Threading.Tasks;

namespace Application.Common.BulkInserts
{
    public class BulkInsert : IBulkInsert, IDisposable
    {
        private readonly IWebHostEnvironment _hostingEnvironment;
        private readonly string _connectionString;
        private readonly SqlConnection _connection;
        private readonly IUnitOfWork _unitOfWork;
        private ICurrentUserService _currentUserService;
        private IUserService _userService;
        private DataTable _validationResultTable;
        private Guid _userId;
        private string _createdByName;
        private string _tableTemp;      
        public string _path;


        public BulkInsert(IWebHostEnvironment environment, IUnitOfWork unitOfWork, ICurrentUserService currentUserService, IUserService userService)
        {
            _userService = userService;
            _currentUserService = currentUserService;
            _hostingEnvironment = environment;
            _unitOfWork = unitOfWork;
            _validationResultTable = new DataTable();
            _connectionString = _unitOfWork.GetDbConnection();
            _connection = new SqlConnection(_connectionString);
            //_userId = (Guid)_currentUserService.GetUserInfo().Id;
            //_userId = new Guid("78EAEA3E-B8B9-4FEF-865B-F3805B35E6F8");
            _createdByName = _currentUserService.GetUserInfo().Name;
            _userId = (Guid)_currentUserService.GetUserInfo().Id;
            

        }


        public async Task SetPath(string path)
        {
            await Task.FromResult(path);

        }


        public void setTemporalTable(string table)
        {
            _tableTemp = table;
        }


        public async Task<ApiResponse<DataTable>> SaveFile(UploadOvertimesPeriodCommand Request)
        {
            var response = new ApiResponse<DataTable>();

            

                try
            {
                string uploads = Path.Combine(_hostingEnvironment.WebRootPath, "uploads");
                string filePath = Path.Combine(uploads, _userId.ToString());

                if (Request.File.Length > 0)
                {
                    using (Stream fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await Request.File.CopyToAsync(fileStream);


                        await fileStream.DisposeAsync();
                    }
                }
                var strconn = ("Provider=Microsoft.ACE.OLEDB.12.0;" +
                ("Data Source=" + (filePath + ";Extended Properties=\"Excel 12.0;HDR=YES\"")));

                DataTable dataTable = new DataTable();

                OleDbConnection mconn = new OleDbConnection(strconn);
                mconn.Open();
                DataTable dtSchema = mconn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);

                if ((null != dtSchema) && (dtSchema.Rows.Count > 0))
                {

                    string firstSheetName = "data$";
                    new OleDbDataAdapter("SELECT * FROM [" + firstSheetName.Trim() + "]", mconn).Fill(dataTable);
                }
                mconn.Close();


                var now = DateTime.Now;

                dataTable.Columns.Add("User", typeof(Guid));
                dataTable.Columns.Add("CreatedAt", typeof(DateTime));
                dataTable.Columns.Add("CreatedByName", typeof(string));
                dataTable.Columns.Add("OvertimePeriodId", typeof(int));

                var errors = ValidateFieldsExcel(dataTable);

                if (!string.IsNullOrEmpty(errors))
                {
                    throw new Exception($"{ errors }");

                }

                foreach (DataRow dr in dataTable.Rows)
                {

                    dr["User"] = _userId;
                    dr["CreatedAt"] = now;
                    dr["CreatedByName"] = _createdByName;
                    dr["OvertimePeriodId"] = Request.OvertimePeriodId;

                }

                response.Data = dataTable;
                response.Result = true;
                response.Message = "OK";

            }
            catch (Exception ex)
            {              
               
                response.Message = ex.Message;               

            }

            return response;
        }


        private string ValidateFieldsExcel(DataTable dataTable)
        {
            IList<string> errors = new List<string>();
            int loop = 2;
            foreach (DataRow dr in dataTable.Rows)
            {

                var overtimeDay = dr["FECHA_HORA_EXTRA"];
                var hourLogueo = dr["HORA_LOGUEO"];
                var startHour = dr["HORA_INICO_RECARGO"];
                var endHour = dr["HORA_FIN_RECARGO"];
                              

                if (!DateTime.TryParse(overtimeDay.ToString(), out DateTime od))
                {
                    errors.Add($"El campo FECHA_HORA_EXTRA en la fila { loop } no posee el formato correcto");                  

                }

                if (!DateTime.TryParse(hourLogueo.ToString(), out DateTime hl))
                {
                    errors.Add($"El campo HORA_LOGUEO en la fila { loop } no posee el formato correcto");

                }

                if (!DateTime.TryParse(startHour.ToString(), out DateTime sh))
                {
                    errors.Add($"El campo HORA_INICO_RECARGO en la fila { loop } no posee el formato correcto");

                }

                if (!DateTime.TryParse(endHour.ToString(), out DateTime eh))
                {
                    errors.Add($"El campo HORA_FIN_RECARGO en la fila { loop } no posee el formato correcto");

                }

                loop++;
            }

            return string.Join(",", errors);
        }

        public async Task<DataTable> Bulk(DataTable dt)
        {


            await TruncateTable(_tableTemp, _userId);
            await _connection.OpenAsync();

            using (SqlBulkCopy bulkcopy = new SqlBulkCopy(_connection))
            {
                bulkcopy.DestinationTableName = _tableTemp;
                bulkcopy.ColumnMappings.Add("TIPO_HORA", "OvertimeTypeName");
                bulkcopy.ColumnMappings.Add("LOGIN", "Login");
                bulkcopy.ColumnMappings.Add("FECHA_HORA_EXTRA", "OvertimeDay");
                bulkcopy.ColumnMappings.Add("DOCUMENTO", "Document");
                bulkcopy.ColumnMappings.Add("HORA_LOGUEO", "LoginTime");
                bulkcopy.ColumnMappings.Add("APLICA_COMPENSATORIO", "CompensatoryAppliesText");
                bulkcopy.ColumnMappings.Add("HORA_INICO_RECARGO", "InitialHour");
                bulkcopy.ColumnMappings.Add("HORA_FIN_RECARGO", "EndHour");
                bulkcopy.ColumnMappings.Add("User", "CreatedBy");
                bulkcopy.ColumnMappings.Add("CreatedAt", "CreatedAt");
                bulkcopy.ColumnMappings.Add("CreatedByName", "CreatedByName");
                bulkcopy.ColumnMappings.Add("OvertimePeriodId", "OvertimePeriodId");

                try
                {
                    bulkcopy.WriteToServer(dt);
                    await _connection.CloseAsync();
                    return await ExecuteStore("P_validateOvertimesTemps");
                }
                catch (Exception ex)
                {
                    throw new Exception("Error Insert the Excel data " + ex.Message);

                }
            }
        }



        public void Dispose()
        {
            _connection.Close();
        }


        public async Task<DataTable> ExecuteStore(string store)
        {

            try
            {

                _validationResultTable.Clear();
                SqlCommand InsertCommand = new SqlCommand(store, _connection);
                InsertCommand.CommandType = CommandType.StoredProcedure;
                SqlParameter parameter = new SqlParameter();
                InsertCommand.Parameters.Clear();
                InsertCommand.Parameters.AddWithValue("@userId", _userId);
                _connection.Open();
                SqlDataReader reader = await InsertCommand.ExecuteReaderAsync();
                _validationResultTable.Load(reader);
                _connection.Close();
                return _validationResultTable;

            }
            catch (Exception ex)
            {
                throw new Exception("Error al ejecutar procedimiento almacenado. \n" + ex.Message.ToString());
            }
        }




        public async Task TruncateTable(string table)
        {

            try
            {


                SqlCommand comandoInsert = new SqlCommand("TRUNCATE TABLE " + table, _connection);
                comandoInsert.CommandType = CommandType.Text;
                SqlParameter parameter = new SqlParameter();
                comandoInsert.Parameters.Clear();
                _connection.Open();
                SqlDataReader reader = await comandoInsert.ExecuteReaderAsync();
                _connection.Close();

            }
            catch (Exception ex)
            {
                throw new Exception("Error al ejecutar procedimiento almacenado. \n" + ex.Message.ToString());
            }
        }

        public async Task TruncateTable(string table, Guid UserId)
        {

            try
            {

                string command = String.Concat("Delete from ", table, $" where CreatedBy ='{UserId}' ");

                SqlCommand comandoInsert = new SqlCommand(command, _connection);
                comandoInsert.CommandType = CommandType.Text;
                SqlParameter parameter = new SqlParameter();
                comandoInsert.Parameters.Clear();
                _connection.Open();
                SqlDataReader reader = await comandoInsert.ExecuteReaderAsync();
                _connection.Close();

            }
            catch (Exception ex)
            {
                throw new Exception("Error al ejecutar procedimiento almacenado. \n" + ex.Message.ToString());
            }
        }



        protected DataTable CargarExcel(string cadenaConexion)
        {

            try
            {
                var strconn = ("Provider=Microsoft.ACE.OLEDB.12.0;" +
                ("Data Source=" + (cadenaConexion + ";Extended Properties=\"Excel 12.0;HDR=YES\"")));

                DataTable dataTable = new DataTable();


                OleDbConnection mconn = new OleDbConnection(strconn);
                mconn.Open();
                DataTable dtSchema = mconn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);

                if ((null != dtSchema) && (dtSchema.Rows.Count > 0))
                {
                    string firstSheetName1 = dtSchema.Rows[2]["TABLE_NAME"].ToString();
                    string firstSheetName = "Cargue$";
                    new OleDbDataAdapter("SELECT * FROM [" + firstSheetName.Trim() + "]", mconn).Fill(dataTable);
                }
                mconn.Close();

                return dataTable;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }


        }

    }
}
