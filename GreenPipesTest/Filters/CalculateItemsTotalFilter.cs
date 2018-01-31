namespace GreenPipesTest.Filters
{
	using System.Threading.Tasks;
	using Data;
	using GreenPipes;
	using Model;

    public class CalculateItemsTotalFilter : ICalculateItemsTotalFilter
	{
	    private readonly IProductItemProvider _productItemProvider;

	    public CalculateItemsTotalFilter(IProductItemProvider productItemProvider)
	    {
		    _productItemProvider = productItemProvider;
	    }

	    public async Task Send(ShoppingCart shoppingCart, IPipe<ShoppingCart> next)
	    {
		    double totalCost = 0d;

		    foreach (var shoppingCartProductItem in shoppingCart.Items)
		    {
			    var productItem = _productItemProvider.GetProductItem(shoppingCartProductItem.ProductId);

			    totalCost += productItem.Cost * shoppingCartProductItem.Quantity;
		    }

		    shoppingCart.ItemsTotalCost = totalCost;

		    await next.Send(shoppingCart);
	    }

	    public void Probe(ProbeContext context)
	    {
		    throw new System.NotImplementedException();
	    }
    }
}
