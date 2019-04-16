using SisWeb.Services.Dto.Authentication;
using SisWeb.Services.Dto.Sis;
using SisWeb.Services.Dto.System;
using System;
using System.Collections.Generic;

namespace SisWeb.Services.Session
{
    public interface IUserSession
    {
        string BackUrl { get; set; }
        string AppUrl { get; set; }
        string Language { get; set; }
        string BaseUri { get; set; }
        int LocalityId { get; set; }
        int Counter { get; set; }
        DateTime LastDate { get; set; }

        AuthResultDto AuthInformation { get; set; }
        NavigateModelDto NavigateModel { get; set; }
        List<LocalityModelDto> Localities { get; set; }
        string GetLocalityConnectionString();
        void SetLocality(int localityId);
        void Clear();
        void MarkAsUsed();
    }
}
