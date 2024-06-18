namespace Paraminter.Recorders.Mappers.Collectors.Managed;

internal static class FixtureFactory
{
    public static IFixture Create()
    {
        ManagedArgumentDataRecorderMappingRegistratorContextFactory sut = new();

        return new Fixture(sut);
    }

    private sealed class Fixture
        : IFixture
    {
        private readonly IManagedArgumentDataRecorderMappingRegistratorContextFactory Sut;

        public Fixture(
            IManagedArgumentDataRecorderMappingRegistratorContextFactory sut)
        {
            Sut = sut;
        }

        IManagedArgumentDataRecorderMappingRegistratorContextFactory IFixture.Sut => Sut;
    }
}
