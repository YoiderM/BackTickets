using Application.DTOs.Mekano;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTOs.Novelties
{
    public class UserMekanoByCostCenterDto
    {
        public string costCenterName { get; set; }
        public List<MekanoUserDto> mekanoUserDtos { get; set; }
    }
}
