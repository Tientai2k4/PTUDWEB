using Microsoft.AspNetCore.Mvc;
using ShopManager.Areas.Admin.DAL;
using ShopManager.Areas.Admin.Models;

namespace ShopManager.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class KhachHangController : Controller
    {
        private readonly KhachHangDAL khachHangDAL = new KhachHangDAL();

        // GET: KhachHang
        public IActionResult Index()
        {
            var khachHangs = khachHangDAL.GetAllKhachHangs();
            return View(khachHangs);
        }

        // GET: KhachHang/Details/5
        public IActionResult Details(int id)
        {
            var khachHang = khachHangDAL.GetKhachHangById(id);
            if (khachHang == null)
            {
                return NotFound();
            }
            return View(khachHang);
        }

        // GET: KhachHang/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: KhachHang/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("FirstName, LastName, Address, Phone, Email, IsActive")] KhachHang khachHang)
        {
            if (ModelState.IsValid)
            {
                bool isCreated = khachHangDAL.AddNewKhachHang(khachHang);
                if (isCreated)
                {
                    TempData["SuccessMessage"] = "Customer Created Successfully!";
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    TempData["ErrorMessage"] = "Error Creating Customer!";
                }
            }
            return View(khachHang);
        }

        // GET: KhachHang/Edit/5
        public IActionResult Edit(int id)
        {
            var khachHang = khachHangDAL.GetKhachHangById(id);
            if (khachHang == null)
            {
                return NotFound();
            }
            return View(khachHang);
        }

        // POST: KhachHang/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id, FirstName, LastName, Address, Phone, Email, IsActive")] KhachHang khachHang)
        {
            if (id != khachHang.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                bool isUpdated = khachHangDAL.UpdateKhachHang(khachHang);
                if (isUpdated)
                {
                    TempData["SuccessMessage"] = "Customer Updated Successfully!";
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    TempData["ErrorMessage"] = "Error Updating Customer!";
                }
            }
            return View(khachHang);
        }

        // GET: KhachHang/Delete/5
        public IActionResult Delete(int id)
        {
            var khachHang = khachHangDAL.GetKhachHangById(id);
            if (khachHang == null)
            {
                return NotFound();
            }
            return View(khachHang);
        }

        // POST: KhachHang/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            bool isDeleted = khachHangDAL.DeleteKhachHang(id);
            if (isDeleted)
            {
                TempData["SuccessMessage"] = "Customer Deleted Successfully!";
            }
            else
            {
                TempData["ErrorMessage"] = "Error Deleting Customer!";
            }
            return RedirectToAction(nameof(Index));
        }

        // Cập nhật quyền và trạng thái của khách hàng
        [HttpGet]
        public IActionResult UpdateRole(int id)
        {
            var khachHang = khachHangDAL.GetKhachHangById(id);
            if (khachHang == null)
            {
                return NotFound();
            }

            // Tạo view để chọn quyền (isActive và role)
            return View(khachHang);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdateRole(int id, bool isActive, int role)
        {
            var khachHang = khachHangDAL.GetKhachHangById(id);
            if (khachHang == null)
            {
                return NotFound();
            }

            // Cập nhật quyền và trạng thái
            khachHang.IsActive = isActive;
            khachHang.Role = role;

            bool isUpdated = khachHangDAL.UpdateKhachHang(khachHang);
            if (isUpdated)
            {
                TempData["SuccessMessage"] = "Customer's Role Updated Successfully!";
            }
            else
            {
                TempData["ErrorMessage"] = "Error Updating Customer's Role!";
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
