namespace GreenPipesTest.Discount
{
	using System.Collections.Generic;
	using Model;

	public class DiscountProvider : List<IDiscount>, IDiscountProvider
	{
		public DiscountProvider(IEnumerable<IDiscount> discounts)
			: base(discounts)
		{
			
		}

		public IDiscount GetDiscount(ShoppingCart shoppingCart)
		{
			return Find(discount => discount.IsEligibleForDiscount(shoppingCart));
		}
	}
}
