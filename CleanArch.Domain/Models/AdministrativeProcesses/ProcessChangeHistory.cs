using Core.Models.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models.AdministrativeProcesses
{
    public class ProcessChangeHistory :Entity
    {
        public DateTime StatusDate { get; set; }
        public  bool Status { get; set; }
        public int StatusStart { get; set; }
        public int StatusNext { get; set; }
        public Guid ProcessPerformedById { get; set; }

        public int DisciplinaryProcessId { get; set; }
   
        public DisciplinaryProcess DisciplinaryProcess { get; set; }

    }
}
