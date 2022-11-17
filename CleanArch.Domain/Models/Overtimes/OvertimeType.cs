using Core.Models.Common;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models.Overtimes
{
    /// <summary>
    /// Type oy overtime to pay 
    /// </summary>
    public class OvertimeType : Entity
    {
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public string Description { get; set; }
        public string Description1 { get; set; }
        public string Note { get; set; }
        public bool status { get; set; } = true;
        public bool? CompensatoryApplies { get; set; }
        public int? IsHoliday { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int? MaximumHours { get; set; }

        [Column(TypeName = "decimal(10, 2)")]
        public Decimal? payPercent { get; set; }

        public string  TypeHour { get; set; }
    }
}
