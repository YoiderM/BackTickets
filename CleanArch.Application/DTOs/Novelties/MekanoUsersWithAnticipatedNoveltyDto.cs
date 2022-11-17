using Application.DTOs.Mekano;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTOs.Novelties
{
    public class MekanoUsersWithAnticipatedNoveltyDto
    {
        public string Document { get; set; }
        public string Name { get; set; }
        public string Job { get; set; }
        public string Campaign { get; set; }
        public DateTime Date { get; set; }
        public bool? Active { get; set; }
        public int? CostCenterId { get; set; }
        public CostCenterDto CostCenter { get; set; }
        public AnticipatedNoveltyDto AnticipatedNoveltyDto { get; set; }
    }
}
