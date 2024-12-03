using Microsoft.Data.SqlClient;
using ShopManager.Areas.Admin.Models;
using ShopManager.Database;
using System.Collections.Generic;

namespace ShopManager.Areas.Admin.DAL
{
    public class HoaDonDAL
    {
        private readonly DBConnect connect = new DBConnect();

        // Lấy danh sách hóa đơn
        public List<HoaDon> GetHoaDons()
        {
            connect.openConnection();
            List<HoaDon> list = new List<HoaDon>();

            using (SqlCommand command = new SqlCommand())
            {
                command.Connection = connect.getConnecttion();
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = @"SELECT id, customerId, firstName, lastName, phone, email, createAt, total FROM payment";

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    HoaDon hoaDon = new HoaDon
                    {
                        Id = Convert.ToInt32(reader["id"]),
                        CustomerId = Convert.ToInt32(reader["customerId"]),
                        FirstName = reader["firstName"].ToString(),
                        LastName = reader["lastName"].ToString(),
                        Phone = reader["phone"].ToString(),
                        Email = reader["email"].ToString(),
                        CreateAt = DateTime.Parse(reader["createAt"].ToString()),
                        Total = Convert.ToDecimal(reader["total"])
                    };
                    list.Add(hoaDon);
                }
            }

            connect.closeConnection();
            return list;
        }

        // Lấy chi tiết hóa đơn theo ID
        public HoaDon GetHoaDonById(int id)
        {
            connect.openConnection();
            HoaDon hoaDon = null;

            using (SqlCommand command = new SqlCommand())
            {
                command.Connection = connect.getConnecttion();
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = @"SELECT id, customerId, firstName, lastName, phone, email, createAt, total FROM payment WHERE id = @id";
                command.Parameters.AddWithValue("@id", id);

                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    hoaDon = new HoaDon
                    {
                        Id = Convert.ToInt32(reader["id"]),
                        CustomerId = Convert.ToInt32(reader["customerId"]),
                        FirstName = reader["firstName"].ToString(),
                        LastName = reader["lastName"].ToString(),
                        Phone = reader["phone"].ToString(),
                        Email = reader["email"].ToString(),
                        CreateAt = DateTime.Parse(reader["createAt"].ToString()),
                        Total = Convert.ToDecimal(reader["total"])
                    };
                }
            }

            connect.closeConnection();
            return hoaDon;
        }

        // Lấy danh sách chi tiết hóa đơn (product details)
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

        // Lấy chi tiết hóa đơn theo ID
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
