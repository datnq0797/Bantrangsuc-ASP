using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JwelryPro.ViewModel
{
	public class CartViewModel
	{
		public CartViewModel()
		{
			ListItem = new List<CartItemViewModel>();
		}

		public int id { get; set; }
		public string Name { get; set; }
		public string Address { get; set; }
		public string Phone { get; set; }

		public List<CartItemViewModel> ListItem { get; set; }
	}
}