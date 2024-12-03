using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopManager.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Img { get; set; }
        public int Price { get; set; }
        public double Rate { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime UpdateAt { get; set; }
        public int CategoryId { get; set; }
        public string CategoryTitle { get; set; }
    }
	public class ProductPagination
	{
		public List<Product> Products { get; set; }
		public int CurrentPageIndex { get; set; }
		public int PageCount { get; set; }
	}
}
