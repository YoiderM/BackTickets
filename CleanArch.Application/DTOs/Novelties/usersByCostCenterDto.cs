using System.Collections.Generic;

namespace Application.DTOs.Novelties
{
    public class usersByCostCenterDto
    {
        public string costCenterName { get; set;}
        public List<TB_ASISTENCIA_MARCADORESDto> users { get; set;}
    }
}
