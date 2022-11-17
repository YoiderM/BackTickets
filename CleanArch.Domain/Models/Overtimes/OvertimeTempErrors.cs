using System;

namespace Domain.Models.Overtimes
{
    public class OvertimeTempErrors
    {
        public string Tipo_de_hora_extra { get; set; }
        public string Login { get; set; }
        public string Centro_de_costo { get; set; }
        public DateTime OvertimeDay { get; set; }
        public string Names { get; set; }
        public string JobName { get; set; }
        public string Document { get; set; }
        public string LoginTimeText { get; set; }
        public string CompensatoryAppliesText { get; set; }
        public string Hora_inicio { get; set; }
        public string Hora_Final { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedByName { get; set; }
        public string Error { get; set; }
    }
}
