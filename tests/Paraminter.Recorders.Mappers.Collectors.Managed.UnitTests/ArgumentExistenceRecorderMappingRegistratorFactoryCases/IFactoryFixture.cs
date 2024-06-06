namespace Paraminter.Recorders.Mappers.Collectors.Managed.ArgumentExistenceRecorderMappingRegistratorFactoryCases;

using Moq;

internal interface IFactoryFixture
{
    public abstract IArgumentExistenceRecorderMappingRegistratorFactory Sut { get; }

    public abstract Mock<IManagedArgumentExistenceRecorderMappingRegistratorContextFactory> ContextFactoryMock { get; }
}
