namespace GreenPipesTest.Filters
{
	using System.Threading.Tasks;
	using Configuration;
	using Data;
	using GreenPipes;
	using Model;

    public class CalculateShippingCostFilter : ICalculateShippingCostFilter
	{
	    private readonly IProductItemProvider _productItemProvider;
	    private readonly IStoreOptions _storeOptions;

	    public CalculateShippingCostFilter(IProductItemProvider productItemProvider, IStoreOptions storeOptions)
	    {
		    _productItemProvider = productItemProvider;
		    _storeOptions = storeOptions;
	    }

	    public async Task Send(ShoppingCart shoppingCart, IPipe<ShoppingCart> next)
	    {
		    if (shoppingCart.ItemsTotalCost >= _storeOptions.FreeShippingThreshold)
		    {
			    shoppingCart.ShippingCost = 0;
		    }
		    else
		    {
				double totalShippingCost = _storeOptions.BaseShippingRate;

			    foreach (var shoppingCartProductItem in shoppingCart.Items)
			    {
				    var productItem = _productItemProvider.GetProductItem(shoppingCartProductItem.ProductId);

				    totalShippingCost += productItem.Weight * _storeOptions.ShippingRatePerKg * shoppingCartProductItem.Quantity;
			    }

			    shoppingCart.ShippingCost = totalShippingCost;
			}

		    await next.Send(shoppingCart);
	    }

	    public void Probe(ProbeContext context)
	    {
		    throw new System.NotImplementedException();
	    }
    }
}
