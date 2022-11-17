using Application.Common.Interfaces;
using Application.Common.Response;
using AutoMapper;
using CleanArchitecture.Application.Common.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Cqrs.OvertimePeriods.Commands
{
    public class UploadOvertimesPeriodCommand : IRequest<ApiResponse<List<Dictionary<string, object>>>>
    {
        public IFormFile File { get; set; }
        public int OvertimePeriodId { get; set; }

    }

    public class UploadOvertimesPeriodCommandHandle : IRequestHandler<UploadOvertimesPeriodCommand, ApiResponse<List<Dictionary<string, object>>>>
    {


        private readonly IBulkInsert _bulkInsert;
        private readonly IMapper _mapper;
        private ICurrentUserService _currentUserService;
        public UploadOvertimesPeriodCommandHandle(
            IBulkInsert bulkInsert,
            IMapper mapper,
            ICurrentUserService currentUserService
        )
        {
            _mapper = mapper;
            _bulkInsert = bulkInsert;
            _currentUserService = currentUserService;

        }
        public async Task<ApiResponse<List<Dictionary<string, object>>>> Handle(UploadOvertimesPeriodCommand request, CancellationToken cancellationToken)
        {
            var source = await _bulkInsert.SaveFile(request);
            var response = new ApiResponse<List<Dictionary<string, object>>>();

            var user = (Guid)_currentUserService.GetUserInfo().Id;

            try
            {
                if (source.Result)
                {
                    _bulkInsert.setTemporalTable("OvertimeTemps");
                    var Resultdt = await _bulkInsert.Bulk(source.Data);
                    var errors = GetErrorList(Resultdt);
                    response.Data = errors.Count > 0 ? errors : GetErrorList(await _bulkInsert.ExecuteStore("P_InsertOvertimesTemps"));
                    response.Result = true;
                    response.Message = "OK";
                }
                else
                {
                    DataTable dt = new DataTable("Errors");
                    List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
                    Dictionary<string, object> row;

                    DataColumn column1 = new DataColumn("Message");
                    dt.Columns.Add(column1);
                    DataRow row1 = dt.NewRow();
                    row1["Message"] = source.Message;
                    dt.Rows.Add(row1);

                    foreach (DataRow dr in dt.Rows)
                    {
                        row = new Dictionary<string, object>();
                        foreach (DataColumn col in dt.Columns)
                        {
                            row.Add(col.ColumnName, source.Message);
                        }
                        rows.Add(row);
                    }

                    
                    response.Data = rows;
                    response.Result = true;
                    response.Message = "OK";

                }

            }
            catch (Exception ex)
            {
                //_logger.LogError($"Error al obtener los Registros, CostCenterService en el método GetCostcenter, { ex.Message } ");
                response.Result = false;
                response.Message = $"Error al cargar el archivo, consulte con el administrador, { ex.Message } ";
            }
    
                return response;

        }

        public List<Dictionary<string, object>> GetErrorList(DataTable result)
        {
            List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
            Dictionary<string, object> row;
            foreach (DataRow dr in result.Rows)
            {
                row = new Dictionary<string, object>();
                foreach (DataColumn col in result.Columns)
                {
                    row.Add(col.ColumnName, dr[col]);
                }
                rows.Add(row);
            }

            return rows;

        }
    }
}
