using Microsoft.AspNetCore.Mvc;
using ShopManager.DAL;
using ShopManager.Helper;
using ShopManager.Models;
using System.Runtime.CompilerServices;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace ShopManager.Controllers
{
    public class CartController : Controller
    {
        ProductDAL productDAL = new ProductDAL();
        CustomerDAL customerDAL = new CustomerDAL();
        CartDAL cartDAL = new CartDAL();
        public List<CartItem> Cart => HttpContext.Session.Get<List<CartItem>>(MyConst.CART_KEY) ?? new List<CartItem>();

        public IActionResult Index()
        {
            return View(Cart);
        }

        public IActionResult AddToCart(int id, int quantity = 1)
        {
            var gioHang = Cart;
            var item = gioHang.SingleOrDefault(p => p.IdProduct == id);
            if (item == null)
            {
                Product? productById = productDAL.GetProductById(id);

                if (productById == null)
                {
                    TempData["Message"] = "Khong tim thay san pham";
                    return Redirect("/404");
                }

                item = new CartItem
                {
                    IdProduct = productById.Id,
                    Img = productById.Img,
                    Name = productById.Title,
                    Price = productById.Price,
                    Rate = productById.Rate,
                    Quantity = quantity
                };
                gioHang.Add(item);
            }
            else
            {
                item.Quantity += quantity;
            }

            HttpContext.Session.Set(MyConst.CART_KEY, gioHang);

            return RedirectToAction("Index");
        }

        public IActionResult ChangeQuantityCart(int id, bool isIncrement = true, int quantity = 1)
        {
            var gioHang = Cart;
            var item = gioHang.SingleOrDefault(p => p.IdProduct == id);

            if (item == null)
            {
                TempData["Message"] = "Khong tim thay san pham";
                return Json(new { success = false, message = "Sản phẩm không tồn tại trong giỏ hàng." });
            }
            else
            {
                if (isIncrement)
                {
                    item.Quantity += quantity;
                }
                else
                {
                    item.Quantity -= quantity;
                    if (item.Quantity <= 0)
                    {
                        gioHang.Remove(item);
                    }
                }
            }

            HttpContext.Session.Set(MyConst.CART_KEY, gioHang);

            return Json(new
            {
                success = true,
                newQuantity = item?.Quantity ?? 0,
                productTotal = item?.Total ?? 0,
                totalAmount = gioHang.Sum(x => x.Total)
            });
        }

        public IActionResult RemoveCart(int id)
        {
            var gioHang = Cart;

            var item = gioHang.SingleOrDefault(p => p.IdProduct == id);
            if (item != null)
            {
                gioHang.Remove(item);
                HttpContext.Session.Set(MyConst.CART_KEY, gioHang);
            }

            return Json(new { success = true, totalAmount = gioHang.Sum(x => x.Total) });
        }

        [Authorize]
        public IActionResult CheckOut()
        {
            try
            {
                if (Cart.Count() == 0)
                {
                    TempData["CheckOutErrorMessage"] = "Thanh toán thất bại";
                    return RedirectToAction("Index");
                }

                string? idTam = null;
                if (HttpContext.User.FindFirstValue("CustomerId") != null)
                {
                    idTam = HttpContext.User.FindFirstValue("CustomerId");
                }

                if (idTam == null)
                {
                    return Redirect("/Customer/SignIn");
                }

                int idCustomer = Convert.ToInt32(idTam!);

                Customer? customer = customerDAL.GetCustomerById(idCustomer);

                if (customer == null)
                {
                    return Redirect("/404");
                }

                bool isSuccess = cartDAL.CheckOut(customer, Cart);
                if (isSuccess)
                {
                    TempData["CheckOutSuccessMessage"] = "Thanh toán thành công";

                    var gioHang = Cart;
                    gioHang = new List<CartItem>();
                    HttpContext.Session.Set(MyConst.CART_KEY, gioHang);
                }
                else
                {
                    TempData["CheckOutErrorMessage"] = "Thanh toán thất bại";
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
                TempData["CheckOutErrorMessage"] = "Lỗi hệ thống: " + ex.Message.ToString();
                return RedirectToAction("Index");
            }
        }

        public IActionResult GetTotalAmount()
        {
            int totalAmount = Cart.Sum(item => item.Total);
            return Json(totalAmount);
        }

        public IActionResult RefreshCartViewComponent()
        {
            return ViewComponent("Cart");
        }

        public IActionResult GetTotalProduct(int idProduct)
        {
            var productFind = Cart.Find(item => item.IdProduct == idProduct);

            int totalAmount = 0;
            if (productFind != null)
            {
                totalAmount = productFind.Total;
            }
            return Json(totalAmount);
        }
    }
}
