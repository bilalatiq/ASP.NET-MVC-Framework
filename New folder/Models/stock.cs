using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace DB_ProjectTRY.Models
{
    public class stock
    {
        public int st_id { get; set; }
        public string st_name { get; set; }
        public int st_qty { get; set; }
        public string st_date { get; set; }
        public int st_fk_ad_id { get; set; }
        public int st_fk_prd_id { get; set; }

        public void add()
        {
            string q = string.Format("insert into table_stock values('{0}',{1},'{2}',{3},{4})", st_name, st_qty, st_date, st_fk_ad_id, st_fk_prd_id);
            SqlCommand cmd = new SqlCommand(q, connection.get());
            cmd.ExecuteNonQuery();
        }

        public void update()
        {
            string q = string.Format("update table_stock set st_name='{0}',st_qty={1},st_date='{2}',st_fk_ad_id={3},st_fk_prd_id={4} where st_id={5}", st_name, st_qty, st_date, st_fk_ad_id, st_fk_prd_id, st_id);
            SqlCommand cmd = new SqlCommand(q, connection.get());
            cmd.ExecuteNonQuery();
        }

        public void delete()
        {
            string q = "delete from table_stock where st_id=" + st_id;
            SqlCommand cmd = new SqlCommand(q, connection.get());
            cmd.ExecuteNonQuery();
        }

        public stock search()
        {
            string q = "select * from table_stock where st_id=" + st_id;
            SqlCommand cmd = new SqlCommand(q, connection.get());
            SqlDataReader sdr = cmd.ExecuteReader();
            stock s = new stock();
            while (sdr.Read())
            {
                s.st_id = (int)sdr[0];
                s.st_name = (string)sdr[1];
                s.st_qty = (int)sdr[2];
                s.st_date = (string)sdr[3];
                s.st_fk_ad_id = (int)sdr[4];
                s.st_fk_prd_id = (int)sdr[5];
            }
            sdr.Close();
            return s;
        }

        public List<stock> showall()
        {
            string q = "select * from table_stock";
            SqlCommand cmd = new SqlCommand(q, connection.get());
            SqlDataReader sdr = cmd.ExecuteReader();
            List<stock> lst = new List<stock>();
            while (sdr.Read())
            {
                stock s = new stock();
                s.st_id = (int)sdr[0];
                s.st_name = (string)sdr[1];
                s.st_qty = (int)sdr[2];
                s.st_date = (string)sdr[3];
                s.st_fk_ad_id = (int)sdr[4];
                s.st_fk_prd_id = (int)sdr[5];
                lst.Add(s);
            }
            sdr.Close();
            return lst;
        }
    }
}