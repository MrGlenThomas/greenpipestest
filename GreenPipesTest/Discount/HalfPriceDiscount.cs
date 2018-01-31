namespace GreenPipesTest.Discount
{
	using System;
	using Data;
	using Model;

	public class HalfPriceDiscount : IDiscount
	{
		private readonly IProductItemProvider _productItemProvider;

		public DateTime? ExpiryDate => DateTime.Now.AddMonths(1);

		public string DiscountCode => "50PERCENTOFFSALE";

		public HalfPriceDiscount(IProductItemProvider productItemProvider)
		{
			_productItemProvider = productItemProvider;
		}

		public bool IsEligibleForDiscount(ShoppingCart shoppingCart)
		{
			var discountCodeMatches = shoppingCart.DiscountCode.Equals(DiscountCode, StringComparison.InvariantCultureIgnoreCase);

			var discountHasExpired = ExpiryDate < DateTime.Now;

			var itemsTotalGreaterThan20 = shoppingCart.ItemsTotalCost >= 20;

			return discountCodeMatches && !discountHasExpired && itemsTotalGreaterThan20;
		}

		public void ApplyDiscount(ShoppingCart shoppingCart)
		{
			double totalDiscount = 0;

			foreach (var shoppingCartProductItem in shoppingCart.Items)
			{
				var productItem = _productItemProvider.GetProductItem(shoppingCartProductItem.ProductId);

				if (productItem.IsOnSale) continue;

				totalDiscount += (productItem.Cost * shoppingCartProductItem.Quantity) / 2;
			}

			shoppingCart.TotalDiscount = totalDiscount;
			shoppingCart.TotalCost -= totalDiscount;
		}
	}
}
