using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTOs.Novelties
{
    public class NoveltiesOrderByTypeNoveltyDto
    {
        public string TypeNovelty { get; set; } 
        public List<NoveltyEntryQueryDto> noveltyEntryQueryDtos { get; set; }
    }
}
