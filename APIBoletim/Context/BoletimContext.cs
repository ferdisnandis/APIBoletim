using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace APIBoletim.Context
{
    public class BoletimContext
    {
        SqlConnection con = new SqlConnection();

        public BoletimContext()
        {
            con.ConnectionString = @"Data Source=DESKTOP-8VUG09E\SQLEXPRESS;Initial Catalog=boletim;User ID=sa;Password=sa132";
        }

        /// <summary>
        /// Conectar o servidor
        /// </summary>
        /// <returns>Estado do servidor</returns>
        public SqlConnection Conectar()
        {
            if(con.State == System.Data.ConnectionState.Closed)
            {
                con.Open();
            }

            return con;
        }

        /// <summary>
        /// Desconectar o servidor
        /// </summary>
        public void Desconectar()
        {
            if (con.State == System.Data.ConnectionState.Closed)
            {
                con.Close();
            }
  
        }
    }
}
