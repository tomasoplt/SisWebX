using System;
using System.Collections.Generic;

namespace SisWeb.EF.Models
{
    public partial class Urovne : Core.EF.EntityFrameworkCore.Domain.Entities.Entity
    {
        public int UrovenId { get; set; }
        public int Uroven { get; set; }
        public string Barva { get; set; }
        public string Nazev { get; set; }
        public string Popis { get; set; }
        public DateTime? NewD { get; set; }
        public string NewU { get; set; }
        public DateTime? ModifD { get; set; }
        public string ModifU { get; set; }
        public DateTime? Reftime { get; set; }
        public DateTime? DeleteD { get; set; }
        public string DeleteU { get; set; }
    }
}
