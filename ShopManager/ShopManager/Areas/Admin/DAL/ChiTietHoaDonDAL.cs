using Microsoft.Data.SqlClient;
using ShopManager.Areas.Admin.Models;
using ShopManager.Database;
using System.Collections.Generic;

namespace ShopManager.Areas.Admin.DAL
{
    public class ChiTietHoaDonDAL
    {
        DBConnect connect = new DBConnect();

        public List<ChiTietHoaDon> GetChiTietHoaDons()
        {
            connect.openConnection();
            List<ChiTietHoaDon> list = new List<ChiTietHoaDon>();

            using (SqlCommand command = new SqlCommand())
            {
                command.Connection = connect.getConnecttion();
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = @"SELECT * FROM paymentDetail";

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    ChiTietHoaDon detail = new ChiTietHoaDon
                    {
                        ProductId = Convert.ToInt32(reader["productId"]),
                        PaymentId = Convert.ToInt32(reader["paymentId"]),
                        Price = Convert.ToDecimal(reader["price"]),
                        Quantity = Convert.ToInt32(reader["quantity"]),
                        Total = Convert.ToDecimal(reader["total"]),
                        CreateAt = DateTime.Parse(reader["createAt"].ToString())
                    };
                    list.Add(detail);
                }
            }
            connect.closeConnection();
            return list;
        }

        public ChiTietHoaDon GetChiTietHoaDonById(int paymentId)
        {
            connect.openConnection();
            ChiTietHoaDon detail = null;

            using (SqlCommand command = new SqlCommand())
            {
                command.Connection = connect.getConnecttion();
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = @"SELECT * FROM paymentDetail WHERE paymentId = @paymentId";

                command.Parameters.AddWithValue("@paymentId", paymentId);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    detail = new ChiTietHoaDon
                    {
                        ProductId = Convert.ToInt32(reader["productId"]),
                        PaymentId = Convert.ToInt32(reader["paymentId"]),
                        Price = Convert.ToDecimal(reader["price"]),
                        Quantity = Convert.ToInt32(reader["quantity"]),
                        Total = Convert.ToDecimal(reader["total"]),
                        CreateAt = DateTime.Parse(reader["createAt"].ToString())
                    };
                }
            }
            connect.closeConnection();
            return detail;
        }
    }
}
