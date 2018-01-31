namespace GreenPipesTest.Filters
{
	using System.Threading.Tasks;
	using GreenPipes;
	using Model;

    public class CalculateTotalFilter : ICalculateTotalFilter
	{
	    public async Task Send(ShoppingCart shoppingCart, IPipe<ShoppingCart> next)
	    {
		    double totalCost = shoppingCart.ItemsTotalCost + shoppingCart.ShippingCost;

		    shoppingCart.TotalCost = totalCost;

		    await next.Send(shoppingCart);
	    }

	    public void Probe(ProbeContext context)
	    {
		    throw new System.NotImplementedException();
	    }
    }
}
