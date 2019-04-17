using SisWeb.Services.Dto.Authentication;
using SisWeb.Services.Dto.Sis;
using SisWeb.Services.Dto.System;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SisWeb.Services.Session
{
    public class UserSession : IUserSession
    {
        public UserSession(string guid)
        {
            Guid = guid;
            AuthInformation = new AuthResultDto();
            NavigateModel = new NavigateModelDto();
            Counter = 0;
            MarkAsUsed();
            LastError = null;
        }

        public string Guid { get; set; }
        public string Language { get; set; }
        public string AppUrl { get; set; }
        public string BackUrl { get; set; }
        public string ForwardUrl { get; set; }
        public string BaseUri { get; set; }
        public AuthResultDto AuthInformation { get; set; }
        public List<LocalityModelDto> Localities { get; set; }
        public NavigateModelDto NavigateModel { get; set; }
        public int LocalityId { get; set; }
        public int Counter { get; set; }
        public DateTime LastDate { get; set; }
        public Exception LastError { get; set; }

        public void SetLocality(int localityId)
        {
            LocalityId = localityId;
        }

        public string GetLocalityConnectionString(int localityId)
        {
            return Localities.SingleOrDefault(x => x.LocalityId == localityId).GetConnectionString();
        }

        public string GetLocalityConnectionString()
        {
            return Localities.SingleOrDefault(x => x.LocalityId == LocalityId).GetConnectionString();
        }

        public void Clear()
        {
            Guid = "";
            Language = "";
            AppUrl = "";
            BackUrl = "";
            BaseUri = "";
            LocalityId = 0;
            Counter = 0;
            AuthInformation.Clear();
            Localities.Clear();
            NavigateModel.Clear();
        }

        public void MarkAsUsed()
        {
            LastDate = DateTime.Now;
        }
    }
}
