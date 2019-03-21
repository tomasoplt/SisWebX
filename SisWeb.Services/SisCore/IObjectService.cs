using SisWeb.Services.Dto.Sis;
using System.Collections.Generic;

namespace SisWeb.Services.SisCore
{
    public interface IObjectService
    {
        List<ObjectModelDto> GetObjects();
        ObjectModelDto GetObject(int objekt_id);
        void SaveObject(ObjectModelDto obj);
    }
}