using Microsoft.EntityFrameworkCore;
using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace SisWeb.EF.Models
{
    public partial class SISContext : Core.EF.EntityFrameworkCore.AppDbContext
    {
        public void SetConnectionString(string connectionString)
        {
            this.ConnectionString = connectionString;
        }

        public int GetObjectId()
        {
            DbCommand cmd = Database.GetDbConnection().CreateCommand();
            cmd.CommandText = "dbo.fn_GetIDForTC";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add(new SqlParameter("@id", SqlDbType.Int) { Direction = ParameterDirection.Output, Value = 0 });

            bool opened = false;
            if (cmd.Connection.State != ConnectionState.Open)
            {
                cmd.Connection.Open();
                opened = true;
            }
            cmd.ExecuteNonQuery();

            int output = (int)cmd.Parameters["@id"].Value;

            if (opened)
                cmd.Connection.Close();

            return output;
        }

    }
}
