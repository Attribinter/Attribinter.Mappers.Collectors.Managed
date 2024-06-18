namespace Paraminter.Recorders.Mappers.Collectors.Managed;

using Moq;

internal static class FixtureFactory
{
    public static IFixture Create()
    {
        Mock<IManagedArgumentExistenceRecorderMappingRegistratorContextFactory> contextFactoryMock = new();

        ArgumentExistenceRecorderMappingRegistratorFactory sut = new(contextFactoryMock.Object);

        return new Fixture(sut, contextFactoryMock);
    }

    private sealed class Fixture
        : IFixture
    {
        private readonly IArgumentExistenceRecorderMappingRegistratorFactory Sut;

        private readonly Mock<IManagedArgumentExistenceRecorderMappingRegistratorContextFactory> ContextFactoryMock;

        public Fixture(
            IArgumentExistenceRecorderMappingRegistratorFactory sut,
            Mock<IManagedArgumentExistenceRecorderMappingRegistratorContextFactory> contextFactoryMock)
        {
            Sut = sut;

            ContextFactoryMock = contextFactoryMock;
        }

        IArgumentExistenceRecorderMappingRegistratorFactory IFixture.Sut => Sut;

        Mock<IManagedArgumentExistenceRecorderMappingRegistratorContextFactory> IFixture.ContextFactoryMock => ContextFactoryMock;
    }
}
