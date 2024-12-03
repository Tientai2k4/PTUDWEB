namespace ShopManager.Areas.Admin.Models
{
    public class ChiTietHoaDon
    {
        public int ProductId { get; set; }
        public int PaymentId { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public decimal Total { get; set; }
        public DateTime CreateAt { get; set; }
    }
}
