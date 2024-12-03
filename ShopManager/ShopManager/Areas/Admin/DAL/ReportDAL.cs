using Microsoft.Data.SqlClient;
using ShopManager.Areas.Admin.Models;
using ShopManager.Database;
using System.Collections.Generic;
using System.Composition;

namespace ShopManager.Areas.Admin.DAL
{
    public class ReportDAL
    {
        DBConnect connect = new DBConnect();

        public List<Report> GetReports()
        {
            connect.openConnection();
            List<Report> list = new List<Report>();

            using (SqlCommand command = new SqlCommand())
            {
                command.Connection = connect.getConnecttion();
                command.CommandType = System.Data.CommandType.Text;

                // Example query: lấy tổng doanh thu mỗi tháng
                command.CommandText = @"
                    SELECT MONTH(createAt) AS Month, SUM(total) AS TotalRevenue
                    FROM payment
                    GROUP BY MONTH(createAt)
                    ORDER BY MONTH(createAt)";

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Report report = new Report
                    {
                        Month = Convert.ToInt32(reader["Month"]),
                        TotalRevenue = Convert.ToDecimal(reader["TotalRevenue"])
                    };
                    list.Add(report);
                }
            }
            connect.closeConnection();
            return list;
        }
    }
}
