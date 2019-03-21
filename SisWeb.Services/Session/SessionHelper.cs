using SisWeb.Services.Dto.Authentication;
using SisWeb.Services.Dto.Sis;
using System.Collections.Generic;

namespace SisWeb.Services.Session
{
    public class SessionHelper : ISessionHelper
    {
        public SessionHelper()
        {
            AuthInformation = new AuthResultDto();
        }

        public string Language { get; set; }
        public string AppUrl { get; set; }
        public string BaseUri { get; set; }
        public AuthResultDto AuthInformation { get; set; }
        public List<LocalityModelDto> Localities { get; set; }
    }
}
