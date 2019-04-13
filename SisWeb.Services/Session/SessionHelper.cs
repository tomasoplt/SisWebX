using SisWeb.Services.Dto.Authentication;
using SisWeb.Services.Dto.Sis;
using SisWeb.Services.Dto.System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using Hanssens.Net;
using System;

namespace SisWeb.Services.Session
{
    public class SessionHelper : ISessionHelper
    {
        private ConcurrentDictionary<string, UserSession> dictionary = new ConcurrentDictionary<string, UserSession>();
        private const string SessionKey = "sisappsession";

        public SessionHelper()
        {

        }

        public UserSession GetSession()
        {
            string guid = "";

            using (var storage = new LocalStorage())
            {
                if (storage.Exists(SessionKey))
                    guid = storage.Get<string>(SessionKey);
                else
                {
                    guid = Guid.NewGuid().ToString();

                    storage.Store(SessionKey, guid);
                    storage.Persist();
                }
            }

            return GetSession(guid);
        }

        public UserSession GetSession(string guid)
        {
            UserSession session = null;
            if (!dictionary.ContainsKey(guid))
            {
                session = new UserSession(guid);
                if (!dictionary.TryAdd(guid, session))
                    throw new ApplicationException("Error adding UserSesssion for guid:" + guid);
            }
            else
            {
                if (!dictionary.TryGetValue(guid, out session))
                    throw new ApplicationException("Error getting UserSesssion for guid:" + guid);
            }

            return session;
        }
    }
}
