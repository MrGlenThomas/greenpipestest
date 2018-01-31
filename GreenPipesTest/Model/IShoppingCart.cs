namespace GreenPipesTest.Model
{
	using System;
	using System.Collections.Generic;
	using GreenPipes;

	interface IShoppingCart : PipeContext
    {
	    Guid Id { get; }

	    Guid CustomerId { get; }

	    IEnumerable<ShoppingCartProductItem> Items { get; }

	    double ItemsTotalCost { get; }

	    double ShippingCost { get; }

	    double TotalCost { get; }
	}
}
