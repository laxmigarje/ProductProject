using Microsoft.Extensions.Configuration;
using ProductProject.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ProductProject.DAL
{
    public class ProductDAL
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        private IConfiguration configuration;
        private object pid;

        public ProductDAL(IConfiguration configuration)
        {
            this.configuration = configuration;
            string constr = configuration["ConnectionStrings:defaultConnection"];
            con = new SqlConnection(constr);
        }
        public List<Product> GetAllProducts()
        {
            List<Product> Productlist = new List<Product>();
            string qry = "select*from Product";
            cmd = new SqlCommand(qry, con);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Product Product = new Product();
                    Product.pid = Convert.ToInt32(dr["pid"]);

                    Product.pname = dr["pname"].ToString();
                    Product.company = dr["company"].ToString();
                    Product.price = Convert.ToInt32(dr["price"]);
                    Product.password = dr["password"].ToString();
                    Productlist.Add(Product);
                }
            }
            con.Close();
            return Productlist;
        }
        public Product GetProductById(int id)
        {
            Product product = new Product();
            string qry = "select * from Product where Id=@pid";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@id", pid);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    product.pid = Convert.ToInt32(dr["pid"]);
                    product.pname = dr["pname"].ToString();
                    product.company = dr["company"].ToString();
                    product.price = Convert.ToInt32(dr["price"]);
                    product.password = dr["password"].ToString();

                }
            }
            
        
            con.Close();
            return product;
        }
        public int AddProduct(Product prod)
        {
            string qry = "insert into Product values(@pid,@pname,@company,@price,@password)";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@pid", prod.pid);
            cmd.Parameters.AddWithValue("@pname", prod.pname);
            cmd.Parameters.AddWithValue("@company", prod.company);
            cmd.Parameters.AddWithValue("@price", prod.price);
            cmd.Parameters.AddWithValue("@password", prod.password);
            con.Open();
            int res = cmd.ExecuteNonQuery();
            con.Close();
            return res;

        }
        public int UpdateProduct(Product prod)
        {
            string qry = "update Product set @pid,@pname,@company,@price,@password  where Id=@pid";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@pid", prod.pid);
            cmd.Parameters.AddWithValue("@pname", prod.pname);
            cmd.Parameters.AddWithValue("@company", prod.company);
            cmd.Parameters.AddWithValue("@price", prod.price);
            cmd.Parameters.AddWithValue("@password", prod.password);
            con.Open();
            int res = cmd.ExecuteNonQuery();
            con.Close();
            return res;
        }
        public int DeleteProduct(int id)
        {
            string qry = "delete from Product where Id=@pid";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@id", pid);
            con.Open();
            int res = cmd.ExecuteNonQuery();
            con.Close();
            return res;
        }
    }



}