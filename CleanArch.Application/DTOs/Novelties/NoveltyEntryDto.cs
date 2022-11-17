using Application.DTOs.Administrativeprocesses;
using Application.DTOs.Resources;
using Domain.Models.Mekano;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTOs.Novelties
{
    public class NoveltyEntryDto
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public DateTime InitDate { get; set; }
        public DateTime EndDate { get; set; }

        public int ConfigurationNoveltiesId { get; set; }
        //[ForeignKey("ConfigurationNoveltiesId")]
        public ConfigurationNoveltiesDto ConfigurationNovelties { get; set; }

        public int ProcessStatusId { get; set; }
        //[ForeignKey("ProcessStatusId")]
        public ProcessStatusDto ProcessStatus { get; set; }

        public int MekanoUserId { get; set; }
        //[ForeignKey("MekanoUserId")]
        public MekanoUser MekanoUser { get; set; }
        public List<ResourcesDto> ResourcesDtos { get; set; }

        public List<NoveltyHistoryQueryDto> NoveltyHistoryQueryDtos { get; set; }
    }
}
