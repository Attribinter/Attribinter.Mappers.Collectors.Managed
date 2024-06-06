namespace Paraminter.Recorders.Mappers.Collectors.Managed.ArgumentExistenceRecorderMappingRegistratorFactoryCases;

using Moq;

internal static class FactoryFixtureFactory
{
    public static IFactoryFixture Create()
    {
        Mock<IManagedArgumentExistenceRecorderMappingRegistratorContextFactory> contextFactoryMock = new();

        ArgumentExistenceRecorderMappingRegistratorFactory sut = new(contextFactoryMock.Object);

        return new FactoryFixture(sut, contextFactoryMock);
    }

    private sealed class FactoryFixture
        : IFactoryFixture
    {
        private readonly IArgumentExistenceRecorderMappingRegistratorFactory Sut;

        private readonly Mock<IManagedArgumentExistenceRecorderMappingRegistratorContextFactory> ContextFactoryMock;

        public FactoryFixture(
            IArgumentExistenceRecorderMappingRegistratorFactory sut,
            Mock<IManagedArgumentExistenceRecorderMappingRegistratorContextFactory> contextFactoryMock)
        {
            Sut = sut;

            ContextFactoryMock = contextFactoryMock;
        }

        IArgumentExistenceRecorderMappingRegistratorFactory IFactoryFixture.Sut => Sut;

        Mock<IManagedArgumentExistenceRecorderMappingRegistratorContextFactory> IFactoryFixture.ContextFactoryMock => ContextFactoryMock;
    }
}
