using Microsoft.Data.SqlClient;
using ShopManager.Database;
using ShopManager.Models;

namespace ShopManager.DAL
{
    public class ProductArrangeDAL
    {
        DBConnect connect = new DBConnect();
        public List<Product> GetRelatedProducts(int limitProduct)
        {
            // get from product table 
            // top limitProduct 
            // sort by product.rate desc 
            connect.openConnection();

            List<Product> list = new List<Product>();

            using (SqlCommand command = new SqlCommand())
            {
                command.Connection = connect.getConnecttion();
                command.CommandType = System.Data.CommandType.Text;

                string query = @"select top " + limitProduct + @" a.id as 
                    ProductId, a.title as ProductTitle,   
                    a.content as ProductContent, a.img as ProductImg, a.price as ProductPrice, 
                    a.rate as ProductRate, a.createAt as ProductCreateAt, a.updateAt as ProductUpdateAt,  
                    b.id as CategoryId, b.title as CategoryTitle 
                    from product a join category b on a.categoryId = b.Id 
                    order by a.rate DESC; ";

                command.CommandText = query;

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    // ================== Cách 1 =============== 
                    Product product = new Product()
                    {
                        Id = Convert.ToInt32(reader["ProductId"]),
                        Title = reader["ProductTitle"].ToString() ?? "",
                        Content = reader["ProductContent"].ToString() ?? "",
                        Img = reader["ProductImg"].ToString() ?? "",
                        Price = Convert.ToInt32(reader["ProductPrice"]),
                        Rate = Convert.ToDouble(reader["ProductRate"].ToString()),
                        CreateAt = DateTime.Parse(reader["ProductCreateAt"]?.ToString()),
                        UpdateAt = DateTime.Parse(reader["ProductUpdateAt"]?.ToString()),
                        CategoryId = Convert.ToInt32(reader["CategoryId"]),
                        CategoryTitle = reader["CategoryTitle"].ToString(),
                    };

                    list.Add(product);
                }
            }
            connect.closeConnection();
            return list;
        }
    }
}
