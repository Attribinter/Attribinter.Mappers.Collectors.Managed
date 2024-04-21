namespace Attribinter.Mappers.Collectors.Managed.ParameterMappingRegistratorFactoryCases;

using Moq;

internal interface IFactoryFixture
{
    public abstract IParameterMappingRegistratorFactory Sut { get; }

    public abstract Mock<IManagedParameterMappingRegistratorContextFactory> ContextFactoryMock { get; }
}
