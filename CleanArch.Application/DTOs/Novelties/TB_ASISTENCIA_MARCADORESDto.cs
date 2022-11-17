using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Application.DTOs.Novelties
{
    public class TB_ASISTENCIA_MARCADORESDto
    {
        public int Id { get; set; }
        public DateTime FECHA { get; set; }
        public string DOCUMENTO { get; set; }
        public string NOMBRE { get; set; }
        public string CARGO { get; set; }
        public int ID_CENTRO_COSTO { get; set; }
        public string CENTRO_COSTO { get; set; }
        [Column("REQUIERE LOGEO")]
        public bool REQUIERE_LOGEO { get; set; }
        public int BIOMETRICO_CONFIRMACION { get; set; }
        public int PRESENCE_CONFIRMACION { get; set; }
        public int AVAYA_CONFIRMACION { get; set; }
        public int HERMES_CONFIRMACION { get; set; }
        public string MARCADOR { get; set; }
        [Column("¿ASISTIO?")]
        public string ASISTIO { get; set; }
        public DateTime? HORA_INICIO_TURNO { get; set; }
        public string DESCRIPCION { get; set; }
    }
}
