using Microsoft.AspNetCore.Mvc;
using ShopManager.Areas.Admin.DAL;

namespace ShopManager.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ReportController : Controller
    {
        private readonly ReportDAL reportDAL = new ReportDAL();

        public IActionResult Index()
        {
            var reportData = reportDAL.GetReports();
            return View(reportData);
        }
    }
}
