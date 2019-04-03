using Core.EF.EntityFrameworkCore;
using Core.Services.Application;
using Microsoft.EntityFrameworkCore;
using SisWeb.EF.Models;
using SisWeb.Services.Dto.Sis;
using SisWeb.Services.Session;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SisWeb.Services.SisCore
{
    public class ObjectService : ApplicationService, IObjectService
    {
        private SISContext _context;
        private ISessionHelper _sessionHelper;

        public ObjectService(AppDbContext context, ISessionHelper sessionHelper)
        {
            _sessionHelper = sessionHelper;
            _context = context as SISContext;
        }

        public void SetConnectionString()
        {
            _context.SetConnectionString(_sessionHelper.GetLocalityConnectionString());
        }

        public void SaveObject(ObjectModelDto obj)
        {
            try
            {
                Objekty dbObj;
                if (obj.objekt_id == null)
                    dbObj = new Objekty();
                else
                    dbObj = _context.Objekty.SingleOrDefault(x => x.ObjektId == obj.objekt_id);

                dbObj.Objekt = obj.objekt;
                dbObj.MrakId = obj.MrakId;
                dbObj.Typ = obj.typ;
                dbObj.Alternativni = obj.alternativni;
                dbObj.X = obj.x;
                dbObj.Y = obj.y;
                dbObj.Z = obj.z;
                dbObj.EGps = obj.e_gps;
                dbObj.NGps = obj.n_gps;
                dbObj.ZGps = obj.z_gps;
                dbObj.Technologie = obj.technologie;
                dbObj.Reference = obj.reference;
                dbObj.Poznamka = obj.poznamka;

                dbObj.ModifD = DateTime.Now;
                dbObj.Reftime = dbObj.ModifD;
                dbObj.NewU = obj.new_u;
                dbObj.ModifU = obj.modif_u;

                if (obj.objekt_id == null)
                {
                    _context.Objekty.Add(dbObj);
                }

                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }


        public ObjectModelDto GetObject(int objekt_id)
        {
            var obj = _context.Objekty.Where(x => x.ObjektId == objekt_id)
            .Select(b =>
                new ObjectModelDto()
                {
                    objekt_id = b.ObjektId,
                    objekt = b.Objekt,
                    oblast = b.Mrak.Mrak,
                    MrakId = b.MrakId,
                    typ = b.Typ,
                    alternativni = b.Alternativni,
                    x = b.X,
                    y = b.Y,
                    z = b.Z,
                    e_gps = b.EGps,
                    n_gps = b.NGps,
                    z_gps = b.ZGps,
                    technologie = b.Technologie,
                    reference = b.Reference,
                    poznamka = b.Poznamka
                }).SingleOrDefault();

            return obj;
             
        }

        private IEnumerable<ObjectModelDto> GetObjectsInternal()
        {
            return _context.Objekty.AsNoTracking().Include(x => x.Mrak).OrderBy(x => x.Objekt).Select(b =>
            new ObjectModelDto()
            {
                objekt_id = b.ObjektId,
                objekt = b.Objekt,
                oblast = b.Mrak.Mrak,
                MrakId = b.MrakId,
                typ = b.Typ,
                alternativni = b.Alternativni,
                x = b.X,
                y = b.Y,
                z = b.Z,
                e_gps = b.EGps,
                n_gps = b.NGps,
                z_gps = b.ZGps,
                technologie = b.Technologie,
                reference = b.Reference,
                poznamka = b.Poznamka
            });
        }

        public List<ObjectModelDto> GetObjects(string nazev)
        {
            List<ObjectModelDto> objects = GetObjectsInternal().Where(x=>x.objekt.StartsWith(nazev)).ToList();
            return objects;
        }

        public List<ObjectModelDto> GetObjects(bool includePlovak)
        {
            List<ObjectModelDto> objects = GetObjectsInternal().ToList();

            var plovaky = _context.Plovaky.AsNoTracking().OrderBy(x => x.ObjektId).ThenBy(x => x.Mereno).Select(b =>
                    new PlovakModelDto()
                    {
                        PlovakId = b.PlovakId,
                        objekt_id = b.ObjektId,
                        Mereno = b.Mereno,
                        NapetiPanel = b.NapetiPanel,
                        NapetiAku = b.NapetiAku
                    }).ToList();

            if (includePlovak)
            {
                ObjectModelDto lastObject = null;
                foreach (PlovakModelDto plovak in plovaky)
                {
                    if (lastObject != null && lastObject.objekt_id == plovak.objekt_id)
                    {
                        lastObject.Plovaky.Add(plovak);
                    }
                    else
                    {
                        lastObject = objects.SingleOrDefault(x => x.objekt_id == plovak.objekt_id);
                        if (lastObject != null)
                            lastObject.Plovaky.Add(plovak);
                    }
                }
            }

            return objects;
        }
    }
}
