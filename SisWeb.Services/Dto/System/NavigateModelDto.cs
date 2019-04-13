namespace SisWeb.Services.Dto.System
{
    public class NavigateModelDto
    {
        public string LocalityId { get; set; }
        public string ObjektType { get; set; }
        public string ObjektId { get; set; }
        public string PlovakId { get; set; }
        public string Action { get; set; }
        public string Param1 { get; set; }
        public string Param2 { get; set; }

        public void Clear()
        {
            LocalityId = "";
            ObjektType = "";
            ObjektId = "";
            PlovakId = "";
            Action = "";
        }
    }
}
