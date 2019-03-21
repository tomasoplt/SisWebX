using System.Collections.Generic;

namespace SisWeb.Services.Dto.Sis
{
    public class LocalityModelDto
    {
        public int? LocalityId { get; set; }
        public string LocalityName { get; set; }
        public string LocalityDescription { get; set; }
        public string Note { get; set; }
        public string Url { get; set; }
        public string DbServer { get; set; }
        public string DbCatalog { get; set; }
        public string DbUsername { get; set; }
        public string DbPassword { get; set; }

        public LocalityModelDto()
        {
            Objekty = new List<ObjectModelDto>();
        }

        public List<ObjectModelDto> Objekty { get; set; }
    }
}
