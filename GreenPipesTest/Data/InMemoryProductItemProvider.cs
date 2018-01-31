namespace GreenPipesTest.Data
{
	using System;
	using System.Collections.Generic;
	using Model;

    public class InMemoryProductItemProvider : List<ProductItem>, IProductItemProvider
    {
	    public InMemoryProductItemProvider()
		    : base(new[]
		    {
			    new ProductItem {Id = Guid.NewGuid(), Cost = 1.99, Weight = 0.75},
			    new ProductItem {Id = Guid.NewGuid(), Cost = 2.50, Weight = 1.20},
			    new ProductItem {Id = Guid.NewGuid(), Cost = 8.12, Weight = 2.45}
			})
	    {
	    }

	    public IEnumerable<ProductItem> AllProductItems()
	    {
		    using (var enumerator = GetEnumerator())
		    {
			    while (enumerator.MoveNext())
			    {
					yield return enumerator.Current;
				}
			}
	    }

	    public ProductItem GetProductItem(Guid id)
	    {
		    return Find(item => item.Id == id);
	    }
    }
}
