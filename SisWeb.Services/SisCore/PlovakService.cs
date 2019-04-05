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
    public class PlovakService : ApplicationService, IPlovakService
    {
        private SISContext _context;
        private ISessionHelper _sessionHelper;

        public PlovakService(AppDbContext context, ISessionHelper sessionHelper)
        {
            _sessionHelper = sessionHelper;
            _context = context as SISContext;
        }

        public void SetConnectionString()
        {
            _context.SetConnectionString(_sessionHelper.GetLocalityConnectionString());
        }

        public void Save(PlovakModelDto obj)
        {
            try
            {
                var dbObj = _context.Plovaky.SingleOrDefault(x => x.PlovakId == obj.PlovakId);

                dbObj.NapetiAku = obj.NapetiAku;
                dbObj.NapetiPanel = obj.NapetiPanel;

                //dbObj.Mereno = obj.Mereno;
                //dbObj.Poznamka = obj.Poznamka;

                dbObj.NewD = obj.new_d;
                dbObj.NewU = obj.new_u;

                dbObj.ModifD = obj.modif_d;
                dbObj.ModifU = obj.modif_u;

                dbObj.DeleteU = obj.delete_u;
                dbObj.DeleteD = obj.delete_d;

                dbObj.Reftime = dbObj.ModifD;
                

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
                    Poznamka = b.Poznamka,
                    new_d = b.NewD,
                    new_u = b.NewU,
                    modif_d = b.ModifD,
                    modif_u = b.ModifU,
                    delete_d = b.DeleteD,
                    delete_u = b.DeleteU
                }).SingleOrDefault();

            return obj;
        }

        public List<PlovakModelDto> GetPlovaky(int objekt_id)
        {
            List<PlovakModelDto>  plovaky = _context.Plovaky.AsNoTracking()
                .Where(x => x.DeleteD == null)
                .OrderByDescending(x => x.Mereno).Select(b =>
                new PlovakModelDto()
                {
                    PlovakId = b.PlovakId,
                    objekt_id = b.ObjektId,
                    NapetiAku = b.NapetiAku,
                    NapetiPanel = b.NapetiPanel,
                    Mereno = b.Mereno,
                    Poznamka = b.Poznamka,
                    new_d = b.NewD,
                    new_u = b.NewU,
                    modif_d = b.ModifD,
                    modif_u = b.ModifU,
                    delete_d = b.DeleteD,
                    delete_u = b.DeleteU
                }).ToList();

            return plovaky;
        }

        public void GetGraphData(int objekt_id)
        {
            

        }

    }
}
