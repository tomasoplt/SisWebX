using System;
using System.Collections.Generic;

namespace SisWeb.EF.Models
{
    public partial class Litologie
    {
        public int LitologieId { get; set; }
        public int ObjektId { get; set; }
        public int? LitkodId { get; set; }
        public double? BaseH { get; set; }
        public string Gtext { get; set; }
        public DateTime? NewD { get; set; }
        public string NewU { get; set; }
        public DateTime? ModifD { get; set; }
        public string ModifU { get; set; }
        public DateTime? Reftime { get; set; }
        public DateTime? DeleteD { get; set; }
        public string DeleteU { get; set; }

        public virtual Litkody Litkod { get; set; }
        public virtual Objekty Objekt { get; set; }
    }
}
