using Microsoft.AspNetCore.Mvc;
using ShopManager.Areas.Admin.DAL;
using ShopManager.Areas.Admin.Models;

namespace ShopManager.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HoaDonController : Controller
    {
        private readonly HoaDonDAL hoaDonDAL = new HoaDonDAL();

        // Hiển thị danh sách hóa đơn
        public IActionResult Index()
        {
            var hoaDons = hoaDonDAL.GetHoaDons();  // Sử dụng GetHoaDons() để lấy danh sách hóa đơn
            return View(hoaDons);
        }

        // Xem chi tiết hóa đơn
        public IActionResult Details(int id)
        {
            var hoaDon = hoaDonDAL.GetHoaDonById(id);
            return View(hoaDon);
        }
    }
}
