using Core.Models.Common;
using Domain.Models.Mekano;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models.User
{
    public class User : Entity
	{
		public string Document { get; set; }
        public string Names { get; set; }
        public string CampaignName { get; set; }
        public string Phone1 { get; set; }
        public string Phone2 { get; set; }
        public string Phone3 { get; set; }
        public string Email { get; set; }
        public bool Status { get; set; } = true;
        public bool Active { get; set; } = true;
        public string PassWord { get; set; } 
        public string login { get; set; }       
        public List<UserRol> UserRol { get; set; }
        
        //[NotMapped]
        //public Guid CostCenterId { get; set; }
        public List<ResponsabilityCostCenter> ResponsabilityCostCenter { get; set; }


    }
}