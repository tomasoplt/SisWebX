using System;
using System.Collections.Generic;

namespace SisWeb.EF.Models
{
    public partial class Clu
    {
        public int CluId { get; set; }
        public int? ObjektId { get; set; }
        public DateTime? Odber { get; set; }
        public double? HloubkaOdberu { get; set; }
        public string TypOdberu { get; set; }
        public string Protokol { get; set; }
        public string Vzorek { get; set; }
        public string VzorekTyp { get; set; }
        public double? Chlormethan { get; set; }
        public double? Dichlormethan { get; set; }
        public double? Trichlormethan { get; set; }
        public double? Tetrachlormethan { get; set; }
        public double? Dichlorethan11 { get; set; }
        public double? Dichlorethan12 { get; set; }
        public double? Vc { get; set; }
        public double? Dce11 { get; set; }
        public double? CDce12 { get; set; }
        public double? TDce12 { get; set; }
        public double? Tce { get; set; }
        public double? Pce { get; set; }
        public double? Trichlorethan111 { get; set; }
        public double? Trichlorethan112 { get; set; }
        public double? Tetrachlorethan1112 { get; set; }
        public double? Tetrachlorethan1122 { get; set; }
        public double? Dichlorpropan12 { get; set; }
        public double? Trichlorpropan123 { get; set; }
        public double? Dichlorpropylen11 { get; set; }
        public double? Hexachlorobutadien { get; set; }
        public double? Chlorbenzen { get; set; }
        public double? Dichlorbenzen12 { get; set; }
        public double? Dichlorbenzen13 { get; set; }
        public double? Dichlorbenzen14 { get; set; }
        public double? Trichlorbenzeny { get; set; }
        public double? Aox { get; set; }
        public double? Teq { get; set; }
        public string Poznamka { get; set; }
        public DateTime? NewD { get; set; }
        public string NewU { get; set; }
        public DateTime? ModifD { get; set; }
        public string ModifU { get; set; }
        public DateTime? Reftime { get; set; }
        public DateTime? DeleteD { get; set; }
        public string DeleteU { get; set; }
        public double? Rezerva1 { get; set; }
        public double? Dichlorbenzeny { get; set; }
        public double? Trichlorbenzen123 { get; set; }
        public double? Trichlorbenzen124 { get; set; }
        public double? Trichlorbenzen135 { get; set; }
        public double? Tetrachlorbenzeny { get; set; }
        public double? Pentachlorbenzen { get; set; }
        public double? Hexachlorbenzen { get; set; }
        public string Realizace { get; set; }
        public double? Tetrachlorobenzen1234 { get; set; }
        public double? Tetrachlorobenzen1235Plus1245 { get; set; }

        public virtual Objekty Objekt { get; set; }
    }
}
