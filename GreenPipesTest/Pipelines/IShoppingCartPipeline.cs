namespace GreenPipesTest.Pipelines
{
	using GreenPipes;
	using Model;

	public interface IShoppingCartPipeline
    {
	    IPipe<ShoppingCart> Build();
	}
}
