namespace ShopManager.Areas.Admin.Models
{
	public class ProductAdminModel
	{
		///<summary>
		/// Gets or sets the list of ProductAdmin.
		///</summary>
		public List<ProductAdmin> ProductAdmins { get; set; }

		///<summary>
		/// Gets or sets the current page index for pagination.
		///</summary>
		public int CurrentPageIndex { get; set; }

		///<summary>
		/// Gets or sets the total page count for pagination.
		///</summary>
		public int PageCount { get; set; }
	}
}
