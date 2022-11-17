using Domain.Models.Mekano;
using System;

namespace Application.DTOs.Mekano
{
    public class ResponsabilityCostCenterDto
    {
        public int Id { get; set; }
        public Guid UserId { get; set; }    
        public int CostCenterId { get; set; }
        public Domain.Models.User.User User { get; set; }
        public CostCenter CostCenter { get; set; }

      
    }
}
