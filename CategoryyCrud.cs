using System.Data.SqlClient;
using System.Transactions;

namespace NimapProjectUsingADO.net.Models
{
    public class CategoryyCrud
    {
        private IConfiguration configuration;
        private SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;

        public CategoryyCrud(IConfiguration configuration)
        {
            this.configuration = configuration;
            con = new SqlConnection(this.configuration.GetConnectionString("defaultConnection"));

        }
        public IEnumerable<Categoryy> GetCategory()
        {
            List<Categoryy> list = new List<Categoryy>();
            cmd = new SqlCommand("Select *from Categoryy", con);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Categoryy c = new Categoryy();
                    c.CategoryId = Convert.ToInt32(dr["CategoryId"]);
                    c.CategoryName = dr["CategoryName"].ToString();
                    list.Add(c);
                }
            }
            con.Close();
            return list;
        }
        public Categoryy GetCategoryyById(int id)
        {
            Categoryy c = new Categoryy();
            cmd = new SqlCommand("select *from Categoryy where CategoryId=@id", con);
          
            cmd.Parameters.AddWithValue("@id", id);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {

                    c.CategoryId = Convert.ToInt32(dr["CategoryId"]);
                    c.CategoryName = (string)dr["CategoryName"];

                }
            }
            con.Close();
            return c;
        }
        public int AddCategory(Categoryy cat)
        {

            int result = 0;
            string qry = "INSERT INTO Categoryy (CategoryName) VALUES (@CategoryName)";
            cmd = new SqlCommand(qry, con);

            cmd.Parameters.AddWithValue("@CategoryName", cat.CategoryName);
            con.Open();
            result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }
        public int UpdtateCategory(Categoryy c)
        {

            int result = 0;
            string qry = "update Categoryy set CategoryName=@categoryname where CategoryId=@categoryid";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@categoryname", c.CategoryName);

            cmd.Parameters.AddWithValue("@categoryid", c.CategoryId);

            con.Open();
            result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }
        public int DeleteCategory(int id)
        {
            int result = 0;
            string qry = ("delete from Productt where  CategoryId=@categoryid ; delete from Ctegoryy where CategoryId=@categoryid ");

            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@categoryid", id);
            con.Open();
            result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }
    }
}
