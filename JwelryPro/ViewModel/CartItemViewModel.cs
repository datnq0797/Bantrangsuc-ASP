using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JwelryPro.ViewModel
{
	public class CartItemViewModel
	{
		
		public int IdProduct { get; set; }
		public int Quantity { get; set; }
		public int Price { get; set; }
		public string Path { get; set; }
		public string Detail { get; set; }
		public string NamePro {get; set;}
	}
}