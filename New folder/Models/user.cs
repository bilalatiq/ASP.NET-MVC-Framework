using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace DB_ProjectTRY.Models
{
    public class user
    {
        public int us_id { get; set; }
        public string us_email { get; set; }
        public string us_password { get; set; }
        public int us_phone { get; set; }
        public string us_billingAD { get; set; }

        public void add()
        {
            string q = string.Format("insert into table_user values('{0}','{1}',{2},'{3}')",us_email,us_password,us_phone,us_billingAD);
            SqlCommand cmd = new SqlCommand(q, connection.get());
            cmd.ExecuteNonQuery();
        }

        public void update()
        {
            string q = string.Format("update table_user set us_email='{0}',us_password='{1}',us_phone={2},us_billingAD='{3}' where us_id={4}", us_email, us_password, us_phone, us_billingAD, us_id);
            SqlCommand cmd = new SqlCommand(q, connection.get());
            cmd.ExecuteNonQuery();
        }

        public void delete()
        {
            string q = "delete from table_user where us_id=" + us_id;
            SqlCommand cmd = new SqlCommand(q, connection.get());
            cmd.ExecuteNonQuery();
        }

        public user search()
        {
            string q = "select * from table_user where us_id=" + us_id;
            SqlCommand cmd = new SqlCommand(q, connection.get());
            SqlDataReader sdr = cmd.ExecuteReader();
            user u = new user();
            while (sdr.Read())
            {
                u.us_id = (int)sdr[0];
                u.us_email = (string)sdr[1];
                u.us_password = (string)sdr[2];
                u.us_phone = (int)sdr[3];
                u.us_billingAD = (string)sdr[4];
            }
            sdr.Close();
            return u;
        }

        public List<user> showall()
        {
            string q = "select * from table_user";
            SqlCommand cmd = new SqlCommand(q, connection.get());
            SqlDataReader sdr = cmd.ExecuteReader();
            List<user> lst = new List<user>();
            while (sdr.Read())
            {
                user u = new user();
                u.us_id = (int)sdr[0];
                u.us_email = (string)sdr[1];
                u.us_password = (string)sdr[2];
                u.us_phone = (int)sdr[3];
                u.us_billingAD = (string)sdr[4];
                lst.Add(u);
            }
            sdr.Close();
            return lst;
        }
    }
}