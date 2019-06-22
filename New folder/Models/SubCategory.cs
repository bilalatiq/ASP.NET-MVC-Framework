using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace DB_ProjectTRY.Models
{
    public class SubCategory
    {
        public int subcat_id { get; set; }
        public string subcat_name { get; set; }
        public string subcat_image { get; set; }
        public int sbcat_fk_ad_id { get; set; }
        public int sbcat_fk_cat_id { get; set; }

        public void add()
        {
            string q = string.Format("insert into table_sub_category values('{0}','{1}',{2},{3})", subcat_name, subcat_image, sbcat_fk_ad_id,sbcat_fk_cat_id);
            SqlCommand cmd = new SqlCommand(q, connection.get());
            cmd.ExecuteNonQuery();
        }

        public void update()
        {
            string q = string.Format("update table_sub_category set sbcat_name='{0}' ,sbcat_image='{1}' ,sbcat_fk_ad_id={2} ,sbcat_fk_cat_id={3} where sbcat_id={4}", subcat_name, subcat_image , sbcat_fk_ad_id, sbcat_fk_cat_id,subcat_id);
            SqlCommand cmd = new SqlCommand(q, connection.get());
            cmd.ExecuteNonQuery();
        }

        public void delete()
        {
            string q = "delete from table_sub_category where sbcat_id=" + subcat_id;
            SqlCommand cmd = new SqlCommand(q, connection.get());
            cmd.ExecuteNonQuery();
        }

        public SubCategory search()
        {
            string q = "select * from table_sub_category where sbcat_id=" + subcat_id;
            SqlCommand cmd = new SqlCommand(q, connection.get());
            SqlDataReader sdr = cmd.ExecuteReader();
            SubCategory sc = new SubCategory();
            while (sdr.Read())
            {
                sc.subcat_id = (int)sdr[0];
                sc.subcat_name = (string)sdr[1];
                sc.subcat_image = (string)sdr[2];
                sc.sbcat_fk_ad_id = (int)sdr[3];
                sc.sbcat_fk_cat_id = (int)sdr[4];
            }
            sdr.Close();
            return sc;
        }

        public List<SubCategory> showall()
        {
            string q = "select * from table_sub_category";
            SqlCommand cmd = new SqlCommand(q, connection.get());
            SqlDataReader sdr = cmd.ExecuteReader();
            List<SubCategory> lst = new List<SubCategory>();
            while (sdr.Read())
            {
                SubCategory sc = new SubCategory();
                sc.subcat_id = (int)sdr[0];
                sc.subcat_name = (string)sdr[1];
                sc.subcat_image = (string)sdr[2];
                sc.sbcat_fk_ad_id = (int)sdr[3];
                sc.sbcat_fk_cat_id = (int)sdr[4];
                lst.Add(sc);
            }
            sdr.Close();
            return lst;
        }
    }
}