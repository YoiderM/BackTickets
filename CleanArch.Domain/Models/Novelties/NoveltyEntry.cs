using Core.Models.Common;
using Domain.Models.AdministrativeProcesses;
using Domain.Models.Mekano;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models.Novelties
{
    public class NoveltyEntry : Entity
    {
        public string Description { get; set; }
        public DateTime InitDate { get; set; }
        public DateTime EndDate { get; set; }

        public int ConfigurationNoveltiesId { get; set; }
        [ForeignKey("ConfigurationNoveltiesId")]
        public ConfigurationNovelties ConfigurationNovelties { get; set; }

        public int ProcessStatusId { get; set; }
        [ForeignKey("ProcessStatusId")]
        public ProcessStatus ProcessStatus { get; set; }

        public int MekanoUserId { get; set; }
        [ForeignKey("MekanoUserId")]
        public MekanoUser MekanoUser { get; set; }
    }
}
