using Core.Models.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models.AdministrativeProcesses
{
    public class TypeOfFault : EntityWithIntId
    {
        public string NameOfFault { get; set; }
        public string Description { get; set; }
        public bool Status { get; set; }
    }
}
