using System;

namespace Application.DTOs.Novelties
{
    public class NoveltyHistoryCommandDto
    {
        // public DateTime date { get; set; }

        //public string InitialState { get; set; }

        //public string EndState { get; set; }
        public string Observation { get; set; }

        //public int MadeByUserId { get; set; }

        //public MekanoUserDto MekanoUser { get; set; }

        public Guid NoveltyEntryId { get; set; }
        //public NoveltyEntryDto NoveltyEntry { get; set; }
    }
}
