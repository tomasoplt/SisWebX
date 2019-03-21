using System;
using System.Collections.Generic;

namespace SisWeb.EF.Models
{
    public partial class BtexNel
    {
        public int BtexNelId { get; set; }
        public int? ObjektId { get; set; }
        public DateTime? Odber { get; set; }
        public double? HloubkaOdberu { get; set; }
        public string TypOdberu { get; set; }
        public string Protokol { get; set; }
        public string Vzorek { get; set; }
        public string VzorekTyp { get; set; }
        public double? Nel { get; set; }
        public double? UhlovodikyC10C40 { get; set; }
        public double? Benzen { get; set; }
        public double? Toluen { get; set; }
        public double? Ethylbenzen { get; set; }
        public double? Xyleny { get; set; }
        public double? Styren { get; set; }
        public double? Naftalen { get; set; }
        public double? Methan { get; set; }
        public double? Ethan { get; set; }
        public double? Ethen { get; set; }
        public double? KyselinaCitronova { get; set; }
        public DateTime? NewD { get; set; }
        public string NewU { get; set; }
        public DateTime? ModifD { get; set; }
        public string ModifU { get; set; }
        public DateTime? Reftime { get; set; }
        public DateTime? DeleteD { get; set; }
        public string DeleteU { get; set; }
        public string Realizace { get; set; }
        public double? Mtbe { get; set; }
        public string Poznamka { get; set; }
        public double? Fenol { get; set; }
        public double? Kresoly { get; set; }
        public double? Dimethylfenoly { get; set; }
        public double? VyssiFenoly { get; set; }
        public double? Edta { get; set; }
        public double? NaFluorescein { get; set; }

        public virtual Objekty Objekt { get; set; }
    }
}
