using SisWeb.Services.Dto.Authentication;
using SisWeb.Services.Dto.Sis;
using SisWeb.Services.Session;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SisWeb.Services.Authentication
{
    public interface IUserService
    {
        string HashPwd(string pwd);
        Task<AuthResultDto> LoginUser(string login, string password, bool hashPassword);
        Task<List<LocalityModelDto>> GetUserLocalities(string login, string password, bool hashPassword);
        void FillLocality(LocalityModelDto localLocality, UserSession userSession);
    }
}