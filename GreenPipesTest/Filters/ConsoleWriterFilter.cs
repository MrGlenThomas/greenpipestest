namespace GreenPipesTest.Filters
{
	using System;
	using System.Threading.Tasks;
	using Formatting;
	using GreenPipes;
	using Model;

	public class ConsoleWriterFilter : IConsoleWriterFilter
	{
		private readonly IShoppingCartFormatter _shoppingCartFormatter;

		public ConsoleWriterFilter(IShoppingCartFormatter shoppingCartFormatter)
		{
			_shoppingCartFormatter = shoppingCartFormatter;
		}

		public async Task Send(ShoppingCart shoppingCart, IPipe<ShoppingCart> next)
		{
			var output = _shoppingCartFormatter.Format(shoppingCart);

			Console.Write(output);

			await next.Send(shoppingCart);
		}

		public void Probe(ProbeContext context)
		{
			throw new System.NotImplementedException();
		}
	}
}
