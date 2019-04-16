using SisWeb.Services.Dto.Authentication;
using SisWeb.Services.Dto.Sis;
using SisWeb.Services.Dto.System;
using System.Collections.Generic;

namespace SisWeb.Services.Session
{
    public interface ISessionHelper
    {
        UserSession GetSession();
        UserSession GetSession(string guid);
        void DestroySession();
    }
}