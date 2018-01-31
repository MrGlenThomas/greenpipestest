namespace GreenPipesTest.Registry
{
	using Configuration;
	using Data;
	using Discount;
	using Pipelines;
	using StructureMap;

	internal class StructureMapRegistry
    {
	    public IContainer BuildContainer()
	    {
			var container = new Container(_ =>
			{
				_.Scan(x =>
				{
					x.TheCallingAssembly();
					x.WithDefaultConventions();
					x.AddAllTypesOf<IDiscount>();
				});

				_.For<IStoreOptions>().Use<InMemoryStoreOptions>();
				_.For<IProductItemProvider>().Use<InMemoryProductItemProvider>().Singleton();
				_.For<IShoppingCartPipeline>().Use<ShoppingCartCheckoutPipeline>();
			});

		    return container;
	    }
    }
}
