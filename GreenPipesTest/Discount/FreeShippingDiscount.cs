namespace GreenPipesTest.Discount
{
	using System;
	using Model;

	public class FreeShippingDiscount : IDiscount
	{
		public DateTime? ExpiryDate => DateTime.Now.AddMonths(1);

		public string DiscountCode => "FREESHIPPING";

		public bool IsEligibleForDiscount(ShoppingCart shoppingCart)
		{
			var discountCodeMatches = shoppingCart.DiscountCode.Equals(DiscountCode, StringComparison.InvariantCultureIgnoreCase);

			var discountHasExpired = ExpiryDate < DateTime.Now;

			return discountCodeMatches && !discountHasExpired;
		}

		public void ApplyDiscount(ShoppingCart shoppingCart)
		{
			shoppingCart.TotalCost -= shoppingCart.ShippingCost;
			shoppingCart.ShippingCost = 0;
		}
	}
}
