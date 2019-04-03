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
        public int? MrakId { get; set; }

        public string new_u { get; set; }
        public string modif_u { get; set; }

        public double? x { get; set; }
        public double? y { get; set; }
        public double? z { get; set; }

        public double? n_gps { get; set; }
        public double? e_gps { get; set; }
        public double? z_gps { get; set; }

        public string technologie { get; set; }
        public string reference { get; set; }
        public string poznamka { get; set; }

        public List<PlovakModelDto> Plovaky { get; set; } = new List<PlovakModelDto>();
    }
}
