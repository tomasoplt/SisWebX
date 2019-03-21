using System;
using System.Collections.Generic;

namespace SisWeb.EF.Models
{
    public partial class Uchr
    {
        public int UchrId { get; set; }
        public int? ObjektId { get; set; }
        public DateTime? Odber { get; set; }
        public double? HloubkaOdberu { get; set; }
        public string TypOdberu { get; set; }
        public string Protokol { get; set; }
        public string Vzorek { get; set; }
        public string VzorekTyp { get; set; }
        public double? AmonneIonty { get; set; }
        public double? Chloridy { get; set; }
        public double? Bromidy { get; set; }
        public double? Dusicnany { get; set; }
        public double? Dusitany { get; set; }
        public double? Fluoridy { get; set; }
        public double? Knk45 { get; set; }
        public double? Znk83 { get; set; }
        public double? Ph { get; set; }
        public double? Sirany { get; set; }
        public double? Siricitany { get; set; }
        public double? SulfanVolny { get; set; }
        public double? Konduktivita { get; set; }
        public double? Fosforecnany { get; set; }
        public double? Co2AgresivniVypocet { get; set; }
        public double? Co2VolnyVypocet { get; set; }
        public double? Hydrogenuhlicitany { get; set; }
        public double? Uhlicitany { get; set; }
        public double? KolonieAerobni { get; set; }
        public double? KolonieAnaerobni { get; set; }
        public double? ChskCr { get; set; }
        public double? Ras { get; set; }
        public double? Nl105 { get; set; }
        public double? Rozpustene { get; set; }
        public double? Draslik { get; set; }
        public double? OxidKremicity { get; set; }
        public double? Sodik { get; set; }
        public double? Vapnik { get; set; }
        public double? Lithium { get; set; }
        public double? Arsen { get; set; }
        public double? PCelkovy { get; set; }
        public double? NCelkovy { get; set; }
        public double? Bsk5 { get; set; }
        public double? TvrdostCelkem { get; set; }
        public double? MineralizaceCelkem { get; set; }
        public double? ObjemovaHmotnost { get; set; }
        public double? Sirouhlik { get; set; }
        public double? KyanidyCelkove { get; set; }
        public double? KyanidyVolne { get; set; }
        public double? Kmno4 { get; set; }
        public double? H2o2 { get; set; }
        public string Barva { get; set; }
        public string Sediment { get; set; }
        public string Pach { get; set; }
        public double? Baryum { get; set; }
        public double? Berylium { get; set; }
        public double? Horcik { get; set; }
        public double? Hlinik { get; set; }
        public double? Chrom { get; set; }
        public double? Kadmium { get; set; }
        public double? Kobalt { get; set; }
        public double? Mangan { get; set; }
        public double? Med { get; set; }
        public double? Molybden { get; set; }
        public double? Nikl { get; set; }
        public double? Olovo { get; set; }
        public double? Rtut { get; set; }
        public double? Vanad { get; set; }
        public double? Zinek { get; set; }
        public double? Zelezo { get; set; }
        public double? Fe2 { get; set; }
        public double? Fe0 { get; set; }
        public DateTime? NewD { get; set; }
        public string NewU { get; set; }
        public DateTime? ModifD { get; set; }
        public string ModifU { get; set; }
        public DateTime? Reftime { get; set; }
        public DateTime? DeleteD { get; set; }
        public string DeleteU { get; set; }
        public double? ChskMn { get; set; }
        public string ChemickyTypVody { get; set; }
        public string Realizace { get; set; }
        public string Poznamka { get; set; }
        public double? Sulfidy { get; set; }
        public double? AlfaAktivita { get; set; }
        public double? BetaAktivita { get; set; }
        public double? Tic { get; set; }
        public double? Brru { get; set; }
        public double? LatkyVeskere { get; set; }
        public double? Doc { get; set; }
        public double? Toc { get; set; }

        public virtual Objekty Objekt { get; set; }
    }
}
