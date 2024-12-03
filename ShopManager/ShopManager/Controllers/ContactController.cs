using Microsoft.AspNetCore.Mvc;

namespace ShopManager.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Contact(string Name, string Email, string Subject, string Message)
        {
            // Thực hiện xử lý dữ liệu liên hệ, ví dụ: gửi email hoặc lưu vào cơ sở dữ liệu
            ViewData["Message"] = "Cảm ơn bạn đã liên hệ! Chúng tôi sẽ phản hồi trong thời gian sớm nhất.";
            return View("Index");
        }

        public IActionResult Contact()
        {
            return View();
        }
    }
}