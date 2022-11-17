using Application.DTOs.Novelties;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTOs.Resources
{
    public class ResourcesDto
    {
        public Guid Id { get; set; }
        public string Extension { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public string URL { get; set; }
        public Guid NoveltyEntryId { get; set; }
        //[ForeignKey("NoveltyEntryId")]
        //public NoveltyEntryDto NoveltyEntry { get; set; }
    }
}
