using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace DB_ProjectTRY.Models
{
    public class category
    {
        public int cat_id { get; set; }
        public string cat_name { get; set; }
        public string cat_image { get; set; }
        public int cat_fk_ad_id { get; set; }

        public void add()
        {
            string q = string.Format("insert into table_category values('{0}','{1}',{2})", cat_name, cat_image, cat_fk_ad_id);
            SqlCommand cmd = new SqlCommand(q, connection.get());
            cmd.ExecuteNonQuery();
        }

        public void update()
        {
            string q = string.Format("update table_category set cat_name='{0}' ,cat_image='{1}',cat_fk_ad_id={2} where cat_id={3}", cat_name, cat_image, cat_fk_ad_id, cat_id);
            SqlCommand cmd = new SqlCommand(q, connection.get());
            cmd.ExecuteNonQuery();
        }

        public void delete()
        {
            string q = "delete from table_category where cat_id=" + cat_id;
            SqlCommand cmd = new SqlCommand(q, connection.get());
            cmd.ExecuteNonQuery();
        }

        public category search()
        {
            string q = "select * from table_category where cat_id=" + cat_id;
            SqlCommand cmd = new SqlCommand(q, connection.get());
            SqlDataReader sdr = cmd.ExecuteReader();
            category c = new category();
            while (sdr.Read())
            {
                c.cat_id = (int)sdr[0];
                c.cat_name = (string)sdr[1];
                c.cat_image = (string)sdr[2];
                c.cat_fk_ad_id = (int)sdr[3];
            }
            sdr.Close();
            return c;
        }

        public List<category> showall()
        {
            string q = "select * from table_category";
            SqlCommand cmd = new SqlCommand(q, connection.get());
            SqlDataReader sdr = cmd.ExecuteReader();
            List<category> lst = new List<category>();
            while (sdr.Read())
            {
                category c = new category();
                c.cat_id = (int)sdr[0];
                c.cat_name = (string)sdr[1];
                c.cat_image = (string)sdr[2];
                c.cat_fk_ad_id = (int)sdr[3];
                lst.Add(c);
            }
            sdr.Close();
            return lst;
        }
    }
}