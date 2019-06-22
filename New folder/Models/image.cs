using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace DB_ProjectTRY.Models
{
    public class image
    {
        public int img_id { get; set; }
        public string img_path { get; set; }
        public int img_fk_prd_id { get; set; }

        public void add()
        {
            string q = string.Format("insert into table_image values('{0}',{1})",img_path,img_fk_prd_id);
            SqlCommand cmd = new SqlCommand(q, connection.get());
            cmd.ExecuteNonQuery();
        }

        public void update()
        {
            string q = string.Format("update table_image set img_path='{0}',img_fk_prd_id={1} where img_id={2}",img_path,img_fk_prd_id,img_id);
            SqlCommand cmd = new SqlCommand(q, connection.get());
            cmd.ExecuteNonQuery();
        }

        public void delete()
        {
            string q = "delete from table_image where img_id=" + img_id;
            SqlCommand cmd = new SqlCommand(q, connection.get());
            cmd.ExecuteNonQuery();
        }

        public image search()
        {
            string q = "select * from table_image where img_id=" + img_id;
            SqlCommand cmd = new SqlCommand(q, connection.get());
            SqlDataReader sdr = cmd.ExecuteReader();
            image i = new image();
            while (sdr.Read())
            {
                i.img_id = (int)sdr[0];
                i.img_path = (string)sdr[1];
                i.img_fk_prd_id = (int)sdr[2];
            }
            sdr.Close();
            return i;
        }

        public List<image> showall()
        {
            string q = "select * from table_image";
            SqlCommand cmd = new SqlCommand(q, connection.get());
            SqlDataReader sdr = cmd.ExecuteReader();
            List<image> lst = new List<image>();
            while (sdr.Read())
            {
                image i = new image();
                i.img_id = (int)sdr[0];
                i.img_path = (string)sdr[1];
                i.img_fk_prd_id = (int)sdr[2];
                lst.Add(i);
            }
            sdr.Close();
            return lst;
        }
    }
}