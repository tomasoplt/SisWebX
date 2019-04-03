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
    public class MrakService : ApplicationService, IMrakService
    {
        private SISContext _context;
        private ISessionHelper _sessionHelper;

        public MrakService(AppDbContext context, ISessionHelper sessionHelper)
        {
            _context = context as SISContext;
            _sessionHelper = sessionHelper;
        }

        public void SetConnectionString()
        {
            _context.SetConnectionString(_sessionHelper.GetLocalityConnectionString());
        }

        public List<MrakModelDto> GetMraky()
        {
            List<MrakModelDto> list = _context.Mraky.AsNoTracking().OrderBy(x => x.Mrak).Select(b =>
                new MrakModelDto()
                {
                    mrak_id = b.MrakId,
                    mrak = b.Mrak,
                    Poznamka = b.Poznamka,
                }).ToList();

            return list;
        }
    }
}
