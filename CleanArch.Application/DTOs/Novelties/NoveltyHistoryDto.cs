using Application.DTOs.Mekano;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTOs.Novelties
{
    public class NoveltyHistoryDto
    {
        public DateTime date { get; set; }
        public string InitialState { get; set; }

        public string EndState { get; set; }

        public string Observation { get; set; }

        public Guid MadeByUserId { get; set; }
        //public MekanoUserDto MekanoUser { get; set; }

        public Guid NoveltyEntryId { get; set; }
        //public NoveltyEntryDto NoveltyEntry { get; set; }
    }
}
