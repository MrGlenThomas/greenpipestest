namespace GreenPipesTest.Configuration
{
    public interface IStoreOptions
    {
		double BaseShippingRate { get; }

		double ShippingRatePerKg { get; }

	    double FreeShippingThreshold { get; }
	}
}
