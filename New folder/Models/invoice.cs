using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace DB_ProjectTRY.Models
{
    public class invoice
    {
        public int in_id { get; set; }
        public string in_date { get; set; }
        public int in_fk_us_id { get; set; }

        public void add()
        {
            string q = string.Format("insert into table_invoice values('{0}',{1})", in_date, in_fk_us_id);
            SqlCommand cmd = new SqlCommand(q, connection.get());
            cmd.ExecuteNonQuery();
        }

        public void update()
        {
            string q = string.Format("update table_invoice set in_date='{0}',in_fk_us_id={1} where in_id={2}", in_date, in_fk_us_id, in_id);
            SqlCommand cmd = new SqlCommand(q, connection.get());
            cmd.ExecuteNonQuery();
        }

        public void delete()
        {
            string q = "delete from table_invoice where in_id=" + in_id;
            SqlCommand cmd = new SqlCommand(q, connection.get());
            cmd.ExecuteNonQuery();
        }

        public invoice search()
        {
            string q = "select * from table_invoice where in_id=" + in_id;
            SqlCommand cmd = new SqlCommand(q, connection.get());
            SqlDataReader sdr = cmd.ExecuteReader();
            invoice i = new invoice();
            while (sdr.Read())
            {
                i.in_id = (int)sdr[0];
                i.in_date = (string)sdr[1];
                i.in_fk_us_id = (int)sdr[2];
            }
            sdr.Close();
            return i;
        }

        public List<invoice> showall()
        {
            string q = "select * from table_invoice";
            SqlCommand cmd = new SqlCommand(q, connection.get());
            SqlDataReader sdr = cmd.ExecuteReader();
            List<invoice> lst = new List<invoice>();
            while (sdr.Read())
            {
                invoice i = new invoice();
                i.in_id = (int)sdr[0];
                i.in_date = (string)sdr[1];
                i.in_fk_us_id = (int)sdr[2];
                lst.Add(i);
            }
            sdr.Close();
            return lst;
        }
    }
}