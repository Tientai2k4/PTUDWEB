using System.ComponentModel.DataAnnotations;

namespace ShopManager.Areas.Admin.Models
{
    public class Kho
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Tên kho không được để trống")]
        [MaxLength(100, ErrorMessage = "Tên kho không được vượt quá 100 ký tự")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Vị trí không được để trống")]
        [MaxLength(200, ErrorMessage = "Vị trí không được vượt quá 200 ký tự")]
        public string Location { get; set; }

        [Required(ErrorMessage = "Sức chứa không được để trống")]
        [Range(1, int.MaxValue, ErrorMessage = "Sức chứa phải lớn hơn 0")]
        public int Capacity { get; set; }

        [Required(ErrorMessage = "Tồn kho hiện tại không được để trống")]
        [Range(0, int.MaxValue, ErrorMessage = "Tồn kho phải là số không âm")]
        public int CurrentStock { get; set; }
    }
}
