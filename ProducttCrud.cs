using System.Collections.Generic;
using System.Data.SqlClient;


namespace NimapProjectUsingADO.net.Models
{
    
        public class ProducttCrud
        {
           
    private IConfiguration configuration;
        private SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;

        public ProducttCrud(IConfiguration configuration)
        {
            this.configuration = configuration;
            con = new SqlConnection(this.configuration.GetConnectionString("defaultConnection"));

        }
        public IEnumerable<Productt> GetProducts()
        {
            List<Productt> list = new List<Productt>();
            string qry = @"select p.ProductId,p.ProductName,c.CategoryId,c.CategoryName
                            from Productt p
                            Inner join Categoryy c on p. CategoryId=c.CategoryId";
            cmd = new SqlCommand(qry, con);
            con.Open();
            dr = cmd.ExecuteReader();
            if(dr.HasRows)
            {
                while(dr.Read())
                {
                    Productt p = new Productt();
                    p.ProductId = Convert.ToInt32(dr["ProductId"]);
                    p.ProductName = (string)dr["ProductName"];
                    p.CategoryId = Convert.ToInt32(dr["CategoryId"]);
                    p.CategoryName = (string)dr["CategoryName"];
                    list.Add(p);
                }
            }
            con.Close();
            return list;
        
        }
        public Productt GetProductById(int id)
        {
            Productt p = new Productt();
            string qry="select ProductId,ProductName,CategoryId,CategoryName from Productt where ProductId=@id";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@id", id);
            dr = cmd.ExecuteReader();
            if(dr.HasRows)
            {
                while(dr.Read())
                {
                    p.ProductId = Convert.ToInt32(dr["ProductId"]);
                    p.ProductName = (string)dr["ProductName"];
                    p.CategoryId = Convert.ToInt32(dr["CategoryId"]);
                    p.CategoryName = (string)dr["CategoryName "];
                    
                }
            }
            con.Close();
            return p;
        }
        public int AddProduct(Productt prod)
        {

            int result = 0;
            string qry = "insert into  Productt (ProductName,  CategoryId) values (@ProductName,  @CategoryId)";
            
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@ProductName", prod.ProductName);
           
            cmd.Parameters.AddWithValue("@CategoryId", prod.CategoryId);
            try
            {
                con.Open();
                result = cmd.ExecuteNonQuery();  
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);  
            }
            finally
            {
                con.Close();
            }

            return result;
        }

        public int UpdtateProduct(Productt prod)
        {

            int result = 0;
            string qry = "update Productt set productname=@productname,categoryid=@categoryid where ProductId=@productid";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@productname", prod.ProductName);
          
            cmd.Parameters.AddWithValue("@categoryid", prod.CategoryId);
            cmd.Parameters.AddWithValue("@productid", prod.ProductId);
            con.Open();
            result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }
        public int DeleteProduct(int id)
        {
            int result = 0;
            string qry = "delete from Productt  where ProductId=@productid";
            cmd = new SqlCommand(qry, con);
       
            cmd.Parameters.AddWithValue("@productid", id);
            con.Open();
            result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }
    }
}
    