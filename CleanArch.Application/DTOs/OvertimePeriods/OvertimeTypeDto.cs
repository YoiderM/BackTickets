using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTOs.OvertimePeriods
{
    public class OvertimeTypeDto
    {

        public Guid? Id { get; set; }
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public string Description { get; set; }
        public string Description1 { get; set; }
        public string Note { get; set; }
        public bool status { get; set; } = true;
        public bool? CompensatoryApplies { get; set; }
        public Decimal? payPercent { get; set; }
        public string TypeHour { get; set; }

    }
}
