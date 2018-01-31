namespace GreenPipesTest
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using Data;
	using Model;
	using Pipelines;
	using Registry;

	internal class Program
    {
	    private static void Main()
        {
	        var container = new StructureMapRegistry().BuildContainer();

	        var productItemProvider = container.GetInstance<IProductItemProvider>();

	        var shoppingCart = new ShoppingCart
	        {
		        Id = Guid.NewGuid(),
		        CustomerId = Guid.NewGuid(),
		        Items = new List<ShoppingCartProductItem>(productItemProvider.AllProductItems()
			        .Select(item => new ShoppingCartProductItem {ProductId = item.Id, Quantity = 2})).ToArray()
	        };

	        var pipeline = container.GetInstance<IShoppingCartPipeline>().Build();
			
			pipeline.Send(shoppingCart);

	        Console.ReadKey();
        }
    }
}
