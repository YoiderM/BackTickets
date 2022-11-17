using System;

namespace Application.DTOs.Novelties
{
    public class NoveltyEntryCommandDto
    {
        public string Description { get; set; }
        public DateTime InitDate { get; set; }
        public DateTime EndDate { get; set; }

        //public int AsistenciaMarcadoresId { get; set; }
        //[ForeignKey("AsistenciaMarcadoresId")]
        //public TB_ASISTENCIA_MARCADORESDto TB_ASISTENCIA_MARCADORES { get; set; }

        //public int ConfigurationNoveltiesId { get; set; }
        //[ForeignKey("ConfigurationNoveltiesId")]
        //public ConfigurationNoveltiesDto ConfigurationNovelties { get; set; }

        public int ProcessStatusId { get; set; }
        //[ForeignKey("ProcessStatusId")]
        //public ProcessStatusDto ProcessStatus { get; set; }

        //public int MekanoUserId { get; set; }
        //[ForeignKey("MekanoUserId")]
        //public MekanoUser MekanoUser { get; set; }
    }
}
