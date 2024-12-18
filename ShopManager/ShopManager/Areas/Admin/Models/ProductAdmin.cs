﻿using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace ShopManager.Areas.Admin.Models
{
	public class ProductAdmin
	{
		[Key]
		public int Id { get; set; }

		[Display(Name = "Title")]
		[Required(ErrorMessage = "*")]
		[MaxLength(100, ErrorMessage = "Tối đa 100 kí tự")]
		public string Title { get; set; }

		[Display(Name = "Content")]
		[Required(ErrorMessage = "*")]
		[MaxLength(500, ErrorMessage = "Tối đa 500 kí tự")]
		public string Content { get; set; }

		[Display(Name = "Image")]
		public string Img { get; set; }

		[Display(Name = "Price")]
		[Required(ErrorMessage = "*")]
		public int Price { get; set; }

		[Display(Name = "Rating")]
		[Required(ErrorMessage = "*")]
		public double Rate { get; set; }

		[Display(Name = "Create At")]
		public DateTime CreateAt { get; set; }

		[Display(Name = "Update At")]
		public DateTime UpdateAt { get; set; }

		[Display(Name = "Category Id")]
		[Required(ErrorMessage = "*")]
		public int CategoryId { get; set; }

		[Display(Name = "Category Title")]
		[Required(ErrorMessage = "*")]
		public string CategoryTitle { get; set; }
	}
}
