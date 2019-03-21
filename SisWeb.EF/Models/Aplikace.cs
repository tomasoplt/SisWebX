using System;
using System.Collections.Generic;

namespace SisWeb.EF.Models
{
    public partial class Aplikace
    {
        public int AplikaceId { get; set; }
        public int? ObjektId { get; set; }
        public DateTime? AplikovanoOd { get; set; }
        public DateTime? AplikovanoDo { get; set; }
        public string AplikovanaLatka { get; set; }
        public string TypLatky { get; set; }
        public double? Mnozstvi { get; set; }
        public double? Koncentrace { get; set; }
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
