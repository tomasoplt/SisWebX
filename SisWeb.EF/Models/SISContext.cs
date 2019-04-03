using Microsoft.EntityFrameworkCore;

namespace SisWeb.EF.Models
{
    public partial class SISContext : Core.EF.EntityFrameworkCore.AppDbContext
    {
        public string ConnectionString;

        public SISContext()
        {
        }

        public SISContext(DbContextOptions<SISContext> options)
            : base(options)
        {
        }

        public SISContext(string connectionString) : base(connectionString)
        {
            this.ConnectionString = connectionString;
        }

        public virtual DbSet<AnalyzyOstatni> AnalyzyOstatni { get; set; }
        public virtual DbSet<Aplikace> Aplikace { get; set; }
        public virtual DbSet<BtexNel> BtexNel { get; set; }
        public virtual DbSet<Cerpani> Cerpani { get; set; }
        public virtual DbSet<Clu> Clu { get; set; }
        public virtual DbSet<DeletedObject> DeletedObject { get; set; }
        public virtual DbSet<HpvFaze> HpvFaze { get; set; }
        public virtual DbSet<Jednotky> Jednotky { get; set; }
        public virtual DbSet<JednotkyTypyvzorkuVeliciny> JednotkyTypyvzorkuVeliciny { get; set; }
        public virtual DbSet<JednotkyVeliciny> JednotkyVeliciny { get; set; }
        public virtual DbSet<Klienti> Klienti { get; set; }
        public virtual DbSet<Kriteria> Kriteria { get; set; }
        public virtual DbSet<Litkody> Litkody { get; set; }
        public virtual DbSet<Litologie> Litologie { get; set; }
        public virtual DbSet<Meteodata> Meteodata { get; set; }
        public virtual DbSet<Mraky> Mraky { get; set; }
        public virtual DbSet<Objekty> Objekty { get; set; }
        public virtual DbSet<Parametry> Parametry { get; set; }
        public virtual DbSet<Pesticidy> Pesticidy { get; set; }
        public virtual DbSet<Plovaky> Plovaky { get; set; }
        public virtual DbSet<Prilohy> Prilohy { get; set; }
        public virtual DbSet<Redox> Redox { get; set; }
        public virtual DbSet<Reporty> Reporty { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<RoleUzivatele> RoleUzivatele { get; set; }
        public virtual DbSet<Uchr> Uchr { get; set; }
        public virtual DbSet<Urovne> Urovne { get; set; }
        public virtual DbSet<Uzivatele> Uzivatele { get; set; }

        // Unable to generate entity type for table 'dbo.logy'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.nastaveni_uzivatel'. Please see the warning messages.

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured || !string.IsNullOrEmpty(ConnectionString))
            {
                optionsBuilder.UseSqlServer(ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "3.0.0-preview.19074.3");

            modelBuilder.Entity<AnalyzyOstatni>(entity =>
            {
                entity.ToTable("analyzy_ostatni");

                entity.Property(e => e.AnalyzyOstatniId)
                    .HasColumnName("analyzy_ostatni_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Ch4).HasColumnName("ch4");

                entity.Property(e => e.Co2).HasColumnName("co2");

                entity.Property(e => e.DeleteD)
                    .HasColumnName("delete_d")
                    .HasColumnType("datetime");

                entity.Property(e => e.DeleteU)
                    .HasColumnName("delete_u")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.HloubkaOdberu).HasColumnName("hloubka_odberu");

                entity.Property(e => e.ModifD)
                    .HasColumnName("modif_d")
                    .HasColumnType("datetime");

                entity.Property(e => e.ModifU)
                    .HasColumnName("modif_u")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.NewD)
                    .HasColumnName("new_d")
                    .HasColumnType("datetime");

                entity.Property(e => e.NewU)
                    .HasColumnName("new_u")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.O2).HasColumnName("o2");

                entity.Property(e => e.ObjektId).HasColumnName("objekt_id");

                entity.Property(e => e.Odber)
                    .HasColumnName("odber")
                    .HasColumnType("datetime");

                entity.Property(e => e.Pid118).HasColumnName("pid118");

                entity.Property(e => e.Poznamka)
                    .HasColumnName("poznamka")
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.Protokol)
                    .HasColumnName("protokol")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Realizace)
                    .HasColumnName("realizace")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Reftime)
                    .HasColumnName("reftime")
                    .HasColumnType("datetime");

                entity.Property(e => e.Tlak).HasColumnName("tlak");

                entity.Property(e => e.Tp).HasColumnName("tp");

                entity.Property(e => e.TypOdberu)
                    .HasColumnName("typ_odberu")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Vzorek)
                    .HasColumnName("vzorek")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.VzorekTyp)
                    .HasColumnName("vzorek_typ")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.HasOne(d => d.Objekt)
                    .WithMany(p => p.AnalyzyOstatni)
                    .HasForeignKey(d => d.ObjektId)
                    .HasConstraintName("FK_analyzy_ostatni_objekty");
            });

            modelBuilder.Entity<Aplikace>(entity =>
            {
                entity.ToTable("aplikace");

                entity.Property(e => e.AplikaceId)
                    .HasColumnName("aplikace_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.AplikovanaLatka)
                    .HasColumnName("aplikovana_latka")
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.AplikovanoDo)
                    .HasColumnName("aplikovano_do")
                    .HasColumnType("datetime");

                entity.Property(e => e.AplikovanoOd)
                    .HasColumnName("aplikovano_od")
                    .HasColumnType("datetime");

                entity.Property(e => e.DeleteD)
                    .HasColumnName("delete_d")
                    .HasColumnType("datetime");

                entity.Property(e => e.DeleteU)
                    .HasColumnName("delete_u")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Koncentrace).HasColumnName("koncentrace");

                entity.Property(e => e.Mnozstvi).HasColumnName("mnozstvi");

                entity.Property(e => e.ModifD)
                    .HasColumnName("modif_d")
                    .HasColumnType("datetime");

                entity.Property(e => e.ModifU)
                    .HasColumnName("modif_u")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.NewD)
                    .HasColumnName("new_d")
                    .HasColumnType("datetime");

                entity.Property(e => e.NewU)
                    .HasColumnName("new_u")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ObjektId).HasColumnName("objekt_id");

                entity.Property(e => e.Poznamka)
                    .HasColumnName("poznamka")
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.Realizace)
                    .HasColumnName("realizace")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Reftime)
                    .HasColumnName("reftime")
                    .HasColumnType("datetime");

                entity.Property(e => e.TypLatky)
                    .HasColumnName("typ_latky")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.Objekt)
                    .WithMany(p => p.Aplikace)
                    .HasForeignKey(d => d.ObjektId)
                    .HasConstraintName("FK_aplikace_objekty");
            });

            modelBuilder.Entity<BtexNel>(entity =>
            {
                entity.ToTable("btex_nel");

                entity.Property(e => e.BtexNelId)
                    .HasColumnName("btex_nel_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Benzen).HasColumnName("benzen");

                entity.Property(e => e.DeleteD)
                    .HasColumnName("delete_d")
                    .HasColumnType("datetime");

                entity.Property(e => e.DeleteU)
                    .HasColumnName("delete_u")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Dimethylfenoly).HasColumnName("dimethylfenoly");

                entity.Property(e => e.Edta).HasColumnName("edta");

                entity.Property(e => e.Ethan).HasColumnName("ethan");

                entity.Property(e => e.Ethen).HasColumnName("ethen");

                entity.Property(e => e.Ethylbenzen).HasColumnName("ethylbenzen");

                entity.Property(e => e.Fenol).HasColumnName("fenol");

                entity.Property(e => e.HloubkaOdberu).HasColumnName("hloubka_odberu");

                entity.Property(e => e.Kresoly).HasColumnName("kresoly");

                entity.Property(e => e.KyselinaCitronova).HasColumnName("kyselina_citronova");

                entity.Property(e => e.Methan).HasColumnName("methan");

                entity.Property(e => e.ModifD)
                    .HasColumnName("modif_d")
                    .HasColumnType("datetime");

                entity.Property(e => e.ModifU)
                    .HasColumnName("modif_u")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Mtbe).HasColumnName("mtbe");

                entity.Property(e => e.NaFluorescein).HasColumnName("na_fluorescein");

                entity.Property(e => e.Naftalen).HasColumnName("naftalen");

                entity.Property(e => e.Nel).HasColumnName("nel");

                entity.Property(e => e.NewD)
                    .HasColumnName("new_d")
                    .HasColumnType("datetime");

                entity.Property(e => e.NewU)
                    .HasColumnName("new_u")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ObjektId).HasColumnName("objekt_id");

                entity.Property(e => e.Odber)
                    .HasColumnName("odber")
                    .HasColumnType("datetime");

                entity.Property(e => e.Poznamka)
                    .HasColumnName("poznamka")
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.Protokol)
                    .HasColumnName("protokol")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Realizace)
                    .HasColumnName("realizace")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Reftime)
                    .HasColumnName("reftime")
                    .HasColumnType("datetime");

                entity.Property(e => e.Styren).HasColumnName("styren");

                entity.Property(e => e.Toluen).HasColumnName("toluen");

                entity.Property(e => e.TypOdberu)
                    .HasColumnName("typ_odberu")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UhlovodikyC10C40).HasColumnName("uhlovodiky_c10_c40");

                entity.Property(e => e.VyssiFenoly).HasColumnName("vyssi_fenoly");

                entity.Property(e => e.Vzorek)
                    .HasColumnName("vzorek")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.VzorekTyp)
                    .HasColumnName("vzorek_typ")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Xyleny).HasColumnName("xyleny");

                entity.HasOne(d => d.Objekt)
                    .WithMany(p => p.BtexNel)
                    .HasForeignKey(d => d.ObjektId)
                    .HasConstraintName("FK_btex_nel_objekty");
            });

            modelBuilder.Entity<Cerpani>(entity =>
            {
                entity.ToTable("cerpani");

                entity.Property(e => e.CerpaniId)
                    .HasColumnName("cerpani_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.DeleteD)
                    .HasColumnName("delete_d")
                    .HasColumnType("datetime");

                entity.Property(e => e.DeleteU)
                    .HasColumnName("delete_u")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.DelkaVytlacnehoPotrubi).HasColumnName("delka_vytlacneho_potrubi");

                entity.Property(e => e.DodrzeniParametru)
                    .HasColumnName("dodrzeni_parametru")
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.DuvodNedodrzeniParametru)
                    .HasColumnName("duvod_nedodrzeni_parametru")
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.Fotodokumentace)
                    .HasColumnName("fotodokumentace")
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.HodnoceniVykonuCerpadla)
                    .HasColumnName("hodnoceni_vykonu_cerpadla")
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.HpvProvozni).HasColumnName("hpv_provozni");

                entity.Property(e => e.KlimatickePodminky)
                    .HasColumnName("klimaticke_podminky")
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.Kolektor)
                    .HasColumnName("kolektor")
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.KontaktniOsoby)
                    .HasColumnName("kontaktni_osoby")
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.Mereno)
                    .HasColumnName("mereno")
                    .HasColumnType("datetime");

                entity.Property(e => e.MeridloPrutokuAUmisteni)
                    .HasColumnName("meridlo_prutoku_a_umisteni")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.ModifD)
                    .HasColumnName("modif_d")
                    .HasColumnType("datetime");

                entity.Property(e => e.ModifU)
                    .HasColumnName("modif_u")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.NewD)
                    .HasColumnName("new_d")
                    .HasColumnType("datetime");

                entity.Property(e => e.NewU)
                    .HasColumnName("new_u")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ObjektId).HasColumnName("objekt_id");

                entity.Property(e => e.Odstaveni)
                    .HasColumnName("odstaveni")
                    .HasColumnType("datetime");

                entity.Property(e => e.OvlivneniCz)
                    .HasColumnName("ovlivneni_cz")
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.OvlivneniHpvProvozni)
                    .HasColumnName("ovlivneni_hpv_provozni")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.PopisNedodrzenychParametru)
                    .HasColumnName("popis_nedodrzenych_parametru")
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.PopisOb)
                    .HasColumnName("popis_ob")
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.PopisVydatnostiJo)
                    .HasColumnName("popis_vydatnosti_jo")
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.Poznamka)
                    .HasColumnName("poznamka")
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.Pretok).HasColumnName("pretok");

                entity.Property(e => e.QDopoctene).HasColumnName("q_dopoctene");

                entity.Property(e => e.QNastavene).HasColumnName("q_nastavene");

                entity.Property(e => e.QProvozni).HasColumnName("q_provozni");

                entity.Property(e => e.Realizace)
                    .HasColumnName("realizace")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Reftime)
                    .HasColumnName("reftime")
                    .HasColumnType("datetime");

                entity.Property(e => e.RezimOdberuVody)
                    .HasColumnName("rezim_odberu_vody")
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.SenzorickeVlastnosti)
                    .HasColumnName("senzoricke_vlastnosti")
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.SnizeniHpvProvozni).HasColumnName("snizeni_hpv_provozni");

                entity.Property(e => e.SpecifickaVydatnost).HasColumnName("specificka_vydatnost");

                entity.Property(e => e.StavMeridla).HasColumnName("stav_meridla");

                entity.Property(e => e.StavObjektu)
                    .HasColumnName("stav_objektu")
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.Typ)
                    .HasColumnName("typ")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.TypCerpadla)
                    .HasColumnName("typ_cerpadla")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.VykonCerpadlaBezny).HasColumnName("vykon_cerpadla_bezny");

                entity.Property(e => e.VzdalenostCidla).HasColumnName("vzdalenost_cidla");

                entity.Property(e => e.VzdalenostOb).HasColumnName("vzdalenost_ob");

                entity.HasOne(d => d.Objekt)
                    .WithMany(p => p.Cerpani)
                    .HasForeignKey(d => d.ObjektId)
                    .HasConstraintName("FK_cerpani_objekty");
            });

            modelBuilder.Entity<Clu>(entity =>
            {
                entity.ToTable("clu");

                entity.Property(e => e.CluId)
                    .HasColumnName("clu_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Aox).HasColumnName("aox");

                entity.Property(e => e.CDce12).HasColumnName("c_dce_1_2");

                entity.Property(e => e.Chlorbenzen).HasColumnName("chlorbenzen");

                entity.Property(e => e.Chlormethan).HasColumnName("chlormethan");

                entity.Property(e => e.Dce11).HasColumnName("dce_1_1");

                entity.Property(e => e.DeleteD)
                    .HasColumnName("delete_d")
                    .HasColumnType("datetime");

                entity.Property(e => e.DeleteU)
                    .HasColumnName("delete_u")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Dichlorbenzen12).HasColumnName("dichlorbenzen_1_2");

                entity.Property(e => e.Dichlorbenzen13).HasColumnName("dichlorbenzen_1_3");

                entity.Property(e => e.Dichlorbenzen14).HasColumnName("dichlorbenzen_1_4");

                entity.Property(e => e.Dichlorbenzeny).HasColumnName("dichlorbenzeny");

                entity.Property(e => e.Dichlorethan11).HasColumnName("dichlorethan_1_1");

                entity.Property(e => e.Dichlorethan12).HasColumnName("dichlorethan_1_2");

                entity.Property(e => e.Dichlormethan).HasColumnName("dichlormethan");

                entity.Property(e => e.Dichlorpropan12).HasColumnName("dichlorpropan_1_2");

                entity.Property(e => e.Dichlorpropylen11).HasColumnName("dichlorpropylen_1_1");

                entity.Property(e => e.Hexachlorbenzen).HasColumnName("hexachlorbenzen");

                entity.Property(e => e.Hexachlorobutadien).HasColumnName("hexachlorobutadien");

                entity.Property(e => e.HloubkaOdberu).HasColumnName("hloubka_odberu");

                entity.Property(e => e.ModifD)
                    .HasColumnName("modif_d")
                    .HasColumnType("datetime");

                entity.Property(e => e.ModifU)
                    .HasColumnName("modif_u")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.NewD)
                    .HasColumnName("new_d")
                    .HasColumnType("datetime");

                entity.Property(e => e.NewU)
                    .HasColumnName("new_u")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ObjektId).HasColumnName("objekt_id");

                entity.Property(e => e.Odber)
                    .HasColumnName("odber")
                    .HasColumnType("datetime");

                entity.Property(e => e.Pce).HasColumnName("pce");

                entity.Property(e => e.Pentachlorbenzen).HasColumnName("pentachlorbenzen");

                entity.Property(e => e.Poznamka)
                    .HasColumnName("poznamka")
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.Protokol)
                    .HasColumnName("protokol")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Realizace)
                    .HasColumnName("realizace")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Reftime)
                    .HasColumnName("reftime")
                    .HasColumnType("datetime");

                entity.Property(e => e.Rezerva1).HasColumnName("rezerva1");

                entity.Property(e => e.TDce12).HasColumnName("t_dce_1_2");

                entity.Property(e => e.Tce).HasColumnName("tce");

                entity.Property(e => e.Teq).HasColumnName("teq");

                entity.Property(e => e.Tetrachlorbenzeny).HasColumnName("tetrachlorbenzeny");

                entity.Property(e => e.Tetrachlorethan1112).HasColumnName("tetrachlorethan_1_1_1_2");

                entity.Property(e => e.Tetrachlorethan1122).HasColumnName("tetrachlorethan_1_1_2_2");

                entity.Property(e => e.Tetrachlormethan).HasColumnName("tetrachlormethan");

                entity.Property(e => e.Tetrachlorobenzen1234).HasColumnName("tetrachlorobenzen_1_2_3_4");

                entity.Property(e => e.Tetrachlorobenzen1235Plus1245).HasColumnName("tetrachlorobenzen_1_2_3_5_plus_1_2_4_5");

                entity.Property(e => e.Trichlorbenzen123).HasColumnName("trichlorbenzen_1_2_3");

                entity.Property(e => e.Trichlorbenzen124).HasColumnName("trichlorbenzen_1_2_4");

                entity.Property(e => e.Trichlorbenzen135).HasColumnName("trichlorbenzen_1_3_5");

                entity.Property(e => e.Trichlorbenzeny).HasColumnName("trichlorbenzeny");

                entity.Property(e => e.Trichlorethan111).HasColumnName("trichlorethan_1_1_1");

                entity.Property(e => e.Trichlorethan112).HasColumnName("trichlorethan_1_1_2");

                entity.Property(e => e.Trichlormethan).HasColumnName("trichlormethan");

                entity.Property(e => e.Trichlorpropan123).HasColumnName("trichlorpropan_1_2_3");

                entity.Property(e => e.TypOdberu)
                    .HasColumnName("typ_odberu")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Vc).HasColumnName("vc");

                entity.Property(e => e.Vzorek)
                    .HasColumnName("vzorek")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.VzorekTyp)
                    .HasColumnName("vzorek_typ")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.HasOne(d => d.Objekt)
                    .WithMany(p => p.Clu)
                    .HasForeignKey(d => d.ObjektId)
                    .HasConstraintName("FK_clu_objekty");
            });

            modelBuilder.Entity<DeletedObject>(entity =>
            {
                entity.ToTable("deleted_object");

                entity.Property(e => e.DeletedObjectId).HasColumnName("deleted_object_id");

                entity.Property(e => e.Commited).HasColumnName("commited");

                entity.Property(e => e.ObjectType)
                    .IsRequired()
                    .HasColumnName("object_type")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PkValue).HasColumnName("pk_value");

                entity.Property(e => e.Reftime)
                    .HasColumnName("reftime")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<HpvFaze>(entity =>
            {
                entity.HasKey(e => e.HpvId);

                entity.ToTable("hpv_faze");

                entity.Property(e => e.HpvId)
                    .HasColumnName("hpv_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.DeleteD)
                    .HasColumnName("delete_d")
                    .HasColumnType("datetime");

                entity.Property(e => e.DeleteU)
                    .HasColumnName("delete_u")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.HladinaFaze).HasColumnName("hladina_faze");

                entity.Property(e => e.HladinaVoda).HasColumnName("hladina_voda");

                entity.Property(e => e.Mereno)
                    .HasColumnName("mereno")
                    .HasColumnType("datetime");

                entity.Property(e => e.ModifD)
                    .HasColumnName("modif_d")
                    .HasColumnType("datetime");

                entity.Property(e => e.ModifU)
                    .HasColumnName("modif_u")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.NewD)
                    .HasColumnName("new_d")
                    .HasColumnType("datetime");

                entity.Property(e => e.NewU)
                    .HasColumnName("new_u")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ObjektId).HasColumnName("objekt_id");

                entity.Property(e => e.Poznamka)
                    .HasColumnName("poznamka")
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.Realizace)
                    .HasColumnName("realizace")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Reftime)
                    .HasColumnName("reftime")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.Objekt)
                    .WithMany(p => p.HpvFaze)
                    .HasForeignKey(d => d.ObjektId)
                    .HasConstraintName("FK_hpv_faze_objekty");
            });

            modelBuilder.Entity<Jednotky>(entity =>
            {
                entity.HasKey(e => e.JednotkaId);

                entity.ToTable("jednotky");

                entity.Property(e => e.JednotkaId)
                    .HasColumnName("jednotka_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.DeleteD)
                    .HasColumnName("delete_d")
                    .HasColumnType("datetime");

                entity.Property(e => e.DeleteU)
                    .HasColumnName("delete_u")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Jednotka)
                    .HasColumnName("jednotka")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.ModifD)
                    .HasColumnName("modif_d")
                    .HasColumnType("datetime");

                entity.Property(e => e.ModifU)
                    .HasColumnName("modif_u")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.NewD)
                    .HasColumnName("new_d")
                    .HasColumnType("datetime");

                entity.Property(e => e.NewU)
                    .HasColumnName("new_u")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Poznamka)
                    .HasColumnName("poznamka")
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.Reftime)
                    .HasColumnName("reftime")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<JednotkyTypyvzorkuVeliciny>(entity =>
            {
                entity.HasKey(e => e.JednotkaTypvzorkuVelicinaId);

                entity.ToTable("jednotky_typyvzorku_veliciny");

                entity.Property(e => e.JednotkaTypvzorkuVelicinaId)
                    .HasColumnName("jednotka_typvzorku_velicina_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Acetochlor).HasColumnName("acetochlor");

                entity.Property(e => e.AcetochlorEsa).HasColumnName("acetochlor_esa");

                entity.Property(e => e.AcetochlorOa).HasColumnName("acetochlor_oa");

                entity.Property(e => e.Alachlor).HasColumnName("alachlor");

                entity.Property(e => e.AlachlorEsa).HasColumnName("alachlor_esa");

                entity.Property(e => e.AlachlorOa).HasColumnName("alachlor_oa");

                entity.Property(e => e.Aldrin).HasColumnName("aldrin");

                entity.Property(e => e.AlfaAktivita).HasColumnName("alfa_aktivita");

                entity.Property(e => e.AlfaEndosulfan).HasColumnName("alfa_endosulfan");

                entity.Property(e => e.AlfaHch).HasColumnName("alfa_hch");

                entity.Property(e => e.Ametryn).HasColumnName("ametryn");

                entity.Property(e => e.Aminopyralid).HasColumnName("aminopyralid");

                entity.Property(e => e.AmonneIonty).HasColumnName("amonne_ionty");

                entity.Property(e => e.Ampa).HasColumnName("ampa");

                entity.Property(e => e.Aox).HasColumnName("aox");

                entity.Property(e => e.Arsen).HasColumnName("arsen");

                entity.Property(e => e.Atraton).HasColumnName("atraton");

                entity.Property(e => e.Atrazin).HasColumnName("atrazin");

                entity.Property(e => e.AtrazinDesethyl).HasColumnName("atrazin_desethyl");

                entity.Property(e => e.AtrazinDesethylDesisopropyl).HasColumnName("atrazin_desethyl_desisopropyl");

                entity.Property(e => e.AtrazinDesisopropyl).HasColumnName("atrazin_desisopropyl");

                entity.Property(e => e.AtrazinHydroxy).HasColumnName("atrazin_hydroxy");

                entity.Property(e => e.Azoxystrobin).HasColumnName("azoxystrobin");

                entity.Property(e => e.Barva).HasColumnName("barva");

                entity.Property(e => e.Baryum).HasColumnName("baryum");

                entity.Property(e => e.Bentazone).HasColumnName("bentazone");

                entity.Property(e => e.BentazoneMethyl).HasColumnName("bentazone_methyl");

                entity.Property(e => e.Benzen).HasColumnName("benzen");

                entity.Property(e => e.Berylium).HasColumnName("berylium");

                entity.Property(e => e.BetaAktivita).HasColumnName("beta_aktivita");

                entity.Property(e => e.BetaEndosulfan).HasColumnName("beta_endosulfan");

                entity.Property(e => e.BetaHch).HasColumnName("beta_hch");

                entity.Property(e => e.Bromacil).HasColumnName("bromacil");

                entity.Property(e => e.Bromidy).HasColumnName("bromidy");

                entity.Property(e => e.Bromoxynil).HasColumnName("bromoxynil");

                entity.Property(e => e.Brru).HasColumnName("brru");

                entity.Property(e => e.Bsk5).HasColumnName("bsk_5");

                entity.Property(e => e.CDce12).HasColumnName("c_dce_1_2");

                entity.Property(e => e.Caffeine).HasColumnName("caffeine");

                entity.Property(e => e.Carbamazepin).HasColumnName("carbamazepin");

                entity.Property(e => e.Carbendazim).HasColumnName("carbendazim");

                entity.Property(e => e.Carbofuran).HasColumnName("carbofuran");

                entity.Property(e => e.Ch4).HasColumnName("ch4");

                entity.Property(e => e.ChemickyTypVody).HasColumnName("chemicky_typ_vody");

                entity.Property(e => e.Chlorantraniliprol).HasColumnName("chlorantraniliprol");

                entity.Property(e => e.Chlorbenzen).HasColumnName("chlorbenzen");

                entity.Property(e => e.Chlorbromuron).HasColumnName("chlorbromuron");

                entity.Property(e => e.Chlorfenvinphos).HasColumnName("chlorfenvinphos");

                entity.Property(e => e.Chloridazon).HasColumnName("chloridazon");

                entity.Property(e => e.ChloridazonDesphenyl).HasColumnName("chloridazon_desphenyl");

                entity.Property(e => e.ChloridazonMethylDesphenyl).HasColumnName("chloridazon_methyl_desphenyl");

                entity.Property(e => e.Chloridy).HasColumnName("chloridy");

                entity.Property(e => e.Chlormethan).HasColumnName("chlormethan");

                entity.Property(e => e.Chlorotoluron).HasColumnName("chlorotoluron");

                entity.Property(e => e.ChlorotoluronDesmethyl).HasColumnName("chlorotoluron_desmethyl");

                entity.Property(e => e.Chlorpyrifos).HasColumnName("chlorpyrifos");

                entity.Property(e => e.Chlorsulfuron).HasColumnName("chlorsulfuron");

                entity.Property(e => e.Chrom).HasColumnName("chrom");

                entity.Property(e => e.ChskCr).HasColumnName("chsk_cr");

                entity.Property(e => e.ChskMn).HasColumnName("chsk_mn");

                entity.Property(e => e.CisChlordan).HasColumnName("cis_chlordan");

                entity.Property(e => e.CisHeptachlorepoxid).HasColumnName("cis_heptachlorepoxid");

                entity.Property(e => e.Clomazone).HasColumnName("clomazone");

                entity.Property(e => e.Clopyralid).HasColumnName("clopyralid");

                entity.Property(e => e.Co2).HasColumnName("co2");

                entity.Property(e => e.Co2AgresivniVypocet).HasColumnName("co2_agresivni_vypocet");

                entity.Property(e => e.Co2VolnyVypocet).HasColumnName("co2_volny_vypocet");

                entity.Property(e => e.Cyanazine).HasColumnName("cyanazine");

                entity.Property(e => e.Cyproconazole).HasColumnName("cyproconazole");

                entity.Property(e => e.Dce11).HasColumnName("dce_1_1");

                entity.Property(e => e.DeleteD)
                    .HasColumnName("delete_d")
                    .HasColumnType("datetime");

                entity.Property(e => e.DeleteU)
                    .HasColumnName("delete_u")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.DeltaHch).HasColumnName("delta_hch");

                entity.Property(e => e.Desmedipham).HasColumnName("desmedipham");

                entity.Property(e => e.Desmetryn).HasColumnName("desmetryn");

                entity.Property(e => e.Diazinon).HasColumnName("diazinon");

                entity.Property(e => e.Dicamba).HasColumnName("dicamba");

                entity.Property(e => e.Dichlobenil).HasColumnName("dichlobenil");

                entity.Property(e => e.Dichlorbenzen12).HasColumnName("dichlorbenzen_1_2");

                entity.Property(e => e.Dichlorbenzen13).HasColumnName("dichlorbenzen_1_3");

                entity.Property(e => e.Dichlorbenzen14).HasColumnName("dichlorbenzen_1_4");

                entity.Property(e => e.Dichlorbenzeny).HasColumnName("dichlorbenzeny");

                entity.Property(e => e.Dichlorethan11).HasColumnName("dichlorethan_1_1");

                entity.Property(e => e.Dichlorethan12).HasColumnName("dichlorethan_1_2");

                entity.Property(e => e.Dichlormethan).HasColumnName("dichlormethan");

                entity.Property(e => e.Dichlormid).HasColumnName("dichlormid");

                entity.Property(e => e.Dichlorpropan12).HasColumnName("dichlorpropan_1_2");

                entity.Property(e => e.Dichlorpropylen11).HasColumnName("dichlorpropylen_1_1");

                entity.Property(e => e.Dieldrin).HasColumnName("dieldrin");

                entity.Property(e => e.Diethyltoluamid).HasColumnName("diethyltoluamid");

                entity.Property(e => e.Dimethachlor).HasColumnName("dimethachlor");

                entity.Property(e => e.Dimethenamide).HasColumnName("dimethenamide");

                entity.Property(e => e.Dimethipin).HasColumnName("dimethipin");

                entity.Property(e => e.Dimethoat).HasColumnName("dimethoat");

                entity.Property(e => e.Dimethomorph).HasColumnName("dimethomorph");

                entity.Property(e => e.Dimethylfenoly).HasColumnName("dimethylfenoly");

                entity.Property(e => e.Diuron).HasColumnName("diuron");

                entity.Property(e => e.DiuronDesmethylDcpmu).HasColumnName("diuron_desmethyl_dcpmu");

                entity.Property(e => e.Doc).HasColumnName("doc");

                entity.Property(e => e.Draslik).HasColumnName("draslik");

                entity.Property(e => e.Dusicnany).HasColumnName("dusicnany");

                entity.Property(e => e.Dusitany).HasColumnName("dusitany");

                entity.Property(e => e.Edta).HasColumnName("edta");

                entity.Property(e => e.EndosulfanSulfat).HasColumnName("endosulfan_sulfat");

                entity.Property(e => e.Endrin).HasColumnName("endrin");

                entity.Property(e => e.Epoxiconazole).HasColumnName("epoxiconazole");

                entity.Property(e => e.EpsilonHch).HasColumnName("epsilon_hch");

                entity.Property(e => e.Ethan).HasColumnName("ethan");

                entity.Property(e => e.Ethen).HasColumnName("ethen");

                entity.Property(e => e.Ethofumesate).HasColumnName("ethofumesate");

                entity.Property(e => e.Ethylbenzen).HasColumnName("ethylbenzen");

                entity.Property(e => e.Fe0).HasColumnName("fe0");

                entity.Property(e => e.Fe2).HasColumnName("fe2");

                entity.Property(e => e.Fenarimol).HasColumnName("fenarimol");

                entity.Property(e => e.Fenhexamid).HasColumnName("fenhexamid");

                entity.Property(e => e.Fenol).HasColumnName("fenol");

                entity.Property(e => e.Fenpropidin).HasColumnName("fenpropidin");

                entity.Property(e => e.Fenpropimorph).HasColumnName("fenpropimorph");

                entity.Property(e => e.Florasulam).HasColumnName("florasulam");

                entity.Property(e => e.FluazifopP).HasColumnName("fluazifop_p");

                entity.Property(e => e.FluazifopPButyl).HasColumnName("fluazifop_p_butyl");

                entity.Property(e => e.Fluoridy).HasColumnName("fluoridy");

                entity.Property(e => e.Fluroxypyr).HasColumnName("fluroxypyr");

                entity.Property(e => e.Flusilazole).HasColumnName("flusilazole");

                entity.Property(e => e.Foramsulfuron).HasColumnName("foramsulfuron");

                entity.Property(e => e.Fosforecnany).HasColumnName("fosforecnany");

                entity.Property(e => e.GamaHch).HasColumnName("gama_hch");

                entity.Property(e => e.Glyphosate).HasColumnName("glyphosate");

                entity.Property(e => e.H2o2).HasColumnName("h2o2");

                entity.Property(e => e.Heptachlor).HasColumnName("heptachlor");

                entity.Property(e => e.Hexachlorbenzen).HasColumnName("hexachlorbenzen");

                entity.Property(e => e.Hexachlorobutadien).HasColumnName("hexachlorobutadien");

                entity.Property(e => e.Hexazinon).HasColumnName("hexazinon");

                entity.Property(e => e.Hlinik).HasColumnName("hlinik");

                entity.Property(e => e.Horcik).HasColumnName("horcik");

                entity.Property(e => e.Hydrogenuhlicitany).HasColumnName("hydrogenuhlicitany");

                entity.Property(e => e.ImazamethabenzMethyl).HasColumnName("imazamethabenz_methyl");

                entity.Property(e => e.Imazamox).HasColumnName("imazamox");

                entity.Property(e => e.Imazethapyr).HasColumnName("imazethapyr");

                entity.Property(e => e.Imidacloprid).HasColumnName("imidacloprid");

                entity.Property(e => e.Iprodion).HasColumnName("iprodion");

                entity.Property(e => e.Isodrin).HasColumnName("isodrin");

                entity.Property(e => e.Isoproturon).HasColumnName("isoproturon");

                entity.Property(e => e.IsoproturonDesmethyl).HasColumnName("isoproturon_desmethyl");

                entity.Property(e => e.IsoproturonMonodesmethyl).HasColumnName("isoproturon_monodesmethyl");

                entity.Property(e => e.Kadmium).HasColumnName("kadmium");

                entity.Property(e => e.Kmno4).HasColumnName("kmno4");

                entity.Property(e => e.Knk45).HasColumnName("knk_45");

                entity.Property(e => e.Kobalt).HasColumnName("kobalt");

                entity.Property(e => e.KolonieAerobni).HasColumnName("kolonie_aerobni");

                entity.Property(e => e.KolonieAnaerobni).HasColumnName("kolonie_anaerobni");

                entity.Property(e => e.Konduktivita).HasColumnName("konduktivita");

                entity.Property(e => e.Kresoly).HasColumnName("kresoly");

                entity.Property(e => e.KresoximMethyl).HasColumnName("kresoxim_methyl");

                entity.Property(e => e.KyanidyCelkove).HasColumnName("kyanidy_celkove");

                entity.Property(e => e.KyanidyVolne).HasColumnName("kyanidy_volne");

                entity.Property(e => e.KyselinaCitronova).HasColumnName("kyselina_citronova");

                entity.Property(e => e.LatkyVeskere).HasColumnName("latky_veskere");

                entity.Property(e => e.Lenacil).HasColumnName("lenacil");

                entity.Property(e => e.Linuron).HasColumnName("linuron");

                entity.Property(e => e.Lithium).HasColumnName("lithium");

                entity.Property(e => e.Mangan).HasColumnName("mangan");

                entity.Property(e => e.Mcpa).HasColumnName("mcpa");

                entity.Property(e => e.Mcpb).HasColumnName("mcpb");

                entity.Property(e => e.McppMecoprop).HasColumnName("mcpp_mecoprop");

                entity.Property(e => e.Med).HasColumnName("med");

                entity.Property(e => e.Metalaxyl).HasColumnName("metalaxyl");

                entity.Property(e => e.Metamitron).HasColumnName("metamitron");

                entity.Property(e => e.Metazachlor).HasColumnName("metazachlor");

                entity.Property(e => e.MetazachlorEsa).HasColumnName("metazachlor_esa");

                entity.Property(e => e.MetazachlorOa).HasColumnName("metazachlor_oa");

                entity.Property(e => e.Metconazole).HasColumnName("metconazole");

                entity.Property(e => e.Methabenzthiazuron).HasColumnName("methabenzthiazuron");

                entity.Property(e => e.Methamidophos).HasColumnName("methamidophos");

                entity.Property(e => e.Methan).HasColumnName("methan");

                entity.Property(e => e.Methidathion).HasColumnName("methidathion");

                entity.Property(e => e.Methoprotryn).HasColumnName("methoprotryn");

                entity.Property(e => e.Methoxychlor).HasColumnName("methoxychlor");

                entity.Property(e => e.Methoxyfenozide).HasColumnName("methoxyfenozide");

                entity.Property(e => e.Metobromuron).HasColumnName("metobromuron");

                entity.Property(e => e.Metolachlor).HasColumnName("metolachlor");

                entity.Property(e => e.MetolachlorEsa).HasColumnName("metolachlor_esa");

                entity.Property(e => e.MetolachlorOa).HasColumnName("metolachlor_oa");

                entity.Property(e => e.Metoxuron).HasColumnName("metoxuron");

                entity.Property(e => e.Metribuzin).HasColumnName("metribuzin");

                entity.Property(e => e.MetribuzinDesamino).HasColumnName("metribuzin_desamino");

                entity.Property(e => e.MetribuzinDesaminoDiketo).HasColumnName("metribuzin_desamino_diketo");

                entity.Property(e => e.MetribuzinDiketo).HasColumnName("metribuzin_diketo");

                entity.Property(e => e.MetsulfuronMethyl).HasColumnName("metsulfuron_methyl");

                entity.Property(e => e.MineralizaceCelkem).HasColumnName("mineralizace_celkem");

                entity.Property(e => e.Mirex).HasColumnName("mirex");

                entity.Property(e => e.ModifD)
                    .HasColumnName("modif_d")
                    .HasColumnType("datetime");

                entity.Property(e => e.ModifU)
                    .HasColumnName("modif_u")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Molybden).HasColumnName("molybden");

                entity.Property(e => e.Monolinuron).HasColumnName("monolinuron");

                entity.Property(e => e.Mtbe).HasColumnName("mtbe");

                entity.Property(e => e.NCelkovy).HasColumnName("n_celkovy");

                entity.Property(e => e.NaFluorescein).HasColumnName("na_fluorescein");

                entity.Property(e => e.Naftalen).HasColumnName("naftalen");

                entity.Property(e => e.Napropamide).HasColumnName("napropamide");

                entity.Property(e => e.Nel).HasColumnName("nel");

                entity.Property(e => e.NewD)
                    .HasColumnName("new_d")
                    .HasColumnType("datetime");

                entity.Property(e => e.NewU)
                    .HasColumnName("new_u")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Nicosulfuron).HasColumnName("nicosulfuron");

                entity.Property(e => e.Nikl).HasColumnName("nikl");

                entity.Property(e => e.Nl105).HasColumnName("nl105");

                entity.Property(e => e.O2).HasColumnName("o2");

                entity.Property(e => e.OPDdd).HasColumnName("o_p_ddd");

                entity.Property(e => e.OPDde).HasColumnName("o_p_dde");

                entity.Property(e => e.OPDdt).HasColumnName("o_p_ddt");

                entity.Property(e => e.ObjemovaHmotnost).HasColumnName("objemova_hmotnost");

                entity.Property(e => e.Oktachlorstyren).HasColumnName("oktachlorstyren");

                entity.Property(e => e.Olovo).HasColumnName("olovo");

                entity.Property(e => e.OxidKremicity).HasColumnName("oxid_kremicity");

                entity.Property(e => e.OxyChlordan).HasColumnName("oxy_chlordan");

                entity.Property(e => e.PCelkovy).HasColumnName("p_celkovy");

                entity.Property(e => e.PIsopropylanilin).HasColumnName("p_isopropylanilin");

                entity.Property(e => e.PPDdd).HasColumnName("p_p_ddd");

                entity.Property(e => e.PPDde).HasColumnName("p_p_dde");

                entity.Property(e => e.PPDdt).HasColumnName("p_p_ddt");

                entity.Property(e => e.Pach).HasColumnName("pach");

                entity.Property(e => e.Pcb101).HasColumnName("pcb_101");

                entity.Property(e => e.Pcb118).HasColumnName("pcb_118");

                entity.Property(e => e.Pcb138).HasColumnName("pcb_138");

                entity.Property(e => e.Pcb153).HasColumnName("pcb_153");

                entity.Property(e => e.Pcb180).HasColumnName("pcb_180");

                entity.Property(e => e.Pcb28).HasColumnName("pcb_28");

                entity.Property(e => e.Pcb52).HasColumnName("pcb_52");

                entity.Property(e => e.Pce).HasColumnName("pce");

                entity.Property(e => e.Pendimethalin).HasColumnName("pendimethalin");

                entity.Property(e => e.Pentachlorbenzen).HasColumnName("pentachlorbenzen");

                entity.Property(e => e.Ph).HasColumnName("ph");

                entity.Property(e => e.Phorate).HasColumnName("phorate");

                entity.Property(e => e.Phosalone).HasColumnName("phosalone");

                entity.Property(e => e.Phosphamidon).HasColumnName("phosphamidon");

                entity.Property(e => e.Picloram).HasColumnName("picloram");

                entity.Property(e => e.Pid118).HasColumnName("pid118");

                entity.Property(e => e.Pirimicarb).HasColumnName("pirimicarb");

                entity.Property(e => e.Poznamka)
                    .HasColumnName("poznamka")
                    .HasMaxLength(5000)
                    .IsUnicode(false);

                entity.Property(e => e.Prochloraz).HasColumnName("prochloraz");

                entity.Property(e => e.Prometon).HasColumnName("prometon");

                entity.Property(e => e.Prometryn).HasColumnName("prometryn");

                entity.Property(e => e.Propachlor).HasColumnName("propachlor");

                entity.Property(e => e.PropachlorEsa).HasColumnName("propachlor_esa");

                entity.Property(e => e.PropachlorOa).HasColumnName("propachlor_oa");

                entity.Property(e => e.Propazin).HasColumnName("propazin");

                entity.Property(e => e.Propiconazole).HasColumnName("propiconazole");

                entity.Property(e => e.PropoxycarbazoneSodium).HasColumnName("propoxycarbazone_sodium");

                entity.Property(e => e.Propyzamide).HasColumnName("propyzamide");

                entity.Property(e => e.Pyridate).HasColumnName("pyridate");

                entity.Property(e => e.Pyrimethanil).HasColumnName("pyrimethanil");

                entity.Property(e => e.Ras).HasColumnName("ras");

                entity.Property(e => e.Reftime)
                    .HasColumnName("reftime")
                    .HasColumnType("datetime");

                entity.Property(e => e.Rimsulfuron).HasColumnName("rimsulfuron");

                entity.Property(e => e.Rozpustene).HasColumnName("rozpustene");

                entity.Property(e => e.Rtut).HasColumnName("rtut");

                entity.Property(e => e.Sebutylazin).HasColumnName("sebutylazin");

                entity.Property(e => e.Sediment).HasColumnName("sediment");

                entity.Property(e => e.Simazin).HasColumnName("simazin");

                entity.Property(e => e.Simazin2Hydroxy).HasColumnName("simazin_2_hydroxy");

                entity.Property(e => e.Simetryn).HasColumnName("simetryn");

                entity.Property(e => e.Sirany).HasColumnName("sirany");

                entity.Property(e => e.Siricitany).HasColumnName("siricitany");

                entity.Property(e => e.Sirouhlik).HasColumnName("sirouhlik");

                entity.Property(e => e.Sodik).HasColumnName("sodik");

                entity.Property(e => e.Spiroxamine).HasColumnName("spiroxamine");

                entity.Property(e => e.Styren).HasColumnName("styren");

                entity.Property(e => e.Sulfamethoxazol).HasColumnName("sulfamethoxazol");

                entity.Property(e => e.SulfanVolny).HasColumnName("sulfan_volny");

                entity.Property(e => e.Sulfidy).HasColumnName("sulfidy");

                entity.Property(e => e.Sulfosulfuron).HasColumnName("sulfosulfuron");

                entity.Property(e => e.SumaBtex).HasColumnName("suma_btex");

                entity.Property(e => e.SumaCb).HasColumnName("suma_cb");

                entity.Property(e => e.SumaCle).HasColumnName("suma_cle");

                entity.Property(e => e.SumaClm).HasColumnName("suma_clm");

                entity.Property(e => e.SumaClu).HasColumnName("suma_clu");

                entity.Property(e => e.SumaCluDleRozhodnuti).HasColumnName("suma_clu_dle_rozhodnuti");

                entity.Property(e => e.SumaDce).HasColumnName("suma_dce");

                entity.Property(e => e.SumaHch).HasColumnName("suma_hch");

                entity.Property(e => e.SumaHchBezEhch).HasColumnName("suma_hch_bez_ehch");

                entity.Property(e => e.TDce12).HasColumnName("t_dce_1_2");

                entity.Property(e => e.Tce).HasColumnName("tce");

                entity.Property(e => e.Tebuconazole).HasColumnName("tebuconazole");

                entity.Property(e => e.Teq).HasColumnName("teq");

                entity.Property(e => e.Terbutryn).HasColumnName("terbutryn");

                entity.Property(e => e.Terbutylazin).HasColumnName("terbutylazin");

                entity.Property(e => e.TerbutylazinDesethyl).HasColumnName("terbutylazin_desethyl");

                entity.Property(e => e.TerbutylazinDesethyl2Hydroxy).HasColumnName("terbutylazin_desethyl_2_hydroxy");

                entity.Property(e => e.TerbutylazinHydroxy).HasColumnName("terbutylazin_hydroxy");

                entity.Property(e => e.Tetrachlorbenzeny).HasColumnName("tetrachlorbenzeny");

                entity.Property(e => e.Tetrachlorethan1112).HasColumnName("tetrachlorethan_1_1_1_2");

                entity.Property(e => e.Tetrachlorethan1122).HasColumnName("tetrachlorethan_1_1_2_2");

                entity.Property(e => e.Tetrachlormethan).HasColumnName("tetrachlormethan");

                entity.Property(e => e.Tetrachlorobenzen1234).HasColumnName("tetrachlorobenzen_1_2_3_4");

                entity.Property(e => e.Tetrachlorobenzen1235Plus1245).HasColumnName("tetrachlorobenzen_1_2_3_5_plus_1_2_4_5");

                entity.Property(e => e.Thiamethoxam).HasColumnName("thiamethoxam");

                entity.Property(e => e.ThifensulfuronMethyl).HasColumnName("thifensulfuron_methyl");

                entity.Property(e => e.ThiophanateMethyl).HasColumnName("thiophanate_methyl");

                entity.Property(e => e.Tic).HasColumnName("tic");

                entity.Property(e => e.Tlak).HasColumnName("tlak");

                entity.Property(e => e.Toc).HasColumnName("toc");

                entity.Property(e => e.Toluen).HasColumnName("toluen");

                entity.Property(e => e.Tp).HasColumnName("tp");

                entity.Property(e => e.TransChlordan).HasColumnName("trans_chlordan");

                entity.Property(e => e.TransHeptachlorepoxid).HasColumnName("trans_heptachlorepoxid");

                entity.Property(e => e.Triadimefon).HasColumnName("triadimefon");

                entity.Property(e => e.Triadimenol).HasColumnName("triadimenol");

                entity.Property(e => e.Triallate).HasColumnName("triallate");

                entity.Property(e => e.Triasulfuron).HasColumnName("triasulfuron");

                entity.Property(e => e.TribenuronMethyl).HasColumnName("tribenuron_methyl");

                entity.Property(e => e.Trichlorbenzen123).HasColumnName("trichlorbenzen_1_2_3");

                entity.Property(e => e.Trichlorbenzen124).HasColumnName("trichlorbenzen_1_2_4");

                entity.Property(e => e.Trichlorbenzen135).HasColumnName("trichlorbenzen_1_3_5");

                entity.Property(e => e.Trichlorbenzeny).HasColumnName("trichlorbenzeny");

                entity.Property(e => e.Trichlorethan111).HasColumnName("trichlorethan_1_1_1");

                entity.Property(e => e.Trichlorethan112).HasColumnName("trichlorethan_1_1_2");

                entity.Property(e => e.Trichlormethan).HasColumnName("trichlormethan");

                entity.Property(e => e.Trichlorpropan123).HasColumnName("trichlorpropan_1_2_3");

                entity.Property(e => e.Trifluralin).HasColumnName("trifluralin");

                entity.Property(e => e.Triforine).HasColumnName("triforine");

                entity.Property(e => e.Triticonazole).HasColumnName("triticonazole");

                entity.Property(e => e.TvrdostCelkem).HasColumnName("tvrdost_celkem");

                entity.Property(e => e.Typ)
                    .IsRequired()
                    .HasColumnName("typ")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Uhlicitany).HasColumnName("uhlicitany");

                entity.Property(e => e.UhlovodikyC10C40).HasColumnName("uhlovodiky_c10_c40");

                entity.Property(e => e.Vanad).HasColumnName("vanad");

                entity.Property(e => e.Vapnik).HasColumnName("vapnik");

                entity.Property(e => e.Vc).HasColumnName("vc");

                entity.Property(e => e.VyssiFenoly).HasColumnName("vyssi_fenoly");

                entity.Property(e => e.Xyleny).HasColumnName("xyleny");

                entity.Property(e => e.Zelezo).HasColumnName("zelezo");

                entity.Property(e => e.Zinek).HasColumnName("zinek");

                entity.Property(e => e.Znk83).HasColumnName("znk_83");

                entity.Property(e => e._245TrichlorfenoxyoctovaKyselina).HasColumnName("_2_4_5_trichlorfenoxyoctova_kyselina");

                entity.Property(e => e._24DichlorfenoxyoctovaKyselina).HasColumnName("_2_4_dichlorfenoxyoctova_kyselina");

                entity.Property(e => e._24DpDichlorprop).HasColumnName("_2_4_dp_dichlorprop");

                entity.Property(e => e._26Dichlorobenzamide).HasColumnName("_2_6_dichlorobenzamide");

                entity.Property(e => e._2AminoNIsopropylBenzamide).HasColumnName("_2_amino_n_isopropyl_benzamide");

                entity.Property(e => e._2Chloro26Diethylacetanilide).HasColumnName("_2_chloro_2_6_diethylacetanilide");

                entity.Property(e => e._34Dichloranilin).HasColumnName("_3_4_dichloranilin");

                entity.Property(e => e._34DichlorophenylUreaDcpu).HasColumnName("_3_4_dichlorophenyl_urea_dcpu");

                entity.Property(e => e._3Chlor4Methylanilin).HasColumnName("_3_chlor_4_methylanilin");

                entity.Property(e => e._3Hydroxycarbofuran).HasColumnName("_3_hydroxycarbofuran");
            });

            modelBuilder.Entity<JednotkyVeliciny>(entity =>
            {
                entity.HasKey(e => e.JednotkaVelicinaId);

                entity.ToTable("jednotky_veliciny");

                entity.Property(e => e.JednotkaVelicinaId)
                    .HasColumnName("jednotka_velicina_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.DeleteD)
                    .HasColumnName("delete_d")
                    .HasColumnType("datetime");

                entity.Property(e => e.DeleteU)
                    .HasColumnName("delete_u")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Eh).HasColumnName("eh");

                entity.Property(e => e.Ehd).HasColumnName("ehd");

                entity.Property(e => e.Konduktivita).HasColumnName("konduktivita");

                entity.Property(e => e.ModifD)
                    .HasColumnName("modif_d")
                    .HasColumnType("datetime");

                entity.Property(e => e.ModifU)
                    .HasColumnName("modif_u")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.NewD)
                    .HasColumnName("new_d")
                    .HasColumnType("datetime");

                entity.Property(e => e.NewU)
                    .HasColumnName("new_u")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.O2).HasColumnName("o2");

                entity.Property(e => e.Poznamka)
                    .HasColumnName("poznamka")
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.Reftime)
                    .HasColumnName("reftime")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<Klienti>(entity =>
            {
                entity.HasKey(e => e.Pcname);

                entity.ToTable("klienti");

                entity.Property(e => e.Pcname)
                    .HasColumnName("pcname")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Identityprefix)
                    .IsRequired()
                    .HasColumnName("identityprefix")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.Identityvalue)
                    .HasColumnName("identityvalue")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.ModifD)
                    .HasColumnName("modif_d")
                    .HasColumnType("datetime");

                entity.Property(e => e.ModifU)
                    .HasColumnName("modif_u")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.PosledniSpojeni)
                    .HasColumnName("posledni_spojeni")
                    .HasColumnType("datetime");

                entity.Property(e => e.Poznamka)
                    .HasColumnName("poznamka")
                    .HasMaxLength(1000)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Kriteria>(entity =>
            {
                entity.HasKey(e => e.KriteriumId);

                entity.ToTable("kriteria");

                entity.Property(e => e.KriteriumId)
                    .HasColumnName("kriterium_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.DeleteD)
                    .HasColumnName("delete_d")
                    .HasColumnType("datetime");

                entity.Property(e => e.DeleteU)
                    .HasColumnName("delete_u")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.H12).HasColumnName("h1_2");

                entity.Property(e => e.H23).HasColumnName("h2_3");

                entity.Property(e => e.H34).HasColumnName("h3_4");

                entity.Property(e => e.H45).HasColumnName("h4_5");

                entity.Property(e => e.ModifD)
                    .HasColumnName("modif_d")
                    .HasColumnType("datetime");

                entity.Property(e => e.ModifU)
                    .HasColumnName("modif_u")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.NewD)
                    .HasColumnName("new_d")
                    .HasColumnType("datetime");

                entity.Property(e => e.NewU)
                    .HasColumnName("new_u")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ObjektId).HasColumnName("objekt_id");

                entity.Property(e => e.Reftime)
                    .HasColumnName("reftime")
                    .HasColumnType("datetime");

                entity.Property(e => e.VelicinaId).HasColumnName("velicina_id");

                entity.Property(e => e.VzorekTyp)
                    .HasColumnName("vzorek_typ")
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Litkody>(entity =>
            {
                entity.HasKey(e => e.LitkodId);

                entity.ToTable("litkody");

                entity.Property(e => e.LitkodId)
                    .HasColumnName("litkod_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.DeleteD)
                    .HasColumnName("delete_d")
                    .HasColumnType("datetime");

                entity.Property(e => e.DeleteU)
                    .HasColumnName("delete_u")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Litkod)
                    .HasColumnName("litkod")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ModifD)
                    .HasColumnName("modif_d")
                    .HasColumnType("datetime");

                entity.Property(e => e.ModifU)
                    .HasColumnName("modif_u")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.NewD)
                    .HasColumnName("new_d")
                    .HasColumnType("datetime");

                entity.Property(e => e.NewU)
                    .HasColumnName("new_u")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Popis)
                    .HasColumnName("popis")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Reftime)
                    .HasColumnName("reftime")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<Litologie>(entity =>
            {
                entity.ToTable("litologie");

                entity.Property(e => e.LitologieId)
                    .HasColumnName("litologie_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.BaseH).HasColumnName("base_h");

                entity.Property(e => e.DeleteD)
                    .HasColumnName("delete_d")
                    .HasColumnType("datetime");

                entity.Property(e => e.DeleteU)
                    .HasColumnName("delete_u")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Gtext)
                    .HasColumnName("gtext")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.LitkodId).HasColumnName("litkod_id");

                entity.Property(e => e.ModifD)
                    .HasColumnName("modif_d")
                    .HasColumnType("datetime");

                entity.Property(e => e.ModifU)
                    .HasColumnName("modif_u")
                    .HasMaxLength(20)
                    .IsFixedLength();

                entity.Property(e => e.NewD)
                    .HasColumnName("new_d")
                    .HasColumnType("datetime");

                entity.Property(e => e.NewU)
                    .HasColumnName("new_u")
                    .HasMaxLength(20)
                    .IsFixedLength();

                entity.Property(e => e.ObjektId).HasColumnName("objekt_id");

                entity.Property(e => e.Reftime)
                    .HasColumnName("reftime")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.Litkod)
                    .WithMany(p => p.Litologie)
                    .HasForeignKey(d => d.LitkodId)
                    .HasConstraintName("FK_litologie_litkody");

                entity.HasOne(d => d.Objekt)
                    .WithMany(p => p.Litologie)
                    .HasForeignKey(d => d.ObjektId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_litologie_objekty");
            });

            modelBuilder.Entity<Meteodata>(entity =>
            {
                entity.ToTable("meteodata");

                entity.Property(e => e.MeteodataId)
                    .HasColumnName("meteodata_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.DeleteD)
                    .HasColumnName("delete_d")
                    .HasColumnType("datetime");

                entity.Property(e => e.DeleteU)
                    .HasColumnName("delete_u")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Mereno)
                    .HasColumnName("mereno")
                    .HasColumnType("datetime");

                entity.Property(e => e.ModifD)
                    .HasColumnName("modif_d")
                    .HasColumnType("datetime");

                entity.Property(e => e.ModifU)
                    .HasColumnName("modif_u")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.NapetiAkumulatoru).HasColumnName("napeti_akumulatoru");

                entity.Property(e => e.NewD)
                    .HasColumnName("new_d")
                    .HasColumnType("datetime");

                entity.Property(e => e.NewU)
                    .HasColumnName("new_u")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ObjektId).HasColumnName("objekt_id");

                entity.Property(e => e.Poznamka)
                    .HasColumnName("poznamka")
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.PrizemniTeplota).HasColumnName("prizemni_teplota");

                entity.Property(e => e.Realizace)
                    .HasColumnName("realizace")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Reftime)
                    .HasColumnName("reftime")
                    .HasColumnType("datetime");

                entity.Property(e => e.RychlostVetru).HasColumnName("rychlost_vetru");

                entity.Property(e => e.Srazky).HasColumnName("srazky");

                entity.Property(e => e.TeplotaPudy).HasColumnName("teplota_pudy");

                entity.Property(e => e.TeplotaVzduchu).HasColumnName("teplota_vzduchu");

                entity.Property(e => e.VlhkostPudy).HasColumnName("vlhkost_pudy");

                entity.Property(e => e.VlhkostVzduchu).HasColumnName("vlhkost_vzduchu");

                entity.HasOne(d => d.Objekt)
                    .WithMany(p => p.Meteodata)
                    .HasForeignKey(d => d.ObjektId)
                    .HasConstraintName("FK_meteodata_objekty");
            });

            modelBuilder.Entity<Mraky>(entity =>
            {
                entity.HasKey(e => e.MrakId);

                entity.ToTable("mraky");

                entity.Property(e => e.MrakId)
                    .HasColumnName("mrak_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.DeleteD)
                    .HasColumnName("delete_d")
                    .HasColumnType("datetime");

                entity.Property(e => e.DeleteU)
                    .HasColumnName("delete_u")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ModifD)
                    .HasColumnName("modif_d")
                    .HasColumnType("datetime");

                entity.Property(e => e.ModifU)
                    .HasColumnName("modif_u")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Mrak)
                    .HasColumnName("mrak")
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.NewD)
                    .HasColumnName("new_d")
                    .HasColumnType("datetime");

                entity.Property(e => e.NewU)
                    .HasColumnName("new_u")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Popis)
                    .HasColumnName("popis")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Poznamka)
                    .HasColumnName("poznamka")
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.Reftime)
                    .HasColumnName("reftime")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<Objekty>(entity =>
            {
                entity.HasKey(e => e.ObjektId);

                entity.ToTable("objekty");

                entity.Property(e => e.ObjektId)
                    .HasColumnName("objekt_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Alternativni)
                    .HasColumnName("alternativni")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.DatumZjisteni)
                    .HasColumnName("datum_zjisteni")
                    .HasColumnType("datetime");

                entity.Property(e => e.DeleteD)
                    .HasColumnName("delete_d")
                    .HasColumnType("datetime");

                entity.Property(e => e.DeleteU)
                    .HasColumnName("delete_u")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.EGps).HasColumnName("e_gps");

                entity.Property(e => e.Geolog)
                    .HasColumnName("geolog")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Hloubka).HasColumnName("hloubka");

                entity.Property(e => e.Material1)
                    .HasColumnName("material_1")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Material2)
                    .HasColumnName("material_2")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Material3)
                    .HasColumnName("material_3")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Material4)
                    .HasColumnName("material_4")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Material5)
                    .HasColumnName("material_5")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Material6)
                    .HasColumnName("material_6")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Material7)
                    .HasColumnName("material_7")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Material8)
                    .HasColumnName("material_8")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.ModifD)
                    .HasColumnName("modif_d")
                    .HasColumnType("datetime");

                entity.Property(e => e.ModifU)
                    .HasColumnName("modif_u")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.MrakId).HasColumnName("mrak_id");

                entity.Property(e => e.NGps).HasColumnName("n_gps");

                entity.Property(e => e.NarazenaHladina1).HasColumnName("narazena_hladina_1");

                entity.Property(e => e.NarazenaHladina2).HasColumnName("narazena_hladina_2");

                entity.Property(e => e.NewD)
                    .HasColumnName("new_d")
                    .HasColumnType("datetime");

                entity.Property(e => e.NewU)
                    .HasColumnName("new_u")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ObOdPaznice).HasColumnName("ob_od_paznice");

                entity.Property(e => e.ObPopis)
                    .HasColumnName("ob_popis")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Objekt)
                    .HasColumnName("objekt")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PazeniDo1).HasColumnName("pazeni_do_1");

                entity.Property(e => e.PazeniDo2).HasColumnName("pazeni_do_2");

                entity.Property(e => e.PazeniDo3).HasColumnName("pazeni_do_3");

                entity.Property(e => e.PazeniOd1).HasColumnName("pazeni_od_1");

                entity.Property(e => e.PazeniOd2).HasColumnName("pazeni_od_2");

                entity.Property(e => e.PazeniOd3).HasColumnName("pazeni_od_3");

                entity.Property(e => e.PazeniPoznamka1)
                    .HasColumnName("pazeni_poznamka_1")
                    .IsUnicode(false);

                entity.Property(e => e.PazeniPoznamka2)
                    .HasColumnName("pazeni_poznamka_2")
                    .IsUnicode(false);

                entity.Property(e => e.PazeniPoznamka3)
                    .HasColumnName("pazeni_poznamka_3")
                    .IsUnicode(false);

                entity.Property(e => e.PazeniPrumer1).HasColumnName("pazeni_prumer_1");

                entity.Property(e => e.PazeniPrumer2).HasColumnName("pazeni_prumer_2");

                entity.Property(e => e.PazeniPrumer3).HasColumnName("pazeni_prumer_3");

                entity.Property(e => e.PerforaceDo1).HasColumnName("perforace_do_1");

                entity.Property(e => e.PerforaceDo2).HasColumnName("perforace_do_2");

                entity.Property(e => e.PerforaceDo3).HasColumnName("perforace_do_3");

                entity.Property(e => e.PerforaceOd1).HasColumnName("perforace_od_1");

                entity.Property(e => e.PerforaceOd2).HasColumnName("perforace_od_2");

                entity.Property(e => e.PerforaceOd3).HasColumnName("perforace_od_3");

                entity.Property(e => e.Poznamka)
                    .HasColumnName("poznamka")
                    .IsUnicode(false);

                entity.Property(e => e.PrumerVnejsi1).HasColumnName("prumer_vnejsi_1");

                entity.Property(e => e.PrumerVnejsi2).HasColumnName("prumer_vnejsi_2");

                entity.Property(e => e.PrumerVnejsi3).HasColumnName("prumer_vnejsi_3");

                entity.Property(e => e.PrumerVnejsi4).HasColumnName("prumer_vnejsi_4");

                entity.Property(e => e.PrumerVnejsi5).HasColumnName("prumer_vnejsi_5");

                entity.Property(e => e.PrumerVnejsi6).HasColumnName("prumer_vnejsi_6");

                entity.Property(e => e.PrumerVnejsi7).HasColumnName("prumer_vnejsi_7");

                entity.Property(e => e.PrumerVnejsi8).HasColumnName("prumer_vnejsi_8");

                entity.Property(e => e.PrumerVnitrni1).HasColumnName("prumer_vnitrni_1");

                entity.Property(e => e.PrumerVnitrni2).HasColumnName("prumer_vnitrni_2");

                entity.Property(e => e.PrumerVnitrni3).HasColumnName("prumer_vnitrni_3");

                entity.Property(e => e.PrumerVnitrni4).HasColumnName("prumer_vnitrni_4");

                entity.Property(e => e.PrumerVnitrni5).HasColumnName("prumer_vnitrni_5");

                entity.Property(e => e.PrumerVnitrni6).HasColumnName("prumer_vnitrni_6");

                entity.Property(e => e.PrumerVnitrni7).HasColumnName("prumer_vnitrni_7");

                entity.Property(e => e.PrumerVnitrni8).HasColumnName("prumer_vnitrni_8");

                entity.Property(e => e.Reference)
                    .HasColumnName("reference")
                    .IsUnicode(false);

                entity.Property(e => e.Reftime)
                    .HasColumnName("reftime")
                    .HasColumnType("datetime");

                entity.Property(e => e.SekmId)
                    .HasColumnName("sekm_id")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Souprava)
                    .HasColumnName("souprava")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Technologie)
                    .HasColumnName("technologie")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Typ)
                    .HasColumnName("typ")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Uroven).HasColumnName("uroven");

                entity.Property(e => e.UrovenZduvodneni)
                    .HasColumnName("uroven_zduvodneni")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.UstalenaHladina).HasColumnName("ustalena_hladina");

                entity.Property(e => e.VrtaniBaze1).HasColumnName("vrtani_baze_1");

                entity.Property(e => e.VrtaniBaze2).HasColumnName("vrtani_baze_2");

                entity.Property(e => e.VrtaniBaze3).HasColumnName("vrtani_baze_3");

                entity.Property(e => e.VrtaniBaze4).HasColumnName("vrtani_baze_4");

                entity.Property(e => e.VrtaniDo)
                    .HasColumnName("vrtani_do")
                    .HasColumnType("datetime");

                entity.Property(e => e.VrtaniOd)
                    .HasColumnName("vrtani_od")
                    .HasColumnType("datetime");

                entity.Property(e => e.VrtaniPoznamka1)
                    .HasColumnName("vrtani_poznamka_1")
                    .IsUnicode(false);

                entity.Property(e => e.VrtaniPoznamka2)
                    .HasColumnName("vrtani_poznamka_2")
                    .IsUnicode(false);

                entity.Property(e => e.VrtaniPoznamka3)
                    .HasColumnName("vrtani_poznamka_3")
                    .IsUnicode(false);

                entity.Property(e => e.VrtaniPoznamka4)
                    .HasColumnName("vrtani_poznamka_4")
                    .IsUnicode(false);

                entity.Property(e => e.VrtaniPrumer1).HasColumnName("vrtani_prumer_1");

                entity.Property(e => e.VrtaniPrumer2).HasColumnName("vrtani_prumer_2");

                entity.Property(e => e.VrtaniPrumer3).HasColumnName("vrtani_prumer_3");

                entity.Property(e => e.VrtaniPrumer4).HasColumnName("vrtani_prumer_4");

                entity.Property(e => e.Vrtmistr)
                    .HasColumnName("vrtmistr")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.VyplDo1).HasColumnName("vypl_do_1");

                entity.Property(e => e.VyplOd1).HasColumnName("vypl_od_1");

                entity.Property(e => e.VyplOd2).HasColumnName("vypl_od_2");

                entity.Property(e => e.VyplOd6).HasColumnName("vypl_od_6");

                entity.Property(e => e.VyplnDo2).HasColumnName("vypln_do_2");

                entity.Property(e => e.VyplnDo3).HasColumnName("vypln_do_3");

                entity.Property(e => e.VyplnDo4).HasColumnName("vypln_do_4");

                entity.Property(e => e.VyplnDo5).HasColumnName("vypln_do_5");

                entity.Property(e => e.VyplnDo8).HasColumnName("vypln_do_8");

                entity.Property(e => e.VyplnOd3).HasColumnName("vypln_od_3");

                entity.Property(e => e.VyplnOd4).HasColumnName("vypln_od_4");

                entity.Property(e => e.VyplnOd5).HasColumnName("vypln_od_5");

                entity.Property(e => e.VyplnOd8).HasColumnName("vypln_od_8");

                entity.Property(e => e.VypnDo6).HasColumnName("vypn_do_6");

                entity.Property(e => e.VypnDo7).HasColumnName("vypn_do_7");

                entity.Property(e => e.VypnOd7).HasColumnName("vypn_od_7");

                entity.Property(e => e.X).HasColumnName("x");

                entity.Property(e => e.Y).HasColumnName("y");

                entity.Property(e => e.Z).HasColumnName("z");

                entity.Property(e => e.ZGps).HasColumnName("z_gps");

                entity.Property(e => e.ZOb).HasColumnName("z_ob");

                entity.HasOne(d => d.Mrak)
                    .WithMany(p => p.Objekty)
                    .HasForeignKey(d => d.MrakId)
                    .HasConstraintName("FK_objekty_mraky");
            });

            modelBuilder.Entity<Parametry>(entity =>
            {
                entity.HasKey(e => e.Pname);

                entity.ToTable("parametry");

                entity.Property(e => e.Pname)
                    .HasColumnName("pname")
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.C)
                    .HasColumnName("c")
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.Pdescription)
                    .IsRequired()
                    .HasColumnName("pdescription")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Pvalue)
                    .IsRequired()
                    .HasColumnName("pvalue")
                    .HasMaxLength(250)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Pesticidy>(entity =>
            {
                entity.ToTable("pesticidy");

                entity.Property(e => e.PesticidyId)
                    .HasColumnName("pesticidy_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Acetochlor).HasColumnName("acetochlor");

                entity.Property(e => e.AcetochlorEsa).HasColumnName("acetochlor_esa");

                entity.Property(e => e.AcetochlorOa).HasColumnName("acetochlor_oa");

                entity.Property(e => e.Alachlor).HasColumnName("alachlor");

                entity.Property(e => e.AlachlorEsa).HasColumnName("alachlor_esa");

                entity.Property(e => e.AlachlorOa).HasColumnName("alachlor_oa");

                entity.Property(e => e.Aldrin).HasColumnName("aldrin");

                entity.Property(e => e.AlfaEndosulfan).HasColumnName("alfa_endosulfan");

                entity.Property(e => e.AlfaHch).HasColumnName("alfa_hch");

                entity.Property(e => e.Ametryn).HasColumnName("ametryn");

                entity.Property(e => e.Aminopyralid).HasColumnName("aminopyralid");

                entity.Property(e => e.Ampa).HasColumnName("ampa");

                entity.Property(e => e.Atraton).HasColumnName("atraton");

                entity.Property(e => e.Atrazin).HasColumnName("atrazin");

                entity.Property(e => e.AtrazinDesethyl).HasColumnName("atrazin_desethyl");

                entity.Property(e => e.AtrazinDesethylDesisopropyl).HasColumnName("atrazin_desethyl_desisopropyl");

                entity.Property(e => e.AtrazinDesisopropyl).HasColumnName("atrazin_desisopropyl");

                entity.Property(e => e.AtrazinHydroxy).HasColumnName("atrazin_hydroxy");

                entity.Property(e => e.Azoxystrobin).HasColumnName("azoxystrobin");

                entity.Property(e => e.Bentazone).HasColumnName("bentazone");

                entity.Property(e => e.BentazoneMethyl).HasColumnName("bentazone_methyl");

                entity.Property(e => e.BetaEndosulfan).HasColumnName("beta_endosulfan");

                entity.Property(e => e.BetaHch).HasColumnName("beta_hch");

                entity.Property(e => e.Bromacil).HasColumnName("bromacil");

                entity.Property(e => e.Bromoxynil).HasColumnName("bromoxynil");

                entity.Property(e => e.Caffeine).HasColumnName("caffeine");

                entity.Property(e => e.Carbamazepin).HasColumnName("carbamazepin");

                entity.Property(e => e.Carbendazim).HasColumnName("carbendazim");

                entity.Property(e => e.Carbofuran).HasColumnName("carbofuran");

                entity.Property(e => e.Chlorantraniliprol).HasColumnName("chlorantraniliprol");

                entity.Property(e => e.Chlorbromuron).HasColumnName("chlorbromuron");

                entity.Property(e => e.Chlorfenvinphos).HasColumnName("chlorfenvinphos");

                entity.Property(e => e.Chloridazon).HasColumnName("chloridazon");

                entity.Property(e => e.ChloridazonDesphenyl).HasColumnName("chloridazon_desphenyl");

                entity.Property(e => e.ChloridazonMethylDesphenyl).HasColumnName("chloridazon_methyl_desphenyl");

                entity.Property(e => e.Chlorotoluron).HasColumnName("chlorotoluron");

                entity.Property(e => e.ChlorotoluronDesmethyl).HasColumnName("chlorotoluron_desmethyl");

                entity.Property(e => e.Chlorpyrifos).HasColumnName("chlorpyrifos");

                entity.Property(e => e.Chlorsulfuron).HasColumnName("chlorsulfuron");

                entity.Property(e => e.CisChlordan).HasColumnName("cis_chlordan");

                entity.Property(e => e.CisHeptachlorepoxid).HasColumnName("cis_heptachlorepoxid");

                entity.Property(e => e.Clomazone).HasColumnName("clomazone");

                entity.Property(e => e.Clopyralid).HasColumnName("clopyralid");

                entity.Property(e => e.Cyanazine).HasColumnName("cyanazine");

                entity.Property(e => e.Cyproconazole).HasColumnName("cyproconazole");

                entity.Property(e => e.DeleteD)
                    .HasColumnName("delete_d")
                    .HasColumnType("datetime");

                entity.Property(e => e.DeleteU)
                    .HasColumnName("delete_u")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.DeltaHch).HasColumnName("delta_hch");

                entity.Property(e => e.Desmedipham).HasColumnName("desmedipham");

                entity.Property(e => e.Desmetryn).HasColumnName("desmetryn");

                entity.Property(e => e.Diazinon).HasColumnName("diazinon");

                entity.Property(e => e.Dicamba).HasColumnName("dicamba");

                entity.Property(e => e.Dichlobenil).HasColumnName("dichlobenil");

                entity.Property(e => e.Dichlormid).HasColumnName("dichlormid");

                entity.Property(e => e.Dieldrin).HasColumnName("dieldrin");

                entity.Property(e => e.Diethyltoluamid).HasColumnName("diethyltoluamid");

                entity.Property(e => e.Dimethachlor).HasColumnName("dimethachlor");

                entity.Property(e => e.Dimethenamide).HasColumnName("dimethenamide");

                entity.Property(e => e.Dimethipin).HasColumnName("dimethipin");

                entity.Property(e => e.Dimethoat).HasColumnName("dimethoat");

                entity.Property(e => e.Dimethomorph).HasColumnName("dimethomorph");

                entity.Property(e => e.Diuron).HasColumnName("diuron");

                entity.Property(e => e.DiuronDesmethylDcpmu).HasColumnName("diuron_desmethyl_dcpmu");

                entity.Property(e => e.EndosulfanSulfat).HasColumnName("endosulfan_sulfat");

                entity.Property(e => e.Endrin).HasColumnName("endrin");

                entity.Property(e => e.Epoxiconazole).HasColumnName("epoxiconazole");

                entity.Property(e => e.EpsilonHch).HasColumnName("epsilon_hch");

                entity.Property(e => e.Ethofumesate).HasColumnName("ethofumesate");

                entity.Property(e => e.Fenarimol).HasColumnName("fenarimol");

                entity.Property(e => e.Fenhexamid).HasColumnName("fenhexamid");

                entity.Property(e => e.Fenpropidin).HasColumnName("fenpropidin");

                entity.Property(e => e.Fenpropimorph).HasColumnName("fenpropimorph");

                entity.Property(e => e.Florasulam).HasColumnName("florasulam");

                entity.Property(e => e.FluazifopP).HasColumnName("fluazifop_p");

                entity.Property(e => e.FluazifopPButyl).HasColumnName("fluazifop_p_butyl");

                entity.Property(e => e.Fluroxypyr).HasColumnName("fluroxypyr");

                entity.Property(e => e.Flusilazole).HasColumnName("flusilazole");

                entity.Property(e => e.Foramsulfuron).HasColumnName("foramsulfuron");

                entity.Property(e => e.GamaHch).HasColumnName("gama_hch");

                entity.Property(e => e.Glyphosate).HasColumnName("glyphosate");

                entity.Property(e => e.Heptachlor).HasColumnName("heptachlor");

                entity.Property(e => e.Hexazinon).HasColumnName("hexazinon");

                entity.Property(e => e.HloubkaOdberu).HasColumnName("hloubka_odberu");

                entity.Property(e => e.ImazamethabenzMethyl).HasColumnName("imazamethabenz_methyl");

                entity.Property(e => e.Imazamox).HasColumnName("imazamox");

                entity.Property(e => e.Imazethapyr).HasColumnName("imazethapyr");

                entity.Property(e => e.Imidacloprid).HasColumnName("imidacloprid");

                entity.Property(e => e.Iprodion).HasColumnName("iprodion");

                entity.Property(e => e.Isodrin).HasColumnName("isodrin");

                entity.Property(e => e.Isoproturon).HasColumnName("isoproturon");

                entity.Property(e => e.IsoproturonDesmethyl).HasColumnName("isoproturon_desmethyl");

                entity.Property(e => e.IsoproturonMonodesmethyl).HasColumnName("isoproturon_monodesmethyl");

                entity.Property(e => e.KresoximMethyl).HasColumnName("kresoxim_methyl");

                entity.Property(e => e.Lenacil).HasColumnName("lenacil");

                entity.Property(e => e.Linuron).HasColumnName("linuron");

                entity.Property(e => e.Mcpa).HasColumnName("mcpa");

                entity.Property(e => e.Mcpb).HasColumnName("mcpb");

                entity.Property(e => e.McppMecoprop).HasColumnName("mcpp_mecoprop");

                entity.Property(e => e.Metalaxyl).HasColumnName("metalaxyl");

                entity.Property(e => e.Metamitron).HasColumnName("metamitron");

                entity.Property(e => e.Metazachlor).HasColumnName("metazachlor");

                entity.Property(e => e.MetazachlorEsa).HasColumnName("metazachlor_esa");

                entity.Property(e => e.MetazachlorOa).HasColumnName("metazachlor_oa");

                entity.Property(e => e.Metconazole).HasColumnName("metconazole");

                entity.Property(e => e.Methabenzthiazuron).HasColumnName("methabenzthiazuron");

                entity.Property(e => e.Methamidophos).HasColumnName("methamidophos");

                entity.Property(e => e.Methidathion).HasColumnName("methidathion");

                entity.Property(e => e.Methoprotryn).HasColumnName("methoprotryn");

                entity.Property(e => e.Methoxychlor).HasColumnName("methoxychlor");

                entity.Property(e => e.Methoxyfenozide).HasColumnName("methoxyfenozide");

                entity.Property(e => e.Metobromuron).HasColumnName("metobromuron");

                entity.Property(e => e.Metolachlor).HasColumnName("metolachlor");

                entity.Property(e => e.MetolachlorEsa).HasColumnName("metolachlor_esa");

                entity.Property(e => e.MetolachlorOa).HasColumnName("metolachlor_oa");

                entity.Property(e => e.Metoxuron).HasColumnName("metoxuron");

                entity.Property(e => e.Metribuzin).HasColumnName("metribuzin");

                entity.Property(e => e.MetribuzinDesamino).HasColumnName("metribuzin_desamino");

                entity.Property(e => e.MetribuzinDesaminoDiketo).HasColumnName("metribuzin_desamino_diketo");

                entity.Property(e => e.MetribuzinDiketo).HasColumnName("metribuzin_diketo");

                entity.Property(e => e.MetsulfuronMethyl).HasColumnName("metsulfuron_methyl");

                entity.Property(e => e.Mirex).HasColumnName("mirex");

                entity.Property(e => e.ModifD)
                    .HasColumnName("modif_d")
                    .HasColumnType("datetime");

                entity.Property(e => e.ModifU)
                    .HasColumnName("modif_u")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Monolinuron).HasColumnName("monolinuron");

                entity.Property(e => e.Napropamide).HasColumnName("napropamide");

                entity.Property(e => e.NewD)
                    .HasColumnName("new_d")
                    .HasColumnType("datetime");

                entity.Property(e => e.NewU)
                    .HasColumnName("new_u")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Nicosulfuron).HasColumnName("nicosulfuron");

                entity.Property(e => e.OPDdd).HasColumnName("o_p_ddd");

                entity.Property(e => e.OPDde).HasColumnName("o_p_dde");

                entity.Property(e => e.OPDdt).HasColumnName("o_p_ddt");

                entity.Property(e => e.ObjektId).HasColumnName("objekt_id");

                entity.Property(e => e.Odber)
                    .HasColumnName("odber")
                    .HasColumnType("datetime");

                entity.Property(e => e.Oktachlorstyren).HasColumnName("oktachlorstyren");

                entity.Property(e => e.OxyChlordan).HasColumnName("oxy_chlordan");

                entity.Property(e => e.PIsopropylanilin).HasColumnName("p_isopropylanilin");

                entity.Property(e => e.PPDdd).HasColumnName("p_p_ddd");

                entity.Property(e => e.PPDde).HasColumnName("p_p_dde");

                entity.Property(e => e.PPDdt).HasColumnName("p_p_ddt");

                entity.Property(e => e.Pcb101).HasColumnName("pcb_101");

                entity.Property(e => e.Pcb118).HasColumnName("pcb_118");

                entity.Property(e => e.Pcb138).HasColumnName("pcb_138");

                entity.Property(e => e.Pcb153).HasColumnName("pcb_153");

                entity.Property(e => e.Pcb180).HasColumnName("pcb_180");

                entity.Property(e => e.Pcb28).HasColumnName("pcb_28");

                entity.Property(e => e.Pcb52).HasColumnName("pcb_52");

                entity.Property(e => e.Pendimethalin).HasColumnName("pendimethalin");

                entity.Property(e => e.Phorate).HasColumnName("phorate");

                entity.Property(e => e.Phosalone).HasColumnName("phosalone");

                entity.Property(e => e.Phosphamidon).HasColumnName("phosphamidon");

                entity.Property(e => e.Picloram).HasColumnName("picloram");

                entity.Property(e => e.Pirimicarb).HasColumnName("pirimicarb");

                entity.Property(e => e.Poznamka)
                    .HasColumnName("poznamka")
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.Prochloraz).HasColumnName("prochloraz");

                entity.Property(e => e.Prometon).HasColumnName("prometon");

                entity.Property(e => e.Prometryn).HasColumnName("prometryn");

                entity.Property(e => e.Propachlor).HasColumnName("propachlor");

                entity.Property(e => e.PropachlorEsa).HasColumnName("propachlor_esa");

                entity.Property(e => e.PropachlorOa).HasColumnName("propachlor_oa");

                entity.Property(e => e.Propazin).HasColumnName("propazin");

                entity.Property(e => e.Propiconazole).HasColumnName("propiconazole");

                entity.Property(e => e.PropoxycarbazoneSodium).HasColumnName("propoxycarbazone_sodium");

                entity.Property(e => e.Propyzamide).HasColumnName("propyzamide");

                entity.Property(e => e.Protokol)
                    .HasColumnName("protokol")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Pyridate).HasColumnName("pyridate");

                entity.Property(e => e.Pyrimethanil).HasColumnName("pyrimethanil");

                entity.Property(e => e.Realizace)
                    .HasColumnName("realizace")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Reftime)
                    .HasColumnName("reftime")
                    .HasColumnType("datetime");

                entity.Property(e => e.Rimsulfuron).HasColumnName("rimsulfuron");

                entity.Property(e => e.Sebutylazin).HasColumnName("sebutylazin");

                entity.Property(e => e.Simazin).HasColumnName("simazin");

                entity.Property(e => e.Simazin2Hydroxy).HasColumnName("simazin_2_hydroxy");

                entity.Property(e => e.Simetryn).HasColumnName("simetryn");

                entity.Property(e => e.Spiroxamine).HasColumnName("spiroxamine");

                entity.Property(e => e.Sulfamethoxazol).HasColumnName("sulfamethoxazol");

                entity.Property(e => e.Sulfosulfuron).HasColumnName("sulfosulfuron");

                entity.Property(e => e.Tebuconazole).HasColumnName("tebuconazole");

                entity.Property(e => e.Terbutryn).HasColumnName("terbutryn");

                entity.Property(e => e.Terbutylazin).HasColumnName("terbutylazin");

                entity.Property(e => e.TerbutylazinDesethyl).HasColumnName("terbutylazin_desethyl");

                entity.Property(e => e.TerbutylazinDesethyl2Hydroxy).HasColumnName("terbutylazin_desethyl_2_hydroxy");

                entity.Property(e => e.TerbutylazinHydroxy).HasColumnName("terbutylazin_hydroxy");

                entity.Property(e => e.Thiamethoxam).HasColumnName("thiamethoxam");

                entity.Property(e => e.ThifensulfuronMethyl).HasColumnName("thifensulfuron_methyl");

                entity.Property(e => e.ThiophanateMethyl).HasColumnName("thiophanate_methyl");

                entity.Property(e => e.TransChlordan).HasColumnName("trans_chlordan");

                entity.Property(e => e.TransHeptachlorepoxid).HasColumnName("trans_heptachlorepoxid");

                entity.Property(e => e.Triadimefon).HasColumnName("triadimefon");

                entity.Property(e => e.Triadimenol).HasColumnName("triadimenol");

                entity.Property(e => e.Triallate).HasColumnName("triallate");

                entity.Property(e => e.Triasulfuron).HasColumnName("triasulfuron");

                entity.Property(e => e.TribenuronMethyl).HasColumnName("tribenuron_methyl");

                entity.Property(e => e.Trifluralin).HasColumnName("trifluralin");

                entity.Property(e => e.Triforine).HasColumnName("triforine");

                entity.Property(e => e.Triticonazole).HasColumnName("triticonazole");

                entity.Property(e => e.TypOdberu)
                    .HasColumnName("typ_odberu")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Vzorek)
                    .HasColumnName("vzorek")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.VzorekTyp)
                    .HasColumnName("vzorek_typ")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e._245TrichlorfenoxyoctovaKyselina).HasColumnName("_2_4_5_trichlorfenoxyoctova_kyselina");

                entity.Property(e => e._24DichlorfenoxyoctovaKyselina).HasColumnName("_2_4_dichlorfenoxyoctova_kyselina");

                entity.Property(e => e._24DpDichlorprop).HasColumnName("_2_4_dp_dichlorprop");

                entity.Property(e => e._26Dichlorobenzamide).HasColumnName("_2_6_dichlorobenzamide");

                entity.Property(e => e._2AminoNIsopropylBenzamide).HasColumnName("_2_amino_n_isopropyl_benzamide");

                entity.Property(e => e._2Chloro26Diethylacetanilide).HasColumnName("_2_chloro_2_6_diethylacetanilide");

                entity.Property(e => e._34Dichloranilin).HasColumnName("_3_4_dichloranilin");

                entity.Property(e => e._34DichlorophenylUreaDcpu).HasColumnName("_3_4_dichlorophenyl_urea_dcpu");

                entity.Property(e => e._3Chlor4Methylanilin).HasColumnName("_3_chlor_4_methylanilin");

                entity.Property(e => e._3Hydroxycarbofuran).HasColumnName("_3_hydroxycarbofuran");
            });

            modelBuilder.Entity<Plovaky>(entity =>
            {
                entity.HasKey(e => e.PlovakId);

                entity.ToTable("plovaky");

                entity.Property(e => e.PlovakId)
                    .HasColumnName("plovak_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.DeleteD)
                    .HasColumnName("delete_d")
                    .HasColumnType("datetime");

                entity.Property(e => e.DeleteU)
                    .HasColumnName("delete_u")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Mereno)
                    .HasColumnName("mereno")
                    .HasColumnType("datetime");

                entity.Property(e => e.ModifD)
                    .HasColumnName("modif_d")
                    .HasColumnType("datetime");

                entity.Property(e => e.ModifU)
                    .HasColumnName("modif_u")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.NapetiAku).HasColumnName("napeti_aku");

                entity.Property(e => e.NapetiPanel).HasColumnName("napeti_panel");

                entity.Property(e => e.NewD)
                    .HasColumnName("new_d")
                    .HasColumnType("datetime");

                entity.Property(e => e.NewU)
                    .HasColumnName("new_u")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ObjektId).HasColumnName("objekt_id");

                entity.Property(e => e.Poznamka)
                    .HasColumnName("poznamka")
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.Reftime)
                    .HasColumnName("reftime")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.Objekt)
                    .WithMany(p => p.Plovaky)
                    .HasForeignKey(d => d.ObjektId)
                    .HasConstraintName("FK_plovaky_objekty");
            });

            modelBuilder.Entity<Prilohy>(entity =>
            {
                entity.HasKey(e => e.PrilohaId);

                entity.ToTable("prilohy");

                entity.Property(e => e.PrilohaId)
                    .HasColumnName("priloha_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.DeleteD)
                    .HasColumnName("delete_d")
                    .HasColumnType("datetime");

                entity.Property(e => e.DeleteU)
                    .HasColumnName("delete_u")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Druh)
                    .HasColumnName("druh")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ModifD)
                    .HasColumnName("modif_d")
                    .HasColumnType("datetime");

                entity.Property(e => e.ModifU)
                    .HasColumnName("modif_u")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.NewD)
                    .HasColumnName("new_d")
                    .HasColumnType("datetime");

                entity.Property(e => e.NewU)
                    .HasColumnName("new_u")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ObjektId).HasColumnName("objekt_id");

                entity.Property(e => e.Popis)
                    .HasColumnName("popis")
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.Priloha)
                    .HasColumnName("priloha")
                    .HasColumnType("image");

                entity.Property(e => e.Reftime)
                    .HasColumnName("reftime")
                    .HasColumnType("datetime");

                entity.Property(e => e.Typ)
                    .HasColumnName("typ")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Vychozi)
                    .HasColumnName("vychozi")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.HasOne(d => d.Objekt)
                    .WithMany(p => p.Prilohy)
                    .HasForeignKey(d => d.ObjektId)
                    .HasConstraintName("FK_prilohy_objekty");
            });

            modelBuilder.Entity<Redox>(entity =>
            {
                entity.ToTable("redox");

                entity.Property(e => e.RedoxId)
                    .HasColumnName("redox_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Barva)
                    .HasColumnName("barva")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.DeleteD)
                    .HasColumnName("delete_d")
                    .HasColumnType("datetime");

                entity.Property(e => e.DeleteU)
                    .HasColumnName("delete_u")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Eh).HasColumnName("eh");

                entity.Property(e => e.HloubkaOdberu).HasColumnName("hloubka_odberu");

                entity.Property(e => e.Konduktivita).HasColumnName("konduktivita");

                entity.Property(e => e.MerenoNeboDOdberu)
                    .HasColumnName("mereno_nebo_d_odberu")
                    .HasColumnType("datetime");

                entity.Property(e => e.ModifD)
                    .HasColumnName("modif_d")
                    .HasColumnType("datetime");

                entity.Property(e => e.ModifU)
                    .HasColumnName("modif_u")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.NewD)
                    .HasColumnName("new_d")
                    .HasColumnType("datetime");

                entity.Property(e => e.NewU)
                    .HasColumnName("new_u")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.O2).HasColumnName("o2");

                entity.Property(e => e.ObjektId).HasColumnName("objekt_id");

                entity.Property(e => e.Pach)
                    .HasColumnName("pach")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Ph).HasColumnName("ph");

                entity.Property(e => e.Poznamka)
                    .HasColumnName("poznamka")
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.Realizace)
                    .HasColumnName("realizace")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Reftime)
                    .HasColumnName("reftime")
                    .HasColumnType("datetime");

                entity.Property(e => e.Teplota).HasColumnName("teplota");

                entity.Property(e => e.TypOdberu)
                    .HasColumnName("typ_odberu")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Objekt)
                    .WithMany(p => p.Redox)
                    .HasForeignKey(d => d.ObjektId)
                    .HasConstraintName("FK_redox_objekty");
            });

            modelBuilder.Entity<Reporty>(entity =>
            {
                entity.HasKey(e => e.ReportId);

                entity.ToTable("reporty");

                entity.Property(e => e.ReportId)
                    .HasColumnName("report_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.DeleteD)
                    .HasColumnName("delete_d")
                    .HasColumnType("datetime");

                entity.Property(e => e.DeleteU)
                    .HasColumnName("delete_u")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ModifD)
                    .HasColumnName("modif_d")
                    .HasColumnType("datetime");

                entity.Property(e => e.ModifU)
                    .HasColumnName("modif_u")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.NewD)
                    .HasColumnName("new_d")
                    .HasColumnType("datetime");

                entity.Property(e => e.NewU)
                    .HasColumnName("new_u")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Reftime)
                    .HasColumnName("reftime")
                    .HasColumnType("datetime");

                entity.Property(e => e.Report)
                    .HasColumnName("report")
                    .HasColumnType("text");

                entity.Property(e => e.Soubor)
                    .HasColumnName("soubor")
                    .IsUnicode(false);

                entity.Property(e => e.Typ)
                    .HasColumnName("typ")
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("role");

                entity.Property(e => e.RoleId)
                    .HasColumnName("role_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.DeleteD)
                    .HasColumnName("delete_d")
                    .HasColumnType("datetime");

                entity.Property(e => e.DeleteU)
                    .HasColumnName("delete_u")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ModifD)
                    .HasColumnName("modif_d")
                    .HasColumnType("datetime");

                entity.Property(e => e.ModifU)
                    .HasColumnName("modif_u")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.NewD)
                    .HasColumnName("new_d")
                    .HasColumnType("datetime");

                entity.Property(e => e.NewU)
                    .HasColumnName("new_u")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Prava)
                    .HasColumnName("prava")
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.Reftime)
                    .HasColumnName("reftime")
                    .HasColumnType("datetime");

                entity.Property(e => e.Role1)
                    .HasColumnName("role")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<RoleUzivatele>(entity =>
            {
                entity.ToTable("role_uzivatele");

                entity.Property(e => e.RoleUzivateleId)
                    .HasColumnName("role_uzivatele_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.DeleteD)
                    .HasColumnName("delete_d")
                    .HasColumnType("datetime");

                entity.Property(e => e.DeleteU)
                    .HasColumnName("delete_u")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ModifD)
                    .HasColumnName("modif_d")
                    .HasColumnType("datetime");

                entity.Property(e => e.ModifU)
                    .HasColumnName("modif_u")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.NewD)
                    .HasColumnName("new_d")
                    .HasColumnType("datetime");

                entity.Property(e => e.NewU)
                    .HasColumnName("new_u")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Reftime)
                    .HasColumnName("reftime")
                    .HasColumnType("datetime");

                entity.Property(e => e.RoleId).HasColumnName("role_id");

                entity.Property(e => e.UzivatelId).HasColumnName("uzivatel_id");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.RoleUzivatele)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK_role_uzivatele_role");

                entity.HasOne(d => d.Uzivatel)
                    .WithMany(p => p.RoleUzivatele)
                    .HasForeignKey(d => d.UzivatelId)
                    .HasConstraintName("FK_role_uzivatele_uzivatele");
            });

            modelBuilder.Entity<Uchr>(entity =>
            {
                entity.ToTable("uchr");

                entity.Property(e => e.UchrId)
                    .HasColumnName("uchr_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.AlfaAktivita).HasColumnName("alfa_aktivita");

                entity.Property(e => e.AmonneIonty).HasColumnName("amonne_ionty");

                entity.Property(e => e.Arsen).HasColumnName("arsen");

                entity.Property(e => e.Barva)
                    .HasColumnName("barva")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Baryum).HasColumnName("baryum");

                entity.Property(e => e.Berylium).HasColumnName("berylium");

                entity.Property(e => e.BetaAktivita).HasColumnName("beta_aktivita");

                entity.Property(e => e.Bromidy).HasColumnName("bromidy");

                entity.Property(e => e.Brru).HasColumnName("brru");

                entity.Property(e => e.Bsk5).HasColumnName("bsk_5");

                entity.Property(e => e.ChemickyTypVody)
                    .HasColumnName("chemicky_typ_vody")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Chloridy).HasColumnName("chloridy");

                entity.Property(e => e.Chrom).HasColumnName("chrom");

                entity.Property(e => e.ChskCr).HasColumnName("chsk_cr");

                entity.Property(e => e.ChskMn).HasColumnName("chsk_mn");

                entity.Property(e => e.Co2AgresivniVypocet).HasColumnName("co2_agresivni_vypocet");

                entity.Property(e => e.Co2VolnyVypocet).HasColumnName("co2_volny_vypocet");

                entity.Property(e => e.DeleteD)
                    .HasColumnName("delete_d")
                    .HasColumnType("datetime");

                entity.Property(e => e.DeleteU)
                    .HasColumnName("delete_u")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Doc).HasColumnName("doc");

                entity.Property(e => e.Draslik).HasColumnName("draslik");

                entity.Property(e => e.Dusicnany).HasColumnName("dusicnany");

                entity.Property(e => e.Dusitany).HasColumnName("dusitany");

                entity.Property(e => e.Fe0).HasColumnName("fe0");

                entity.Property(e => e.Fe2).HasColumnName("fe2");

                entity.Property(e => e.Fluoridy).HasColumnName("fluoridy");

                entity.Property(e => e.Fosforecnany).HasColumnName("fosforecnany");

                entity.Property(e => e.H2o2).HasColumnName("h2o2");

                entity.Property(e => e.Hlinik).HasColumnName("hlinik");

                entity.Property(e => e.HloubkaOdberu).HasColumnName("hloubka_odberu");

                entity.Property(e => e.Horcik).HasColumnName("horcik");

                entity.Property(e => e.Hydrogenuhlicitany).HasColumnName("hydrogenuhlicitany");

                entity.Property(e => e.Kadmium).HasColumnName("kadmium");

                entity.Property(e => e.Kmno4).HasColumnName("kmno4");

                entity.Property(e => e.Knk45).HasColumnName("knk_45");

                entity.Property(e => e.Kobalt).HasColumnName("kobalt");

                entity.Property(e => e.KolonieAerobni).HasColumnName("kolonie_aerobni");

                entity.Property(e => e.KolonieAnaerobni).HasColumnName("kolonie_anaerobni");

                entity.Property(e => e.Konduktivita).HasColumnName("konduktivita");

                entity.Property(e => e.KyanidyCelkove).HasColumnName("kyanidy_celkove");

                entity.Property(e => e.KyanidyVolne).HasColumnName("kyanidy_volne");

                entity.Property(e => e.LatkyVeskere).HasColumnName("latky_veskere");

                entity.Property(e => e.Lithium).HasColumnName("lithium");

                entity.Property(e => e.Mangan).HasColumnName("mangan");

                entity.Property(e => e.Med).HasColumnName("med");

                entity.Property(e => e.MineralizaceCelkem).HasColumnName("mineralizace_celkem");

                entity.Property(e => e.ModifD)
                    .HasColumnName("modif_d")
                    .HasColumnType("datetime");

                entity.Property(e => e.ModifU)
                    .HasColumnName("modif_u")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Molybden).HasColumnName("molybden");

                entity.Property(e => e.NCelkovy).HasColumnName("n_celkovy");

                entity.Property(e => e.NewD)
                    .HasColumnName("new_d")
                    .HasColumnType("datetime");

                entity.Property(e => e.NewU)
                    .HasColumnName("new_u")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Nikl).HasColumnName("nikl");

                entity.Property(e => e.Nl105).HasColumnName("nl105");

                entity.Property(e => e.ObjektId).HasColumnName("objekt_id");

                entity.Property(e => e.ObjemovaHmotnost).HasColumnName("objemova_hmotnost");

                entity.Property(e => e.Odber)
                    .HasColumnName("odber")
                    .HasColumnType("datetime");

                entity.Property(e => e.Olovo).HasColumnName("olovo");

                entity.Property(e => e.OxidKremicity).HasColumnName("oxid_kremicity");

                entity.Property(e => e.PCelkovy).HasColumnName("p_celkovy");

                entity.Property(e => e.Pach)
                    .HasColumnName("pach")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Ph).HasColumnName("ph");

                entity.Property(e => e.Poznamka)
                    .HasColumnName("poznamka")
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.Protokol)
                    .HasColumnName("protokol")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Ras).HasColumnName("ras");

                entity.Property(e => e.Realizace)
                    .HasColumnName("realizace")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Reftime)
                    .HasColumnName("reftime")
                    .HasColumnType("datetime");

                entity.Property(e => e.Rozpustene).HasColumnName("rozpustene");

                entity.Property(e => e.Rtut).HasColumnName("rtut");

                entity.Property(e => e.Sediment)
                    .HasColumnName("sediment")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Sirany).HasColumnName("sirany");

                entity.Property(e => e.Siricitany).HasColumnName("siricitany");

                entity.Property(e => e.Sirouhlik).HasColumnName("sirouhlik");

                entity.Property(e => e.Sodik).HasColumnName("sodik");

                entity.Property(e => e.SulfanVolny).HasColumnName("sulfan_volny");

                entity.Property(e => e.Sulfidy).HasColumnName("sulfidy");

                entity.Property(e => e.Tic).HasColumnName("tic");

                entity.Property(e => e.Toc).HasColumnName("toc");

                entity.Property(e => e.TvrdostCelkem).HasColumnName("tvrdost_celkem");

                entity.Property(e => e.TypOdberu)
                    .HasColumnName("typ_odberu")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Uhlicitany).HasColumnName("uhlicitany");

                entity.Property(e => e.Vanad).HasColumnName("vanad");

                entity.Property(e => e.Vapnik).HasColumnName("vapnik");

                entity.Property(e => e.Vzorek)
                    .HasColumnName("vzorek")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.VzorekTyp)
                    .HasColumnName("vzorek_typ")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Zelezo).HasColumnName("zelezo");

                entity.Property(e => e.Zinek).HasColumnName("zinek");

                entity.Property(e => e.Znk83).HasColumnName("znk_83");

                entity.HasOne(d => d.Objekt)
                    .WithMany(p => p.Uchr)
                    .HasForeignKey(d => d.ObjektId)
                    .HasConstraintName("FK_uchr_objekty");
            });

            modelBuilder.Entity<Urovne>(entity =>
            {
                entity.HasKey(e => e.UrovenId);

                entity.ToTable("urovne");

                entity.Property(e => e.UrovenId)
                    .HasColumnName("uroven_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Barva)
                    .HasColumnName("barva")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.DeleteD)
                    .HasColumnName("delete_d")
                    .HasColumnType("datetime");

                entity.Property(e => e.DeleteU)
                    .HasColumnName("delete_u")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ModifD)
                    .HasColumnName("modif_d")
                    .HasColumnType("datetime");

                entity.Property(e => e.ModifU)
                    .HasColumnName("modif_u")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Nazev)
                    .HasColumnName("nazev")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NewD)
                    .HasColumnName("new_d")
                    .HasColumnType("datetime");

                entity.Property(e => e.NewU)
                    .HasColumnName("new_u")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Popis)
                    .HasColumnName("popis")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Reftime)
                    .HasColumnName("reftime")
                    .HasColumnType("datetime");

                entity.Property(e => e.Uroven).HasColumnName("uroven");
            });

            modelBuilder.Entity<Uzivatele>(entity =>
            {
                entity.HasKey(e => e.UzivatelId);

                entity.ToTable("uzivatele");

                entity.Property(e => e.UzivatelId)
                    .HasColumnName("uzivatel_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.DatumKlikuOk)
                    .HasColumnName("datum_kliku_ok")
                    .HasColumnType("datetime");

                entity.Property(e => e.DeleteD)
                    .HasColumnName("delete_d")
                    .HasColumnType("datetime");

                entity.Property(e => e.DeleteU)
                    .HasColumnName("delete_u")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Heslo)
                    .HasColumnName("heslo")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Jmeno)
                    .HasColumnName("jmeno")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ModifD)
                    .HasColumnName("modif_d")
                    .HasColumnType("datetime");

                entity.Property(e => e.ModifU)
                    .HasColumnName("modif_u")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.NewD)
                    .HasColumnName("new_d")
                    .HasColumnType("datetime");

                entity.Property(e => e.NewU)
                    .HasColumnName("new_u")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Popis)
                    .HasColumnName("popis")
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.PosledniSynchronizace)
                    .HasColumnName("posledni_synchronizace")
                    .HasColumnType("datetime");

                entity.Property(e => e.Prijmeni)
                    .HasColumnName("prijmeni")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Reftime)
                    .HasColumnName("reftime")
                    .HasColumnType("datetime");

                entity.Property(e => e.StavUpozorneni)
                    .HasColumnName("stav_upozorneni")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Telefon)
                    .HasColumnName("telefon")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Upozorneni)
                    .HasColumnName("upozorneni")
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.Uzivatel)
                    .HasColumnName("uzivatel")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });
        }
    }
}
