using System;
using System.Collections.Generic;

namespace Application.DTOs.User
{
    public class UserDto
    {
        public Guid Id { get; set; }
        public string Document { get; set; }
        public string Names { get; set; }
        public string CampaignName { get; set; }
        public string Phone1 { get; set; }
        public string Phone2 { get; set; }
        public string Phone3 { get; set; }
        public string Email { get; set; }
        public bool Status { get; set; }  
        public bool Active { get; set; }  
        public string login { get; set; }
        public string RolId { get; set; }
        public List<UserRolDto> UserRol { get; set; }

    }
}

