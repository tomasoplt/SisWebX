using System;
using System.Collections.Generic;

namespace SisWeb.EF.Models
{
    public partial class JednotkyVeliciny
    {
        public int JednotkaVelicinaId { get; set; }
        public int? O2 { get; set; }
        public int? Konduktivita { get; set; }
        public int? Eh { get; set; }
        public int? Ehd { get; set; }
        public string Poznamka { get; set; }
        public DateTime? NewD { get; set; }
        public string NewU { get; set; }
        public DateTime? ModifD { get; set; }
        public string ModifU { get; set; }
        public DateTime? Reftime { get; set; }
        public DateTime? DeleteD { get; set; }
        public string DeleteU { get; set; }
    }
}
