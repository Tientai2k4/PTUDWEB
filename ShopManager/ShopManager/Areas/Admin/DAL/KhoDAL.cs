using Microsoft.Data.SqlClient;
using ShopManager.Areas.Admin.Models;
using ShopManager.Database;
using System.Collections.Generic;

namespace ShopManager.Areas.Admin.DAL
{
    public class KhoDAL
    {
        private readonly DBConnect connect = new DBConnect();

        public List<Kho> GetAllKho()
        {
            connect.openConnection();
            List<Kho> list = new List<Kho>();

            using (SqlCommand command = new SqlCommand())
            {
                command.Connection = connect.getConnecttion();
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "SELECT * FROM warehouse";

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(new Kho
                    {
                        Id = Convert.ToInt32(reader["id"]),
                        Name = reader["name"].ToString(),
                        Location = reader["location"].ToString(),
                        Capacity = Convert.ToInt32(reader["capacity"]),
                        CurrentStock = Convert.ToInt32(reader["currentStock"])
                    });
                }
            }

            connect.closeConnection();
            return list;
        }

        public Kho GetKhoById(int id)
        {
            connect.openConnection();
            Kho kho = null;

            using (SqlCommand command = new SqlCommand())
            {
                command.Connection = connect.getConnecttion();
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "SELECT * FROM warehouse WHERE id = @id";
                command.Parameters.AddWithValue("@id", id);

                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    kho = new Kho
                    {
                        Id = Convert.ToInt32(reader["id"]),
                        Name = reader["name"].ToString(),
                        Location = reader["location"].ToString(),
                        Capacity = Convert.ToInt32(reader["capacity"]),
                        CurrentStock = Convert.ToInt32(reader["currentStock"])
                    };
                }
            }

            connect.closeConnection();
            return kho;
        }

        public bool AddNewKho(Kho kho)
        {
            connect.openConnection();
            int result;

            using (SqlCommand command = new SqlCommand())
            {
                command.Connection = connect.getConnecttion();
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = @"INSERT INTO warehouse (name, location, capacity, currentStock) 
                                        VALUES (@name, @location, @capacity, @currentStock)";
                command.Parameters.AddWithValue("@name", kho.Name);
                command.Parameters.AddWithValue("@location", kho.Location);
                command.Parameters.AddWithValue("@capacity", kho.Capacity);
                command.Parameters.AddWithValue("@currentStock", kho.CurrentStock);

                result = command.ExecuteNonQuery();
            }

            connect.closeConnection();
            return result > 0;
        }

        public bool UpdateKho(Kho kho)
        {
            connect.openConnection();
            int result;

            using (SqlCommand command = new SqlCommand())
            {
                command.Connection = connect.getConnecttion();
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = @"UPDATE warehouse SET 
                                        name = @name, 
                                        location = @location, 
                                        capacity = @capacity, 
                                        currentStock = @currentStock 
                                        WHERE id = @id";
                command.Parameters.AddWithValue("@id", kho.Id);
                command.Parameters.AddWithValue("@name", kho.Name);
                command.Parameters.AddWithValue("@location", kho.Location);
                command.Parameters.AddWithValue("@capacity", kho.Capacity);
                command.Parameters.AddWithValue("@currentStock", kho.CurrentStock);

                result = command.ExecuteNonQuery();
            }

            connect.closeConnection();
            return result > 0;
        }

        public bool DeleteKho(int id)
        {
            connect.openConnection();
            int result;

            using (SqlCommand command = new SqlCommand())
            {
                command.Connection = connect.getConnecttion();
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "DELETE FROM warehouse WHERE id = @id";
                command.Parameters.AddWithValue("@id", id);

                result = command.ExecuteNonQuery();
            }

            connect.closeConnection();
            return result > 0;
        }
    }
}
