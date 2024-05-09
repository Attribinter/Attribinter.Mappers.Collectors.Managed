namespace Paraminter.Mappers.Collectors.Managed.ManagedParameterMappingRegistratorContextFactoryCases;

internal static class FactoryFixtureFactory
{
    public static IFactoryFixture Create()
    {
        ManagedParameterMappingRegistratorContextFactory sut = new();

        return new FactoryFixture(sut);
    }

    private sealed class FactoryFixture : IFactoryFixture
    {
        private readonly IManagedParameterMappingRegistratorContextFactory Sut;

        public FactoryFixture(IManagedParameterMappingRegistratorContextFactory sut)
        {
            Sut = sut;
        }

        IManagedParameterMappingRegistratorContextFactory IFactoryFixture.Sut => Sut;
    }
}
