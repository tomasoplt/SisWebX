using System;
using System.Collections.Generic;

namespace SisWeb.EF.Models
{
    public partial class Plovaky
    {
        public int PlovakId { get; set; }
        public int? ObjektId { get; set; }
        public DateTime? Mereno { get; set; }
        public double? NapetiPanel { get; set; }
        public double? NapetiAku { get; set; }
        public string Poznamka { get; set; }
        public DateTime? NewD { get; set; }
        public string NewU { get; set; }
        public DateTime? ModifD { get; set; }
        public string ModifU { get; set; }
        public DateTime? Reftime { get; set; }
        public DateTime? DeleteD { get; set; }
        public string DeleteU { get; set; }

        public virtual Objekty Objekt { get; set; }
    }
}
