using Core.Models.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models.AdministrativeProcesses
{
    public class ProcessSupport : Entity
    {   
        public int DisciplinaryProcessId { get; set; }
        public string Type { get; set; }
        public string NameFile { get; set; }
    }
}
