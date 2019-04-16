using System.Collections.Concurrent;
using Hanssens.Net;
using System;
using System.Globalization;

namespace SisWeb.Services.Session
{
    public class SessionHelper : ISessionHelper
    {
        private ConcurrentDictionary<string, UserSession> dictionary = new ConcurrentDictionary<string, UserSession>();
        private const string SessionKey = "sisappsession";
        private const int MaxLifeTime = 30;
        private const string TimeFormat = "yyyyMMddHHmm";

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


            DateTime timeBack = DateTime.Now.AddMinutes(-MaxLifeTime);
            bool removed = true;

            while (removed)
            {
                removed = false;
                foreach (var session in dictionary)
                {
                    if (session.Value.LastDate < timeBack)
                    {
                        dictionary.TryRemove(session.Key, out UserSession removedSession);
                        removed = true;
                        break;
                    }
                }
            }
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

        public UserSession GetSession()
        {
            string guid = "";
            DateTime timeBack = DateTime.Now.AddMinutes(-MaxLifeTime);

            using (var storage = new LocalStorage())
            {
                if (storage.Exists(SessionKey))
                {
                    string sessionParameter = storage.Get<string>(SessionKey);
                    SessionParams parms = GetSessionParams(sessionParameter);
                    guid = parms.Guid;

                    if (parms.Time == null || parms.Time.Value < timeBack)
                    {
                        guid = GenerateGuid();
                        storage.Store(SessionKey, guid);
                        storage.Persist();
                    }
                }
                else
                {
                    guid = GenerateGuid();
                    storage.Store(SessionKey, guid);
                    storage.Persist();
                }
            }

            return GetSession(guid);
        }

        private string GenerateGuid()
        {
            return Guid.NewGuid().ToString() + "|" + DateTime.Now.ToString(TimeFormat);
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
