using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTOs.Novelties
{
    public class ConfigurationNoveltiesDto
    {
        public int Id { get; set; }
        public string Initial { get; set; }
        public string Name { get; set; }
        public string Detail { get; set; }
        public string Description { get; set; }
        public bool Status { get; set; }
        public bool AnticipatedNovelty { get; set; }
        public bool Assistance { get; set; }
        public bool Approbation { get; set; }
    }
}
