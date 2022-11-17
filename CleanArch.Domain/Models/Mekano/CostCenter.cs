using Core.Models.Common;

namespace Domain.Models.Mekano
{
    public class CostCenter : EntityWithIntId
    {
        public string Name { get; set; }
        public bool Status { get; set; }
        public bool UsesMarker { get; set; }
    }
}
