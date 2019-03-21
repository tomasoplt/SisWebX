using System;
using System.Collections.Generic;

namespace SisWeb.EF.Models
{
    public partial class AnalyzyOstatni
    {
        public int AnalyzyOstatniId { get; set; }
        public int? ObjektId { get; set; }
        public DateTime? Odber { get; set; }
        public double? HloubkaOdberu { get; set; }
        public string TypOdberu { get; set; }
        public string Protokol { get; set; }
        public string Vzorek { get; set; }
        public string VzorekTyp { get; set; }
        public double? O2 { get; set; }
        public double? Tlak { get; set; }
        public double? Pid118 { get; set; }
        public double? Ch4 { get; set; }
        public double? Tp { get; set; }
        public double? Co2 { get; set; }
        public DateTime? NewD { get; set; }
        public string NewU { get; set; }
        public DateTime? ModifD { get; set; }
        public string ModifU { get; set; }
        public DateTime? Reftime { get; set; }
        public DateTime? DeleteD { get; set; }
        public string DeleteU { get; set; }
        public string Realizace { get; set; }
        public string Poznamka { get; set; }

        public virtual Objekty Objekt { get; set; }
    }
}
