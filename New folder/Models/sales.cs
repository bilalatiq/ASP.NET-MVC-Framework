using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace DB_ProjectTRY.Models
{
    public class sales
    {
        public int sls_id { get; set; }
        public int sls_qty { get; set; }
        public int sls_fk_in_id { get; set; }
        public int sls_fk_prd_id { get; set; }

        public void add()
        {
            string q = string.Format("insert into table_sales values({0},{1},{2})", sls_qty,sls_fk_in_id,sls_fk_prd_id);
            SqlCommand cmd = new SqlCommand(q, connection.get());
            cmd.ExecuteNonQuery();
        }

        public void update()
        {
            string q = string.Format("update table_sales set sls_qty={0},sls_fk_in_id={1},sls_fk_prd_id={2} where sls_id={3}", sls_qty,sls_fk_in_id,sls_fk_prd_id,sls_id);
            SqlCommand cmd = new SqlCommand(q, connection.get());
            cmd.ExecuteNonQuery();
        }

        public void delete()
        {
            string q = "delete from table_sales where sls_id=" + sls_id;
            SqlCommand cmd = new SqlCommand(q, connection.get());
            cmd.ExecuteNonQuery();
        }

        public sales search()
        {
            string q = "select * from table_sales where sls_id=" + sls_id;
            SqlCommand cmd = new SqlCommand(q, connection.get());
            SqlDataReader sdr = cmd.ExecuteReader();
            sales s = new sales();
            while (sdr.Read())
            {
                s.sls_id = (int)sdr[0];
                s.sls_qty = (int)sdr[1];
                s.sls_fk_in_id = (int)sdr[2];
                s.sls_fk_prd_id = (int)sdr[3];
            }
            sdr.Close();
            return s;
        }

        public List<sales> showall()
        {
            string q = "select * from table_sales";
            SqlCommand cmd = new SqlCommand(q, connection.get());
            SqlDataReader sdr = cmd.ExecuteReader();
            List<sales> lst = new List<sales>();
            while (sdr.Read())
            {
                sales s = new sales();
                s.sls_id = (int)sdr[0];
                s.sls_qty = (int)sdr[1];
                s.sls_fk_in_id = (int)sdr[2];
                s.sls_fk_prd_id = (int)sdr[3];
                lst.Add(s);
            }
            sdr.Close();
            return lst;
        }
    }
}