using Core.Models.Common;
using System;

namespace Domain.Models.Mekano
{
    public class MekanoUser : EntityWithIntId
    {
        public string Document { get; set; }
        public string Name { get; set; }
        public string Job { get; set; }
        public string Campaign { get; set; }
        public DateTime Date { get; set; }
        public bool? Active { get; set; }
        public int? CostCenterId { get; set; }
        public CostCenter CostCenter { get; set; }
        
    }
}
