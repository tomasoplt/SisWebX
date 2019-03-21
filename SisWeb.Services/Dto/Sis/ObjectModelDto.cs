using System.Collections.Generic;

namespace SisWeb.Services.Dto.Sis
{
    public class ObjectModelDto
    {
        public int? objekt_id { get; set; }
        public string objekt { get; set; }
        public string typ { get; set; }
        public string alternativni { get; set; }
        public string oblast { get; set; }

        public double? x { get; set; }
        public double? y { get; set; }
        public double? z { get; set; }

        public List<PlovakModelDto> Plovaky { get; set; } = new List<PlovakModelDto>();
    }
}
