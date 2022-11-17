using Core.Models.Common;
using Domain.Models.Novelties;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models.Resources
{
    public class Resources : Entity
    {
        public string Extension { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public string URL { get; set; }
        public Guid NoveltyEntryId { get; set; }
        [ForeignKey("NoveltyEntryId")]
        public NoveltyEntry NoveltyEntry { get; set; }
    }
}
