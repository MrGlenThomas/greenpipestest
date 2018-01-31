namespace GreenPipesTest.Discount
{
	using Model;

	public interface IDiscountProvider
	{
		IDiscount GetDiscount(ShoppingCart shoppingCart);
	}
}
