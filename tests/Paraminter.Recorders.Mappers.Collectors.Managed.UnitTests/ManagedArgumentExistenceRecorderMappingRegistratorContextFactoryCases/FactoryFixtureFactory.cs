namespace Paraminter.Recorders.Mappers.Collectors.Managed.ManagedArgumentExistenceRecorderMappingRegistratorContextFactoryCases;

internal static class FactoryFixtureFactory
{
    public static IFactoryFixture Create()
    {
        ManagedArgumentExistenceRecorderMappingRegistratorContextFactory sut = new();

        return new FactoryFixture(sut);
    }

    private sealed class FactoryFixture
        : IFactoryFixture
    {
        private readonly IManagedArgumentExistenceRecorderMappingRegistratorContextFactory Sut;

        public FactoryFixture(
            IManagedArgumentExistenceRecorderMappingRegistratorContextFactory sut)
        {
            Sut = sut;
        }

        IManagedArgumentExistenceRecorderMappingRegistratorContextFactory IFactoryFixture.Sut => Sut;
    }
}
