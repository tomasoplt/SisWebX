using System;
using System.Collections.Generic;

namespace SisWeb.EF.Models
{
    public partial class Litkody
    {
        public Litkody()
        {
            Litologie = new HashSet<Litologie>();
        }

        public int LitkodId { get; set; }
        public string Litkod { get; set; }
        public string Popis { get; set; }
        public DateTime? NewD { get; set; }
        public string NewU { get; set; }
        public DateTime? ModifD { get; set; }
        public string ModifU { get; set; }
        public DateTime? Reftime { get; set; }
        public DateTime? DeleteD { get; set; }
        public string DeleteU { get; set; }

        public virtual ICollection<Litologie> Litologie { get; set; }
    }
}
