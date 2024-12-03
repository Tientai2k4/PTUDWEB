using Microsoft.Data.SqlClient;
using ShopManager.Areas.Admin.Models;
using ShopManager.Database;
using System.Collections.Generic;

namespace ShopManager.Areas.Admin.DAL
{
    public class KhachHangDAL
    {
        private readonly DBConnect connect = new DBConnect();

        public List<KhachHang> GetAllKhachHangs()
        {
            connect.openConnection();
            List<KhachHang> list = new List<KhachHang>();

            using (SqlCommand command = new SqlCommand())
            {
                command.Connection = connect.getConnecttion();
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "SELECT * FROM customer";

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(new KhachHang
                    {
                        Id = Convert.ToInt32(reader["id"]),
                        FirstName = reader["firstName"].ToString(),
                        LastName = reader["lastName"].ToString(),
                        Address = reader["address"].ToString(),
                        Phone = reader["phone"].ToString(),
                        Email = reader["email"].ToString(),
                        IsActive = Convert.ToBoolean(reader["isActive"]),
                        Role = Convert.ToInt32(reader["role"])
                    });
                }
            }

            connect.closeConnection();
            return list;
        }

        public KhachHang GetKhachHangById(int id)
        {
            connect.openConnection();
            KhachHang khachHang = null;

            using (SqlCommand command = new SqlCommand())
            {
                command.Connection = connect.getConnecttion();
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "SELECT * FROM customer WHERE id = @id";
                command.Parameters.AddWithValue("@id", id);

                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    khachHang = new KhachHang
                    {
                        Id = Convert.ToInt32(reader["id"]),
                        FirstName = reader["firstName"].ToString(),
                        LastName = reader["lastName"].ToString(),
                        Address = reader["address"].ToString(),
                        Phone = reader["phone"].ToString(),
                        Email = reader["email"].ToString(),
                        IsActive = Convert.ToBoolean(reader["isActive"]),
                        Role = Convert.ToInt32(reader["role"])
                    };
                }
            }

            connect.closeConnection();
            return khachHang;
        }

        public bool AddNewKhachHang(KhachHang khachHang)
        {
            connect.openConnection();
            int result;

            using (SqlCommand command = new SqlCommand())
            {
                command.Connection = connect.getConnecttion();
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = @"INSERT INTO customer (firstName, lastName, address, phone, email, isActive, role) 
                                        VALUES (@firstName, @lastName, @address, @phone, @email, @isActive, @role)";
                command.Parameters.AddWithValue("@firstName", khachHang.FirstName);
                command.Parameters.AddWithValue("@lastName", khachHang.LastName);
                command.Parameters.AddWithValue("@address", khachHang.Address);
                command.Parameters.AddWithValue("@phone", khachHang.Phone);
                command.Parameters.AddWithValue("@email", khachHang.Email);
                command.Parameters.AddWithValue("@isActive", khachHang.IsActive);
                command.Parameters.AddWithValue("@role", khachHang.Role);

                result = command.ExecuteNonQuery();
            }

            connect.closeConnection();
            return result > 0;
        }

        public bool UpdateKhachHang(KhachHang khachHang)
        {
            connect.openConnection();
            int result;

            using (SqlCommand command = new SqlCommand())
            {
                command.Connection = connect.getConnecttion();
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = @"UPDATE customer SET 
                                        firstName = @firstName, 
                                        lastName = @lastName, 
                                        address = @address, 
                                        phone = @phone, 
                                        email = @email, 
                                        isActive = @isActive, 
                                        role = @role
                                        WHERE id = @id";
                command.Parameters.AddWithValue("@id", khachHang.Id);
                command.Parameters.AddWithValue("@firstName", khachHang.FirstName);
                command.Parameters.AddWithValue("@lastName", khachHang.LastName);
                command.Parameters.AddWithValue("@address", khachHang.Address);
                command.Parameters.AddWithValue("@phone", khachHang.Phone);
                command.Parameters.AddWithValue("@email", khachHang.Email);
                command.Parameters.AddWithValue("@isActive", khachHang.IsActive);
                command.Parameters.AddWithValue("@role", khachHang.Role);

                result = command.ExecuteNonQuery();
            }

            connect.closeConnection();
            return result > 0;
        }

        public bool DeleteKhachHang(int id)
        {
            connect.openConnection();
            int result;

            using (SqlCommand command = new SqlCommand())
            {
                command.Connection = connect.getConnecttion();
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "DELETE FROM customer WHERE id = @id";
                command.Parameters.AddWithValue("@id", id);

                result = command.ExecuteNonQuery();
            }

            connect.closeConnection();
            return result > 0;
        }
    }
}
