using System.Collections.Concurrent;
using System;
using System.Globalization;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace SisWeb.Services.Session
{
    public class SessionHelper : ISessionHelper
    {
        //private ConcurrentDictionary<string, UserSession> dictionary = new ConcurrentDictionary<string, UserSession>();
        private const string SessionKey = "sisappsession";
        private const int MaxLifeTime = 30;
        private const string TimeFormat = "yyyyMMddHHmm";
        private IHttpContextAccessor _httpContextAccessor;

        public string SessionDescription { get; set; }

        public SessionHelper(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        private SessionParams GetSessionParams(string val)
        {
            SessionParams sessParams = new SessionParams();

            string[] values = val.Split('|');
            if ( values.Length >= 1 )
                sessParams.Guid = values[0];
            if (values.Length >= 2)
                sessParams.Time = DateTime.ParseExact(values[1], TimeFormat, CultureInfo.InvariantCulture);

            return sessParams;
        }

        public string GetSessionKey()
        {
            string sessionParameter = _httpContextAccessor.HttpContext.Connection.Id;
            SessionParams parms = GetSessionParams(sessionParameter);
            return parms.Guid;
        }

        private string GenerateGuid()
        {
            return Guid.NewGuid().ToString() + "|" + DateTime.Now.ToString(TimeFormat);
        }

        public void SaveSession(UserSession session)
        {
            var sessionString = JsonConvert.SerializeObject(session);
            _httpContextAccessor.HttpContext.Session.SetString(SessionKey, sessionString);
        }

        public UserSession GetSession()
        {
            UserSession session = null;
            string sessionValue = _httpContextAccessor.HttpContext.Session.GetString(SessionKey);

            if (string.IsNullOrEmpty(sessionValue))
            {
                session = new UserSession(_httpContextAccessor.HttpContext.Connection.Id);
                SaveSession(session);
            }
            else
            {
                var sessionString  = _httpContextAccessor.HttpContext.Session.GetString(SessionKey);
                session = JsonConvert.DeserializeObject<UserSession>(sessionString);
            }

            return session;
        }
    }
}
