using System;
using System.Collections.Generic;

namespace SisWeb.EF.Models
{
    public partial class Meteodata
    {
        public int MeteodataId { get; set; }
        public int? ObjektId { get; set; }
        public DateTime? Mereno { get; set; }
        public double? TeplotaVzduchu { get; set; }
        public double? PrizemniTeplota { get; set; }
        public double? TeplotaPudy { get; set; }
        public double? Srazky { get; set; }
        public double? VlhkostVzduchu { get; set; }
        public double? VlhkostPudy { get; set; }
        public double? RychlostVetru { get; set; }
        public double? NapetiAkumulatoru { get; set; }
        public string Poznamka { get; set; }
        public DateTime? NewD { get; set; }
        public string NewU { get; set; }
        public DateTime? ModifD { get; set; }
        public string ModifU { get; set; }
        public DateTime? Reftime { get; set; }
        public DateTime? DeleteD { get; set; }
        public string DeleteU { get; set; }
        public string Realizace { get; set; }

        public virtual Objekty Objekt { get; set; }
    }
}
