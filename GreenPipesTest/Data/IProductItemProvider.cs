namespace GreenPipesTest.Data
{
	using System;
	using System.Collections.Generic;
	using Model;

	public interface IProductItemProvider
	{
		IEnumerable<ProductItem> AllProductItems();

		ProductItem GetProductItem(Guid id);
	}
}