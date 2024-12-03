namespace ShopManager.Areas.Admin.Models
{
    public class KhachHang
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; }
        public int Role { get; set; } // Quyền của khách hàng (0: Customer, 1: Admin)
    }
}
