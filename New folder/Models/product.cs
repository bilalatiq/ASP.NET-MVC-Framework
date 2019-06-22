using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace DB_ProjectTRY.Models
{
    public class product
    {
        public int prd_id { get; set; }
        public string prd_name { get; set; }
        public string prd_dis { get; set; }
        public int prd_selprice { get; set; }
        public int prd_cstprice  { get; set; }
        public int prd_fk_cat_id { get; set; }
        public int prd_fk_sbcat_id { get; set; }
        public int prd_fk_ad_id { get; set; }

        public void add()
        {
            string q = string.Format("insert into table_product values('{0}','{1}',{2},{3},{4},{5},{6})", prd_name, prd_dis, prd_selprice, prd_cstprice, prd_fk_cat_id, prd_fk_sbcat_id, prd_fk_ad_id);
            SqlCommand cmd = new SqlCommand(q, connection.get());
            cmd.ExecuteNonQuery();
        }

        public void update()
        {
            string q = string.Format("update table_product set prd_name='{0}', prd_dis='{1}',prd_selprice={2},prd_cstprise={3},prd_fk_cat_id={4},prd_fk_sbcat_id={5},prd_fk_ad_id={6} where prd_id={7}", prd_name, prd_dis, prd_selprice, prd_cstprice, prd_fk_cat_id, prd_fk_sbcat_id, prd_fk_ad_id, prd_id);
            SqlCommand cmd = new SqlCommand(q, connection.get());
            cmd.ExecuteNonQuery();
        }

        public void delete()
        {
            string q = "delete from table_product where prd_id=" + prd_id;
            SqlCommand cmd = new SqlCommand(q, connection.get());
            cmd.ExecuteNonQuery();
        }

        public product search()
        {
            string q = "select * from table_product where prd_id=" + prd_id;
            SqlCommand cmd = new SqlCommand(q, connection.get());
            SqlDataReader sdr = cmd.ExecuteReader();
            product p = new product();
            while (sdr.Read())
            {
                p.prd_id = (int)sdr[0];
                p.prd_name = (string)sdr[1];
                p.prd_dis = (string)sdr[2];
                p.prd_selprice = (int)sdr[3];
                p.prd_cstprice = (int)sdr[4];
                p.prd_fk_cat_id = (int)sdr[5];
                p.prd_fk_sbcat_id = (int)sdr[6];
                p.prd_fk_ad_id = (int)sdr[7];
            }
            sdr.Close();
            return p;
        }

        public List<product> showall()
        {
            string q = "select * from table_product";
            SqlCommand cmd = new SqlCommand(q, connection.get());
            SqlDataReader sdr = cmd.ExecuteReader();
            List<product> lst = new List<product>();
            while (sdr.Read())
            {
                product p = new product();
                p.prd_id = (int)sdr[0];
                p.prd_name = (string)sdr[1];
                p.prd_dis = (string)sdr[2];
                p.prd_selprice = (int)sdr[3];
                p.prd_cstprice = (int)sdr[4];
                p.prd_fk_cat_id = (int)sdr[5];
                p.prd_fk_sbcat_id = (int)sdr[6];
                p.prd_fk_ad_id = (int)sdr[7];
                lst.Add(p);
            }
            sdr.Close();
            return lst;
        }

    }
}