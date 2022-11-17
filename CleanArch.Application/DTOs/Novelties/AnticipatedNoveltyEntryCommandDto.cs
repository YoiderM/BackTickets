using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTOs.Novelties
{
    public class AnticipatedNoveltyEntryCommandDto
    {
        public string Description { get; set; }
        public DateTime InitDate { get; set; }
        public DateTime EndDate { get; set; }

        public int ConfigurationNoveltiesId { get; set; }
        //[ForeignKey("ConfigurationNoveltiesId")]
        //public ConfigurationNoveltiesDto ConfigurationNovelties { get; set; }

        public int ProcessStatusId { get; set; }
        //[ForeignKey("ProcessStatusId")]
        //public ProcessStatusDto ProcessStatus { get; set; }

        public int MekanoUserId { get; set; }
        //[ForeignKey("MekanoUserId")]
        //public MekanoUser MekanoUser { get; set; }
    }
}
