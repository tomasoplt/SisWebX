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

        public string new_u { get; set; }
        public string modif_u { get; set; }
        public string delete_u { get; set; }

        public DateTime? new_d { get; set; }
        public DateTime? modif_d { get; set; }
        public DateTime? delete_d { get; set; }

    }
}
