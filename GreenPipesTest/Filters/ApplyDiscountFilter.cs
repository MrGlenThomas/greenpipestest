namespace GreenPipesTest.Filters
{
	using System.Threading.Tasks;
	using Discount;
	using GreenPipes;
	using Model;

	public class ApplyDiscountFilter : IApplyDiscountFilter
    {
	    private readonly IDiscountProvider _discountProvider;

	    public ApplyDiscountFilter(IDiscountProvider discountProvider)
	    {
		    _discountProvider = discountProvider;
	    }

	    public async Task Send(ShoppingCart shoppingCart, IPipe<ShoppingCart> next)
	    {
		    var discount = _discountProvider.GetDiscount(shoppingCart);

		    discount?.ApplyDiscount(shoppingCart);

		    await next.Send(shoppingCart);
	    }

	    public void Probe(ProbeContext context)
	    {
		    throw new System.NotImplementedException();
	    }
    }
}
