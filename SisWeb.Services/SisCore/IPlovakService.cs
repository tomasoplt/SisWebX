using SisWeb.Services.Dto.Sis;
using System.Collections.Generic;

namespace SisWeb.Services.SisCore
{
    public interface IPlovakService
    {
        List<PlovakModelDto> GetPlovaky(int objekt_id);
        PlovakModelDto GetSingle(int plovak_id);
        void Save(PlovakModelDto obj);
    }
}