using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DB_ProjectTRY
{
    public class connection
    {
        public static SqlConnection sc;
        public static SqlConnection get()
        {
            if (sc==null)
            {
                sc = new SqlConnection();
                sc.ConnectionString = "Data Source=Bilal;Initial Catalog=pcbuild;Integrated Security=True";
                sc.Open();
            }
            return sc;
        }
    }
}