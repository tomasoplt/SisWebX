using System;
using System.Collections.Generic;

namespace SisWeb.EF.Models
{
    public partial class Klienti
    {
        public string Pcname { get; set; }
        public string Identityprefix { get; set; }
        public int Identityvalue { get; set; }
        public DateTime? ModifD { get; set; }
        public string ModifU { get; set; }
        public string Poznamka { get; set; }
        public DateTime? PosledniSpojeni { get; set; }
    }
}
