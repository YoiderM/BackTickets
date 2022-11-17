using Core.Models.Common;

namespace Domain.Models.AdministrativeProcesses
{
    public class ProcessStatus : EntityWithIntId
    {
        public string NameStatus { get; set; }
        public bool Status { get; set; }
        public int Order { get; set; }
        public string FromProject { get; set; }
    }
}
