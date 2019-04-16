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

        public void DestroySession()
        {
            using (var storage = new LocalStorage())
            {
                if (storage.Exists(SessionKey))
                {
                    string guid = storage.Get<string>(SessionKey);
                    if (dictionary.ContainsKey(guid))
                    {
                        if (!dictionary.TryRemove(guid, out UserSession removedSession))
                            throw new ApplicationException("Error DestroySession for guid:" + guid);
                    }
                }
            }

            using (var storage = new LocalStorage())
            {
                storage.Clear();
                storage.Persist();
            }
        }

        private void RemoveOldSession()
        {
            const int MaxLifeTime = 30;

            DateTime timeBack = DateTime.Now.AddMinutes(-MaxLifeTime);
            foreach( var session in dictionary)
            {
                if (session.Value.LastDate < timeBack)
                {
                    dictionary.TryRemove(session.Key, out UserSession removedSession);
                    break;
                }
            }
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
            RemoveOldSession();

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

                session.MarkAsUsed();
            }

            return session;
        }
    }
}
