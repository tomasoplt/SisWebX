namespace SisWeb.Services.Session
{
    public interface ISessionHelper
    {
        UserSession GetSession();
        string GetSessionKey();
        void SaveSession(UserSession session);
        string SessionDescription { get; set; }
    }
}