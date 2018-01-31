namespace GreenPipesTest.Formatting
{
	using System.Text;
	using Model;

	public class ShoppingCartFormatter : IShoppingCartFormatter
    {
	    public string Format(ShoppingCart shoppingCart)
	    {
			var output = new StringBuilder();
		    output.AppendLine($"ID: {shoppingCart.Id}");
		    output.AppendLine($"Customer ID: {shoppingCart.CustomerId}");
		    output.AppendLine($"Items Cost: £{shoppingCart.ItemsTotalCost}");
		    output.AppendLine($"Shipping Cost: £{shoppingCart.ShippingCost}");
		    output.AppendLine($"Total Cost: £{shoppingCart.TotalCost}");

		    return output.ToString();
	    }
    }
}
