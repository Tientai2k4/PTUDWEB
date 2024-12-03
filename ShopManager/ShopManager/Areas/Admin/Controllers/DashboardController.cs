using Microsoft.AspNetCore.Mvc;
using ShopManager.Areas.Admin.DAL;
using ShopManager.Areas.Admin.Models;

namespace ShopManager.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DashboardController : Controller
    {
        private readonly DashboardDAL _dashboardDAL = new DashboardDAL();

        public IActionResult Index()
        {
            // Lấy dữ liệu từ DAL
            DashboardData dashboardData = _dashboardDAL.GetDashboardData();

            // Trả về view và truyền dữ liệu vào
            return View(dashboardData);
        }
    }
}
