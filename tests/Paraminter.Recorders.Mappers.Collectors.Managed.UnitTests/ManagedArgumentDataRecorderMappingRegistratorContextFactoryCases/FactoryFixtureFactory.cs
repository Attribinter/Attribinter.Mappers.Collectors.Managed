namespace Paraminter.Recorders.Mappers.Collectors.Managed.ManagedArgumentDataRecorderMappingRegistratorContextFactoryCases;

internal static class FactoryFixtureFactory
{
    public static IFactoryFixture Create()
    {
        ManagedArgumentDataRecorderMappingRegistratorContextFactory sut = new();

        return new FactoryFixture(sut);
    }

    private sealed class FactoryFixture
        : IFactoryFixture
    {
        private readonly IManagedArgumentDataRecorderMappingRegistratorContextFactory Sut;

        public FactoryFixture(
            IManagedArgumentDataRecorderMappingRegistratorContextFactory sut)
        {
            Sut = sut;
        }

        IManagedArgumentDataRecorderMappingRegistratorContextFactory IFactoryFixture.Sut => Sut;
    }
}
