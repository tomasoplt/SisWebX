namespace SisWeb.EF.Models
{
    public partial class SISContext : Core.EF.EntityFrameworkCore.AppDbContext
    {
        public void SetConnectionString(string connectionString)
        {
            this.ConnectionString = connectionString;
        }
    }
}
