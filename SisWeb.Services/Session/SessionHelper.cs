using SisWeb.Services.Dto.Authentication;
using SisWeb.Services.Dto.Sis;
using SisWeb.Services.Dto.System;
using System.Collections.Generic;
using System.Linq;

namespace SisWeb.Services.Session
{
    public class SessionHelper : ISessionHelper
    {
        public SessionHelper()
        {
            Clear();
        }

        public string Language { get; set; }
        public string AppUrl { get; set; }
        public string BackUrl { get; set; }
        public string BaseUri { get; set; }
        public AuthResultDto AuthInformation { get; set; }
        public List<LocalityModelDto> Localities { get; set; }
        public NavigateModelDto NavigateModel { get; set; }
        public int LocalityId { get; set; }

        public void SetLocality(int localityId)
        {
            LocalityId = localityId;
        }

        public string GetLocalityConnectionString()
        {
            return Localities.SingleOrDefault(x => x.LocalityId == LocalityId).GetConnectionString();
        }

        public void Clear()
        {
            AuthInformation = new AuthResultDto();
            NavigateModel = new NavigateModelDto();
            Localities = new List<LocalityModelDto>();
        }
    }
}
