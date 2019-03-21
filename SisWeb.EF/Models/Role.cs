using System;
using System.Collections.Generic;

namespace SisWeb.EF.Models
{
    public partial class Role
    {
        public Role()
        {
            RoleUzivatele = new HashSet<RoleUzivatele>();
        }

        public int RoleId { get; set; }
        public string Role1 { get; set; }
        public string Prava { get; set; }
        public DateTime? NewD { get; set; }
        public string NewU { get; set; }
        public DateTime? ModifD { get; set; }
        public string ModifU { get; set; }
        public DateTime? Reftime { get; set; }
        public DateTime? DeleteD { get; set; }
        public string DeleteU { get; set; }

        public virtual ICollection<RoleUzivatele> RoleUzivatele { get; set; }
    }
}
