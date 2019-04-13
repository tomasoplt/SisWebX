namespace SisWeb.Services.Dto.Authentication
{
    public class AuthResultDto
    {
        public bool IsAuthentized { get; set; } = false;
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string Lastname { get; set; }
        public string Tel { get; set; }
        public string Password { get; set; }
        public string Username { get; set; }
        public string FullName
        {
            get
            {
                return $"{FirstName} {Lastname}";
            }
        }
        
        public void Clear()
        {
            IsAuthentized = false;
            Email = "";
            FirstName = "";
            Lastname = "";
            Tel = "";
            Password = "";
            Username = "";
        }
    }
}
