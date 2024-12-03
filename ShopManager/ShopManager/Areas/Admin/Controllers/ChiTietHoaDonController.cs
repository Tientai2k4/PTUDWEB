using Microsoft.AspNetCore.Mvc;
using ShopManager.Areas.Admin.DAL;
using ShopManager.Areas.Admin.Models;

namespace ShopManager.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ChiTietHoaDonController : Controller
    {
        private readonly HoaDonDAL hoaDonDAL = new HoaDonDAL();

        // Hiển thị danh sách chi tiết hóa đơn
        public IActionResult Index()
        {
            var chiTietHoaDon = hoaDonDAL.GetChiTietHoaDons();
            return View(chiTietHoaDon);
        }

        // Xem chi tiết hóa đơn cụ thể
        public IActionResult Details(int id)
        {
            var chiTiet = hoaDonDAL.GetChiTietHoaDonById(id);
            return View(chiTiet);
        }
    }
}
