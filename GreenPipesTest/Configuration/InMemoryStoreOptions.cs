namespace GreenPipesTest.Configuration
{
    public class InMemoryStoreOptions : IStoreOptions
    {
	    public double BaseShippingRate => 5.0;

	    public double ShippingRatePerKg => 2.5;

	    public double FreeShippingThreshold => 30;
    }
}
