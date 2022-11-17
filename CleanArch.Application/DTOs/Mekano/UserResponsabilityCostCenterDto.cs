using Application.DTOs.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTOs.Mekano
{
    public class UserResponsabilityCostCenterDto
    {
        public Guid Id { get; set; }
        public string Document { get; set; }
        public string Names { get; set; }
        public string CampaignName { get; set; }
                 
        public string RolId { get; set; }

        //public Guid CostCenterId { get; set; }
        public List<ResponsabilityCostCenterDto> ResponsabilityCostCenter { get; set; }
        public List<UserRolDto> UserRol { get; set; }
    }
}
