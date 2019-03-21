using System;
using System.Collections.Generic;

namespace SisWeb.EF.Models
{
    public partial class Uzivatele : Core.EF.EntityFrameworkCore.Domain.Entities.Entity
    {
        public Uzivatele()
        {
            RoleUzivatele = new HashSet<RoleUzivatele>();
        }

        public int UzivatelId { get; set; }
        public string Uzivatel { get; set; }
        public string Jmeno { get; set; }
        public string Prijmeni { get; set; }
        public string Popis { get; set; }
        public DateTime? NewD { get; set; }
        public string NewU { get; set; }
        public DateTime? ModifD { get; set; }
        public string ModifU { get; set; }
        public DateTime? Reftime { get; set; }
        public string Heslo { get; set; }
        public DateTime? DeleteD { get; set; }
        public string DeleteU { get; set; }
        public string Email { get; set; }
        public string Telefon { get; set; }
        public string Upozorneni { get; set; }
        public string StavUpozorneni { get; set; }
        public DateTime? DatumKlikuOk { get; set; }
        public DateTime? PosledniSynchronizace { get; set; }

        public virtual ICollection<RoleUzivatele> RoleUzivatele { get; set; }
    }
}
