using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace DB_ProjectTRY.Models
{
    public class admin
    {
        public int ad_id { get; set; }
        public string ad_name { get; set; }
        public int ad_age { get; set; }
        public int ad_phone { get; set; }
        public string ad_username { get; set; }
        public string ad_password { get; set; }
        public string ad_email { get; set; }
        public string ad_image { get; set; }

        public void add()
        {
            string q = string.Format("insert into table_admin values('{0}',{1},{2},'{3}','{4}','{5}','{6}')",ad_name,ad_age,ad_phone,ad_username,ad_password,ad_email,ad_image);
            SqlCommand cmd = new SqlCommand(q,connection.get());
            cmd.ExecuteNonQuery();           
        }

        public void update()
        {
            string q = string.Format("update table_admin set ad_name='{0}',ad_age={1},ad_phone={2},ad_password='{3}',ad_email='{4}',ad_image='{5}',ad_username='{6}' where ad_id={7}",ad_name,ad_age,ad_phone,ad_password,ad_email,ad_image,ad_username,ad_id);
            SqlCommand cmd = new SqlCommand(q,connection.get());
            cmd.ExecuteNonQuery();
        }

        public void delete()
        {
            string q = "delete from table_admin where ad_id="+ad_id;
            SqlCommand cmd = new SqlCommand(q, connection.get());
            cmd.ExecuteNonQuery();
        }

        public admin search()
        {
            string q = "select * from table_admin where ad_id="+ad_id;
            SqlCommand cmd = new SqlCommand(q, connection.get());
            SqlDataReader sdr = cmd.ExecuteReader();
            admin a = new admin();
            while (sdr.Read())
            {
                a.ad_id = (int)sdr[0];
                a.ad_name = (string)sdr[1];
                a.ad_age = (int)sdr[2];
                a.ad_phone = (int)sdr[3];
                a.ad_username = (string)sdr[4];
                a.ad_password = (string)sdr[5];
                a.ad_email = (string)sdr[6];
                a.ad_image = (string)sdr[7];
            }
            sdr.Close();
            return a;
        }

        public List<admin> showall()
        {
            string q = "select * from table_admin";
            SqlCommand cmd = new SqlCommand(q, connection.get());
            SqlDataReader sdr = cmd.ExecuteReader();
            List<admin> lst = new List<admin>();
            while (sdr.Read())
            {
                admin a = new admin();
                a.ad_id = (int)sdr[0];
                a.ad_name = (string)sdr[1];
                a.ad_age = (int)sdr[2];
                a.ad_phone = (int)sdr[3];
                a.ad_username = (string)sdr[4];
                a.ad_password = (string)sdr[5];
                a.ad_email = (string)sdr[6];
                a.ad_image = (string)sdr[7];
                lst.Add(a);
            }
            sdr.Close();
            return lst;
        }
    }
}