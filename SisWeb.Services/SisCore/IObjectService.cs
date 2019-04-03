using Core.Services.Application;
using SisWeb.Services.Dto.Sis;
using System.Collections.Generic;

namespace SisWeb.Services.SisCore
{
    public interface IObjectService : IApplicationService
    {
        List<ObjectModelDto> GetObjects(bool includePlovak);
        List<ObjectModelDto> GetObjects(string nazev);
        
        ObjectModelDto GetObject(int objekt_id);
        void SaveObject(ObjectModelDto obj);
    }
}