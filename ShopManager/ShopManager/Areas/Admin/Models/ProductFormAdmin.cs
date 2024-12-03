using Microsoft.AspNetCore.Mvc.Rendering;

namespace ShopManager.Areas.Admin.Models
{
	public class ProductFormAdmin : ProductAdmin
	{
		// Property to hold the selected category ID as a string (for dropdown selection)
		public string IdCategorySelected { get; set; }

		// List to hold the available categories for the dropdown list in the view
		public List<SelectListItem>? ListCategory { get; set; }
	}
}
