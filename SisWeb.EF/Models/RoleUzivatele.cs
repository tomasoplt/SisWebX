using System;
using System.Collections.Generic;

namespace SisWeb.EF.Models
{
    public partial class RoleUzivatele
    {
        public int RoleUzivateleId { get; set; }
        public int RoleId { get; set; }
        public int UzivatelId { get; set; }
        public DateTime? NewD { get; set; }
        public string NewU { get; set; }
        public DateTime? ModifD { get; set; }
        public string ModifU { get; set; }
        public DateTime? Reftime { get; set; }
        public DateTime? DeleteD { get; set; }
        public string DeleteU { get; set; }

        public virtual Role Role { get; set; }
        public virtual Uzivatele Uzivatel { get; set; }
    }
}
