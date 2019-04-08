using Core.Services.Application;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using SisWeb.EF.Models;
using SisWeb.Services.Dto.Authentication;
using SisWeb.Services.Dto.Sis;
using SisWeb.Services.Session;
using SisWeb.Services.SisCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace SisWeb.Services.Authentication
{
    public class UserService : ApplicationService, IUserService
    {
        private ISessionHelper _sessionHelper;
        private IObjectService _objectService;
        private IConfiguration _configuration;
        private readonly ILogger _log;

        public UserService(ISessionHelper sessionHelper, IObjectService objectService, ILogger<UserService> log, IConfiguration configuration)
        {
            _sessionHelper = sessionHelper;
            _objectService = objectService;
            _configuration = configuration;
            _log = log;
        }

        public async Task<AuthResultDto> LoginUser(string login, string password, bool hashPassword)
        {
            var client = new SisWebService.BaseDataClient();
            SetClientProperties(client);

            var hashedPassword = hashPassword ? HashPwd(password) : password;
            bool isAuthentized = await client.AuthenticatedUserAsync(SisWebService.LocalityType.SIS, login, hashedPassword);

            var result = new AuthResultDto();
            result.IsAuthentized = isAuthentized;

            if (isAuthentized)
            {
                var sisUser = await client.GetSISSrvAuthenticatedUserAsync(SisWebService.LocalityType.SIS, login, hashedPassword);
                if (sisUser.Count > 0)
                {
                    result.Email = sisUser[0].email;
                    result.FirstName = sisUser[0].firstName;
                    result.Lastname = sisUser[0].lastName;
                    result.Tel = sisUser[0].tel;
                }
            }

            return result;
        }

        public async Task<List<LocalityModelDto>> GetUserLocalities(string login, string password, bool hashPassword)
        {
            var client = new SisWebService.BaseDataClient();
            SetClientProperties(client);
            var hashedPassword = hashPassword ? HashPwd(password) : password;
            var localities = await client.GetSISSrvLocalitiesForUserAsync(SisWebService.LocalityType.SIS, login, hashedPassword);

            var list = new List<LocalityModelDto>();
            foreach (var locality in localities)
            {
                var item = new LocalityModelDto
                {
                    LocalityId = locality.localityId,
                    LocalityName = locality.localityName,
                    LocalityDescription = locality.localityDescription,
                    Note = locality.note,
                    Url = locality.sistcurl,
                    DbServer = locality.srv,
                    DbCatalog = locality.db,
                    DbUsername = locality.uname,
                    DbPassword = locality.pwd
                };
                list.Add(item);
            }

            _sessionHelper.Localities = list;

            var localLocality = list.FirstOrDefault(x => x.Url == _sessionHelper.BaseUri);
            if ( localLocality != null)
            {
                localLocality.IsLocal = true;
                try
                {
                    ObjectService objectService = _objectService as ObjectService;
                    _sessionHelper.SetLocality(localLocality.LocalityId.Value);
                    objectService.SetConnectionString();
                    localLocality.Objekty = _objectService.GetObjects(true);
                }
                catch ( Exception ex)
                {
                    _log.LogError(ex, "GetObjects");
                }
            }


            return list;
        }

        private void SetClientProperties(SisWebService.BaseDataClient client)
        {
            string webServiceAddress = GetWebServiceAddr();
            ServicePointManager.ServerCertificateValidationCallback += RemoteCertificateValidate;
            EndpointAddress Address = new EndpointAddress(webServiceAddress);
            client.Endpoint.Address = Address;

            //client.ClientCredentials.UserName.UserName = login;
            //client.ClientCredentials.UserName.Password = password;
        }

        private string GetWebServiceAddr()
        {
            var graphSection = _configuration.GetSection("WebService");
            var settingsSection = graphSection.GetSection("Settings");
            string addr = settingsSection.GetValue<string>("Address");

            return addr;
        }

        /// <summary>
        /// Remotes the certificate validate.
        /// </summary>
        private static bool RemoteCertificateValidate(object sender, X509Certificate cert, X509Chain chain, SslPolicyErrors error)
        {
            // trust any certificate!!!
            System.Console.WriteLine("Warning, trust any certificate");
            return true;
        }

        public string HashPwd(string pwd)
        {
            MD5 md5Hash = MD5.Create();
            {
                byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(pwd));
                StringBuilder sBuilder = new StringBuilder();
                for (int i = 0; i < data.Length; i++)
                {
                    sBuilder.Append(data[i].ToString("x2"));
                }
                return sBuilder.ToString();
            }
        }


    }
}
