using System;
using System.Collections.Generic;

namespace SisWeb.EF.Models
{
    public partial class Cerpani
    {
        public int CerpaniId { get; set; }
        public int? ObjektId { get; set; }
        public DateTime? NewD { get; set; }
        public string NewU { get; set; }
        public DateTime? ModifD { get; set; }
        public string ModifU { get; set; }
        public DateTime? Reftime { get; set; }
        public DateTime? DeleteD { get; set; }
        public string DeleteU { get; set; }
        public string Typ { get; set; }
        public DateTime? Mereno { get; set; }
        public double? StavMeridla { get; set; }
        public double? QNastavene { get; set; }
        public string MeridloPrutokuAUmisteni { get; set; }
        public string Realizace { get; set; }
        public string TypCerpadla { get; set; }
        public double? DelkaVytlacnehoPotrubi { get; set; }
        public double? VzdalenostCidla { get; set; }
        public double? VykonCerpadlaBezny { get; set; }
        public double? Pretok { get; set; }
        public double? QDopoctene { get; set; }
        public double? SpecifickaVydatnost { get; set; }
        public double? QProvozni { get; set; }
        public double? HpvProvozni { get; set; }
        public double? SnizeniHpvProvozni { get; set; }
        public string OvlivneniHpvProvozni { get; set; }
        public DateTime? Odstaveni { get; set; }
        public string Poznamka { get; set; }
        public string PopisOb { get; set; }
        public string DodrzeniParametru { get; set; }
        public string KlimatickePodminky { get; set; }
        public string SenzorickeVlastnosti { get; set; }
        public string StavObjektu { get; set; }
        public string OvlivneniCz { get; set; }
        public string PopisNedodrzenychParametru { get; set; }
        public string DuvodNedodrzeniParametru { get; set; }
        public string KontaktniOsoby { get; set; }
        public string RezimOdberuVody { get; set; }
        public string HodnoceniVykonuCerpadla { get; set; }
        public string PopisVydatnostiJo { get; set; }
        public string Fotodokumentace { get; set; }
        public string Kolektor { get; set; }
        public double? VzdalenostOb { get; set; }

        public virtual Objekty Objekt { get; set; }
    }
}
