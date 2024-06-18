namespace Paraminter.Recorders.Mappers.Collectors.Managed;

using Moq;

internal static class FixtureFactory
{
    public static IFixture Create()
    {
        Mock<IManagedArgumentDataRecorderMappingRegistratorContextFactory> contextFactoryMock = new();

        ArgumentDataRecorderMappingRegistratorFactory sut = new(contextFactoryMock.Object);

        return new Fixture(sut, contextFactoryMock);
    }

    private sealed class Fixture
        : IFixture
    {
        private readonly IArgumentDataRecorderMappingRegistratorFactory Sut;

        private readonly Mock<IManagedArgumentDataRecorderMappingRegistratorContextFactory> ContextFactoryMock;

        public Fixture(
            IArgumentDataRecorderMappingRegistratorFactory sut,
            Mock<IManagedArgumentDataRecorderMappingRegistratorContextFactory> contextFactoryMock)
        {
            Sut = sut;

            ContextFactoryMock = contextFactoryMock;
        }

        IArgumentDataRecorderMappingRegistratorFactory IFixture.Sut => Sut;

        Mock<IManagedArgumentDataRecorderMappingRegistratorContextFactory> IFixture.ContextFactoryMock => ContextFactoryMock;
    }
}
