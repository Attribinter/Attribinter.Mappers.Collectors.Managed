namespace Paraminter.Mappers.Collectors.Managed.ParameterMappingRegistratorFactoryCases;

using Moq;

internal static class FactoryFixtureFactory
{
    public static IFactoryFixture Create()
    {
        Mock<IManagedParameterMappingRegistratorContextFactory> contextFactoryMock = new();

        ParameterMappingRegistratorFactory sut = new(contextFactoryMock.Object);

        return new FactoryFixture(sut, contextFactoryMock);
    }

    private sealed class FactoryFixture : IFactoryFixture
    {
        private readonly IParameterMappingRegistratorFactory Sut;

        private readonly Mock<IManagedParameterMappingRegistratorContextFactory> ContextFactoryMock;

        public FactoryFixture(IParameterMappingRegistratorFactory sut, Mock<IManagedParameterMappingRegistratorContextFactory> contextFactoryMock)
        {
            Sut = sut;

            ContextFactoryMock = contextFactoryMock;
        }

        IParameterMappingRegistratorFactory IFactoryFixture.Sut => Sut;

        Mock<IManagedParameterMappingRegistratorContextFactory> IFactoryFixture.ContextFactoryMock => ContextFactoryMock;
    }
}
