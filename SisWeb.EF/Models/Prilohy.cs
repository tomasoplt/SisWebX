using System;
using System.Collections.Generic;

namespace SisWeb.EF.Models
{
    public partial class Prilohy
    {
        public int PrilohaId { get; set; }
        public int? ObjektId { get; set; }
        public byte[] Priloha { get; set; }
        public string Typ { get; set; }
        public string Vychozi { get; set; }
        public string Popis { get; set; }
        public DateTime? NewD { get; set; }
        public string NewU { get; set; }
        public DateTime? ModifD { get; set; }
        public string ModifU { get; set; }
        public DateTime? Reftime { get; set; }
        public DateTime? DeleteD { get; set; }
        public string DeleteU { get; set; }
        public string Druh { get; set; }

        public virtual Objekty Objekt { get; set; }
    }
}
