using System;
using System.Collections.Generic;

namespace SisWeb.EF.Models
{
    public partial class Redox
    {
        public int RedoxId { get; set; }
        public int? ObjektId { get; set; }
        public DateTime? MerenoNeboDOdberu { get; set; }
        public double? Teplota { get; set; }
        public double? HloubkaOdberu { get; set; }
        public double? Ph { get; set; }
        public double? O2 { get; set; }
        public double? Eh { get; set; }
        public double? Konduktivita { get; set; }
        public string Barva { get; set; }
        public string Pach { get; set; }
        public string Poznamka { get; set; }
        public DateTime? NewD { get; set; }
        public string NewU { get; set; }
        public DateTime? ModifD { get; set; }
        public string ModifU { get; set; }
        public DateTime? Reftime { get; set; }
        public DateTime? DeleteD { get; set; }
        public string DeleteU { get; set; }
        public string TypOdberu { get; set; }
        public string Realizace { get; set; }

        public virtual Objekty Objekt { get; set; }
    }
}
