using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTOs.Novelties
{
    public class AnticipatedNoveltyDto
    {
        public Guid NoveltyEntryId { get; set; }
        //[ForeignKey("NoveltyEntryId")]
        public NoveltyEntryQueryDto NoveltyEntry { get; set; }
        public string NoveltyInit { get; set; }
    }
}
