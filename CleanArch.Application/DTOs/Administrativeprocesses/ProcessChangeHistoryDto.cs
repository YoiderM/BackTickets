using Domain.Models.AdministrativeProcesses;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTOs.Administrativeprocesses
{
    public class ProcessChangeHistoryDto
    {
        public DateTime StatusDate { get; set; }
        public bool Status { get; set; }
        public Guid StatusStart { get; set; }
        public Guid StatusNext { get; set; }
        public Guid ProcessPerformedById { get; set; }
        public int DisciplinaryProcessId { get; set; }

        public DisciplinaryProcess DisciplinaryProcess { get; set; }

    }
}
