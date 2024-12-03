using Microsoft.AspNetCore.Mvc;
using ShopManager.DAL;
using ShopManager.Models;
namespace ThucHanh_TruongCongHuy64130895.ViewComponents
{
    public class RelatedProductViewComponent : ViewComponent
    {
        ProductArrangeDAL arrangeDAL = new ProductArrangeDAL();
        public IViewComponentResult Invoke(int? limit)
        {
            int limitProduct = limit ?? 4;
            List<Product> relatedProducts = new List<Product>();

            relatedProducts = arrangeDAL.GetRelatedProducts(limitProduct);

            return View("RelatedProduct", relatedProducts);
        }
    }
}
