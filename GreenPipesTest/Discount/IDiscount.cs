namespace GreenPipesTest.Discount
{
	using Model;

	public interface IDiscount
	{
		bool IsEligibleForDiscount(ShoppingCart shoppingCart);

		void ApplyDiscount(ShoppingCart shoppingCart);
	}
}
