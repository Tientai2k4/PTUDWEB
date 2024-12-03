namespace ShopManager.Areas.Admin.Models
{
    public class HoaDon
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public DateTime CreateAt { get; set; }
        public decimal Total { get; set; }
    }
}
