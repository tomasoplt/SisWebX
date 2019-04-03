using System;

namespace SisWeb.Services.Dto.Sis
{
    public class PlovakModelDto
    {
        public int? PlovakId { get; set; }
        public int? objekt_id { get; set; }
        public DateTime? Mereno { get; set; }
        public double? NapetiPanel { get; set; }
        public double? NapetiAku { get; set; }
        public string Poznamka { get; set; }
        public string modif_u { get; set; }
        
    }
}
