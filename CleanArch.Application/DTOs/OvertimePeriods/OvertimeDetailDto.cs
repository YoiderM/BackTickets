using Application.DTOs.Mekano;
using System;
using System.Collections.Generic;

namespace Application.DTOs.OvertimePeriods
{
    public class OvertimeDetailDto
    {
        public Guid Id { get; set; }
        public Guid? AprovedBy { get; set; }
        public Guid? CreatedBy { get; set; }
        public bool? Aproved { get; set; } = false; //aproved
        public string Login { get; set; }
        public string JobName { get; set; }
        public string Document { get; set; }
        public string Names { get; set; }
        public string Observation { get; set; }
        public string AuthObservation { get; set; }
        public string AdminObservation { get; set; }
        public bool? UserStatus { get; set; } = true; // active       
        public int TotalHours { get; set; }
        public bool CompensatoryApplies { get; set; } = false;
        public bool SundayNumber1 { get; set; } = false;
        public bool SundayNumbre2 { get; set; } = false;
        public DateTime? LoginTime { get; set; }
        public DateTime? OvertimeDay { get; set; }
        public DateTime? InitialHour { get; set; }
        public DateTime? EndHour { get; set; }
        public Decimal? Salary { get; set; }
        public Decimal? PaymentPercent { get; set; }
        public int Status { get; set; } = 1;
        public int? OvertimePeriodId { get; set; }
        public int CostCenterId { get; set; }
        public Guid OvertimeTypeId { get; set; }



        #region ForeingKey
        public OvertimePeriodDto OvertimePeriod { get; set; } 
        public CostCenterDto CostCenter { get; set; }
        public OvertimeTypeDto OvertimeType { get; set; }
        #endregion


    }
}
