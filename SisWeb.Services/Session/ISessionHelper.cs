using SisWeb.Services.Dto.Authentication;
using SisWeb.Services.Dto.Sis;
using System.Collections.Generic;

namespace SisWeb.Services.Session
{
    public interface ISessionHelper
    {
        string AppUrl { get; set; }
        string Language { get; set; }
        string BaseUri { get; set; }
        AuthResultDto AuthInformation { get; set; }
        List<LocalityModelDto> Localities { get; set; }
    }
}