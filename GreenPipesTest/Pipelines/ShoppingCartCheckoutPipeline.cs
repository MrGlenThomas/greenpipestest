namespace GreenPipesTest.Pipelines
{
	using Configuration;
	using Data;
	using Discount;
	using Filters;
	using Formatting;
	using GreenPipes;
	using Model;

	public class ShoppingCartCheckoutPipeline : IShoppingCartPipeline
	{
		private readonly IProductItemProvider _productItemProvider;
		private readonly IStoreOptions _storeOptions;
		private readonly IShoppingCartFormatter _shoppingCartFormatter;
		private readonly IDiscountProvider _discountProvider;

		public ShoppingCartCheckoutPipeline(IProductItemProvider productItemProvider, IStoreOptions storeOptions,
			IShoppingCartFormatter shoppingCartFormatter, IDiscountProvider discountProvider)
		{
			_productItemProvider = productItemProvider;
			_storeOptions = storeOptions;
			_shoppingCartFormatter = shoppingCartFormatter;
			_discountProvider = discountProvider;
		}

		public IPipe<ShoppingCart> Build()
		{
			var pipeline = Pipe.New<ShoppingCart>(x =>
			{
				x.UseFilter(new CalculateItemsTotalFilter(_productItemProvider));
				x.UseFilter(new CalculateShippingCostFilter(_productItemProvider, _storeOptions));
				x.UseFilter(new CalculateTotalFilter());
				x.UseFilter(new ApplyDiscountFilter(_discountProvider));
				x.UseFilter(new ConsoleWriterFilter(_shoppingCartFormatter));
			});

			return pipeline;
		}
	}
}
