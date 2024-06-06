namespace Paraminter.Recorders.Mappers.Collectors.Managed.ArgumentDataRecorderMappingRegistratorFactoryCases;

using Moq;

internal static class FactoryFixtureFactory
{
    public static IFactoryFixture Create()
    {
        Mock<IManagedArgumentDataRecorderMappingRegistratorContextFactory> contextFactoryMock = new();

        ArgumentDataRecorderMappingRegistratorFactory sut = new(contextFactoryMock.Object);

        return new FactoryFixture(sut, contextFactoryMock);
    }

    private sealed class FactoryFixture
        : IFactoryFixture
    {
        private readonly IArgumentDataRecorderMappingRegistratorFactory Sut;

        private readonly Mock<IManagedArgumentDataRecorderMappingRegistratorContextFactory> ContextFactoryMock;

        public FactoryFixture(
            IArgumentDataRecorderMappingRegistratorFactory sut,
            Mock<IManagedArgumentDataRecorderMappingRegistratorContextFactory> contextFactoryMock)
        {
            Sut = sut;

            ContextFactoryMock = contextFactoryMock;
        }

        IArgumentDataRecorderMappingRegistratorFactory IFactoryFixture.Sut => Sut;

        Mock<IManagedArgumentDataRecorderMappingRegistratorContextFactory> IFactoryFixture.ContextFactoryMock => ContextFactoryMock;
    }
}
