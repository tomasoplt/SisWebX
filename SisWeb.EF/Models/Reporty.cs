using System;
using System.Collections.Generic;

namespace SisWeb.EF.Models
{
    public partial class Reporty
    {
        public int ReportId { get; set; }
        public string Typ { get; set; }
        public string Soubor { get; set; }
        public string Report { get; set; }
        public DateTime? NewD { get; set; }
        public string NewU { get; set; }
        public DateTime? ModifD { get; set; }
        public string ModifU { get; set; }
        public DateTime? Reftime { get; set; }
        public DateTime? DeleteD { get; set; }
        public string DeleteU { get; set; }
    }
}
