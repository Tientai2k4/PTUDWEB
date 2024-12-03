using Microsoft.Data.SqlClient;
using ShopManager.Areas.Admin.Models;
using ShopManager.Database;

namespace ShopManager.Areas.Admin.DAL
{
    public class DashboardDAL
    {
        private readonly DBConnect _connect = new DBConnect();

        // Phương thức lấy dữ liệu tổng quan cho Dashboard
        public DashboardData GetDashboardData()
        {
            DashboardData data = new DashboardData();

            _connect.openConnection();

            using (SqlCommand command = new SqlCommand())
            {
                command.Connection = _connect.getConnecttion();
                command.CommandType = System.Data.CommandType.Text;

                // Lấy tổng số khách hàng
                command.CommandText = @"SELECT COUNT(*) AS TotalCustomers FROM customer";
                data.TotalCustomers = (int)command.ExecuteScalar();

                // Lấy tổng số sản phẩm
                command.CommandText = @"SELECT COUNT(*) AS TotalProducts FROM product";
                data.TotalProducts = (int)command.ExecuteScalar();

                // Lấy tổng doanh thu
                command.CommandText = @"SELECT SUM(total) AS TotalRevenue FROM payment";
                data.TotalRevenue = Convert.ToDecimal(command.ExecuteScalar());

                // Lấy tổng số đơn hàng
                command.CommandText = @"SELECT COUNT(*) AS TotalOrders FROM payment";
                data.TotalOrders = (int)command.ExecuteScalar();
            }

            _connect.closeConnection();
            return data;
        }
    }
}
