using System;
using System.Collections.Generic;

namespace SisWeb.EF.Models
{
    public partial class Objekty
    {
        public Objekty()
        {
            AnalyzyOstatni = new HashSet<AnalyzyOstatni>();
            Aplikace = new HashSet<Aplikace>();
            BtexNel = new HashSet<BtexNel>();
            Cerpani = new HashSet<Cerpani>();
            Clu = new HashSet<Clu>();
            HpvFaze = new HashSet<HpvFaze>();
            Litologie = new HashSet<Litologie>();
            Meteodata = new HashSet<Meteodata>();
            Plovaky = new HashSet<Plovaky>();
            Prilohy = new HashSet<Prilohy>();
            Redox = new HashSet<Redox>();
            Uchr = new HashSet<Uchr>();
        }

        public int ObjektId { get; set; }
        public string Objekt { get; set; }
        public string Typ { get; set; }
        public string Alternativni { get; set; }
        public string SekmId { get; set; }
        public int? MrakId { get; set; }
        public double? X { get; set; }
        public double? Y { get; set; }
        public double? Z { get; set; }
        public double? Hloubka { get; set; }
        public string ObPopis { get; set; }
        public double? ZOb { get; set; }
        public double? ObOdPaznice { get; set; }
        public double? NarazenaHladina1 { get; set; }
        public double? NarazenaHladina2 { get; set; }
        public double? UstalenaHladina { get; set; }
        public DateTime? DatumZjisteni { get; set; }
        public DateTime? VrtaniOd { get; set; }
        public DateTime? VrtaniDo { get; set; }
        public string Souprava { get; set; }
        public string Technologie { get; set; }
        public string Vrtmistr { get; set; }
        public string Geolog { get; set; }
        public string Reference { get; set; }
        public string Poznamka { get; set; }
        public double? VrtaniBaze1 { get; set; }
        public double? VrtaniPrumer1 { get; set; }
        public string VrtaniPoznamka1 { get; set; }
        public double? VrtaniBaze2 { get; set; }
        public double? VrtaniPrumer2 { get; set; }
        public string VrtaniPoznamka2 { get; set; }
        public double? VrtaniBaze3 { get; set; }
        public double? VrtaniPrumer3 { get; set; }
        public string VrtaniPoznamka3 { get; set; }
        public double? VrtaniBaze4 { get; set; }
        public double? VrtaniPrumer4 { get; set; }
        public string VrtaniPoznamka4 { get; set; }
        public double? PazeniOd1 { get; set; }
        public double? PazeniDo1 { get; set; }
        public double? PazeniPrumer1 { get; set; }
        public string PazeniPoznamka1 { get; set; }
        public double? PazeniOd2 { get; set; }
        public double? PazeniDo2 { get; set; }
        public double? PazeniPrumer2 { get; set; }
        public string PazeniPoznamka2 { get; set; }
        public double? PazeniOd3 { get; set; }
        public double? PazeniDo3 { get; set; }
        public double? PazeniPrumer3 { get; set; }
        public string PazeniPoznamka3 { get; set; }
        public double? PerforaceOd1 { get; set; }
        public double? PerforaceDo1 { get; set; }
        public double? PerforaceOd2 { get; set; }
        public double? PerforaceDo2 { get; set; }
        public double? PerforaceOd3 { get; set; }
        public double? PerforaceDo3 { get; set; }
        public double? VyplOd1 { get; set; }
        public double? VyplDo1 { get; set; }
        public double? PrumerVnitrni1 { get; set; }
        public double? PrumerVnejsi1 { get; set; }
        public string Material1 { get; set; }
        public double? VyplOd2 { get; set; }
        public double? VyplnDo2 { get; set; }
        public double? PrumerVnitrni2 { get; set; }
        public double? PrumerVnejsi2 { get; set; }
        public string Material2 { get; set; }
        public double? VyplnOd3 { get; set; }
        public double? VyplnDo3 { get; set; }
        public double? PrumerVnitrni3 { get; set; }
        public double? PrumerVnejsi3 { get; set; }
        public string Material3 { get; set; }
        public double? VyplnOd4 { get; set; }
        public double? VyplnDo4 { get; set; }
        public double? PrumerVnitrni4 { get; set; }
        public double? PrumerVnejsi4 { get; set; }
        public string Material4 { get; set; }
        public double? VyplnOd5 { get; set; }
        public double? VyplnDo5 { get; set; }
        public double? PrumerVnitrni5 { get; set; }
        public double? PrumerVnejsi5 { get; set; }
        public string Material5 { get; set; }
        public double? VyplOd6 { get; set; }
        public double? VypnDo6 { get; set; }
        public double? PrumerVnitrni6 { get; set; }
        public double? PrumerVnejsi6 { get; set; }
        public string Material6 { get; set; }
        public double? VypnOd7 { get; set; }
        public double? VypnDo7 { get; set; }
        public double? PrumerVnitrni7 { get; set; }
        public double? PrumerVnejsi7 { get; set; }
        public string Material7 { get; set; }
        public double? VyplnOd8 { get; set; }
        public double? VyplnDo8 { get; set; }
        public double? PrumerVnitrni8 { get; set; }
        public double? PrumerVnejsi8 { get; set; }
        public string Material8 { get; set; }
        public DateTime? NewD { get; set; }
        public string NewU { get; set; }
        public DateTime? ModifD { get; set; }
        public string ModifU { get; set; }
        public DateTime? Reftime { get; set; }
        public DateTime? DeleteD { get; set; }
        public string DeleteU { get; set; }
        public double? NGps { get; set; }
        public double? EGps { get; set; }
        public double? ZGps { get; set; }
        public int? Uroven { get; set; }
        public string UrovenZduvodneni { get; set; }

        public virtual Mraky Mrak { get; set; }
        public virtual ICollection<AnalyzyOstatni> AnalyzyOstatni { get; set; }
        public virtual ICollection<Aplikace> Aplikace { get; set; }
        public virtual ICollection<BtexNel> BtexNel { get; set; }
        public virtual ICollection<Cerpani> Cerpani { get; set; }
        public virtual ICollection<Clu> Clu { get; set; }
        public virtual ICollection<HpvFaze> HpvFaze { get; set; }
        public virtual ICollection<Litologie> Litologie { get; set; }
        public virtual ICollection<Meteodata> Meteodata { get; set; }
        public virtual ICollection<Plovaky> Plovaky { get; set; }
        public virtual ICollection<Prilohy> Prilohy { get; set; }
        public virtual ICollection<Redox> Redox { get; set; }
        public virtual ICollection<Uchr> Uchr { get; set; }
    }
}
