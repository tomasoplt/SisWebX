using Core.EF.EntityFrameworkCore;
using Core.Services.Application;
using Microsoft.EntityFrameworkCore;
using SisWeb.EF.Models;
using SisWeb.Services.Dto.Sis;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SisWeb.Services.SisCore
{
    public class ObjectService : ApplicationService, IObjectService
    {
        private SISContext _context;

        public ObjectService(AppDbContext context)
        {
            _context = context as SISContext;
        }

        public void SaveObject(ObjectModelDto obj)
        {
            try
            {
                var dbObj = _context.Objekty.SingleOrDefault(x => x.ObjektId == obj.objekt_id);
                dbObj.Objekt = obj.objekt;
                dbObj.Typ = obj.typ;
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
                    typ = b.Typ,
                    alternativni = b.Alternativni,
                    x = b.X,
                    y = b.Y
                }).SingleOrDefault();

            return obj;
             
        }


        public List<ObjectModelDto> GetObjects()
        {
            Func<AppDbContext> f = () => _context;
            SISContext context = GetContext(f) as SISContext;

            List<ObjectModelDto>  objects = context.Objekty.AsNoTracking().Include(x => x.Mrak).OrderBy(x => x.Objekt).Select(b =>
            new ObjectModelDto()
                {
                    objekt_id = b.ObjektId,
                    objekt = b.Objekt,
                    oblast = b.Mrak.Mrak,
                    typ = b.Typ,
                    alternativni = b.Alternativni,
                    x = b.X,
                    y = b.Y
                }).ToList();

            var plovaky = context.Plovaky.AsNoTracking().OrderBy(x => x.ObjektId).ThenBy(x => x.Mereno).Select(b =>
                    new PlovakModelDto()
                    {
                        PlovakId = b.PlovakId,
                        objekt_id = b.ObjektId,
                        Mereno = b.Mereno,
                        NapetiPanel = b.NapetiPanel,
                        NapetiAku = b.NapetiAku
                    }).ToList();

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

            return objects;
        }
    }
}
