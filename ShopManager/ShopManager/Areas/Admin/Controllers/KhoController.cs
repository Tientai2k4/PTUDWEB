using Microsoft.AspNetCore.Mvc;
using ShopManager.Areas.Admin.DAL;
using ShopManager.Areas.Admin.Models;

namespace ShopManager.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class KhoController : Controller
    {
        private readonly KhoDAL khoDAL = new KhoDAL();

        // GET: Kho
        public IActionResult Index()
        {
            var danhSachKho = khoDAL.GetAllKho();
            return View(danhSachKho);
        }

        // GET: Kho/Details/5
        public IActionResult Details(int id)
        {
            var kho = khoDAL.GetKhoById(id);
            if (kho == null)
            {
                return NotFound();
            }
            return View(kho);
        }

        // GET: Kho/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Kho/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Name, Location, Capacity, CurrentStock")] Kho kho)
        {
            if (ModelState.IsValid)
            {
                bool isCreated = khoDAL.AddNewKho(kho);
                if (isCreated)
                {
                    TempData["SuccessMessage"] = "Warehouse Created Successfully!";
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    TempData["ErrorMessage"] = "Error Creating Warehouse!";
                }
            }
            return View(kho);
        }

        // GET: Kho/Edit/5
        public IActionResult Edit(int id)
        {
            var kho = khoDAL.GetKhoById(id);
            if (kho == null)
            {
                return NotFound();
            }
            return View(kho);
        }

        // POST: Kho/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id, Name, Location, Capacity, CurrentStock")] Kho kho)
        {
            if (id != kho.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                bool isUpdated = khoDAL.UpdateKho(kho);
                if (isUpdated)
                {
                    TempData["SuccessMessage"] = "Warehouse Updated Successfully!";
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    TempData["ErrorMessage"] = "Error Updating Warehouse!";
                }
            }
            return View(kho);
        }

        // GET: Kho/Delete/5
        public IActionResult Delete(int id)
        {
            var kho = khoDAL.GetKhoById(id);
            if (kho == null)
            {
                return NotFound();
            }
            return View(kho);
        }
        // POST: Kho/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            bool isDeleted = khoDAL.DeleteKho(id);
            if (isDeleted)
            {
                TempData["SuccessMessage"] = "Warehouse Deleted Successfully!";
            }
            else
            {
                TempData["ErrorMessage"] = "Error Deleting Warehouse!";
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
