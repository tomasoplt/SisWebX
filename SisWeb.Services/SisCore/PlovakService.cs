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

        public void SetConnectionString(int localityId)
        {
            UserSession userSession = _sessionHelper.GetSession();
            _context.SetConnectionString(userSession.GetLocalityConnectionString(localityId));
        }

        public void Save(PlovakModelDto obj)
        {
            using (var ctx = new SISContext(_context.ConnectionString))
            {
                var dbObj = ctx.Plovaky.SingleOrDefault(x => x.PlovakId == obj.PlovakId);

                dbObj.NapetiAku = obj.NapetiAku;
                dbObj.NapetiPanel = obj.NapetiPanel;

                dbObj.NewD = obj.new_d;
                dbObj.NewU = obj.new_u;

                dbObj.ModifD = obj.modif_d;
                dbObj.ModifU = obj.modif_u;

                dbObj.DeleteU = obj.delete_u;
                dbObj.DeleteD = obj.delete_d;

                dbObj.Reftime = dbObj.ModifD;

                ctx.SaveChanges();
            }
        }

        public PlovakModelDto GetSingle(int plovak_id)
        {
            using (var ctx = new SISContext(_context.ConnectionString))
            {
                var obj = ctx.Plovaky.Where(x => x.PlovakId == plovak_id)
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
        }

        public List<PlovakModelDto> GetPlovaky(int objekt_id)
        {
            using (var ctx = new SISContext(_context.ConnectionString))
            {
                List<PlovakModelDto> plovaky = ctx.Plovaky.AsNoTracking()
                .Where(x => x.ObjektId == objekt_id && x.DeleteD == null)
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
        }

        public void GetGraphData(int objekt_id)
        {
            

        }

    }
}
