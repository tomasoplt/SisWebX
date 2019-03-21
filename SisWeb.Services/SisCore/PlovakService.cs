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
    public class PlovakService : ApplicationService, IPlovakService
    {
        private SISContext _context;

        public PlovakService(AppDbContext context)
        {
            _context = context as SISContext;
        }

        public void Save(PlovakModelDto obj)
        {
            try
            {
                var dbObj = _context.Plovaky.SingleOrDefault(x => x.ObjektId == obj.objekt_id);
                dbObj.NapetiAku = obj.NapetiAku;
                dbObj.NapetiPanel = obj.NapetiPanel;
                dbObj.Mereno = obj.Mereno;
                dbObj.Poznamka = obj.Poznamka;
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public PlovakModelDto GetSingle(int plovak_id)
        {
            var obj = _context.Plovaky.Where(x => x.PlovakId == plovak_id)
            .Select(b =>
                new PlovakModelDto()
                {
                    PlovakId = b.PlovakId,
                    objekt_id = b.ObjektId,
                    NapetiAku = b.NapetiAku,
                    NapetiPanel = b.NapetiPanel,
                    Mereno = b.Mereno,
                    Poznamka = b.Poznamka
                }).SingleOrDefault();

            return obj;
        }

        public List<PlovakModelDto> GetPlovaky(int objekt_id)
        {
            Func<AppDbContext> f = () => _context;
            SISContext context = GetContext(f) as SISContext;

            List<PlovakModelDto>  plovaky = context.Plovaky.AsNoTracking().OrderBy(x => x.Mereno).Select(b =>
                new PlovakModelDto()
                {
                    PlovakId = b.PlovakId,
                    objekt_id = b.ObjektId,
                    NapetiAku = b.NapetiAku,
                    NapetiPanel = b.NapetiPanel,
                    Mereno = b.Mereno,
                    Poznamka = b.Poznamka
                }).ToList();

            return plovaky;
        }
    }
}
