using System;
using System.Collections.Generic;

namespace SisWeb.EF.Models
{
    public partial class Jednotky
    {
        public int JednotkaId { get; set; }
        public string Jednotka { get; set; }
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
