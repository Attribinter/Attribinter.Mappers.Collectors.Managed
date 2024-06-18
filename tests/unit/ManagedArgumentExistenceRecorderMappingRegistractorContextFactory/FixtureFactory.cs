namespace Paraminter.Recorders.Mappers.Collectors.Managed;

internal static class FixtureFactory
{
    public static IFixture Create()
    {
        ManagedArgumentExistenceRecorderMappingRegistratorContextFactory sut = new();

        return new Fixture(sut);
    }

    private sealed class Fixture
        : IFixture
    {
        private readonly IManagedArgumentExistenceRecorderMappingRegistratorContextFactory Sut;

        public Fixture(
            IManagedArgumentExistenceRecorderMappingRegistratorContextFactory sut)
        {
            Sut = sut;
        }

        IManagedArgumentExistenceRecorderMappingRegistratorContextFactory IFixture.Sut => Sut;
    }
}
