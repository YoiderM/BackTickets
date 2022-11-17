using Core.Models.Common;
using System;

namespace Domain.Models.Mekano
{
    public class ResponsabilityCostCenter : EntityWithIntId
    {
        public Guid UserId { get; set; }
        public int CostCenterId { get; set; }
        public Domain.Models.User.User User { get; set; }
        public CostCenter CostCenter { get; set; }
    }
}
