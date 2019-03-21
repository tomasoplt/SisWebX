using System;
using System.Collections.Generic;

namespace SisWeb.EF.Models
{
    public partial class Mraky
    {
        public Mraky()
        {
            Objekty = new HashSet<Objekty>();
        }

        public int MrakId { get; set; }
        public string Mrak { get; set; }
        public string Popis { get; set; }
        public string Poznamka { get; set; }
        public DateTime? NewD { get; set; }
        public string NewU { get; set; }
        public DateTime? ModifD { get; set; }
        public string ModifU { get; set; }
        public DateTime? Reftime { get; set; }
        public DateTime? DeleteD { get; set; }
        public string DeleteU { get; set; }

        public virtual ICollection<Objekty> Objekty { get; set; }
    }
}
