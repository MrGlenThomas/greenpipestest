namespace GreenPipesTest.Model
{
	using System;
	using System.Collections.Generic;
	using GreenPipes;

	public class ShoppingCart : BasePipeContext, IShoppingCart
	{
		public Guid Id { get; set; }

		public Guid CustomerId { get; set; }

		public IEnumerable<ShoppingCartProductItem> Items { get; set; }

		public double ItemsTotalCost { get; set; }

		public double ShippingCost { get; set; }

		public double TotalCost { get; set; }
	}
}
