namespace Paraminter.Recorders.Mappers.Collectors.Managed.ArgumentDataRecorderMappingRegistratorFactoryCases;

using Moq;

internal interface IFactoryFixture
{
    public abstract IArgumentDataRecorderMappingRegistratorFactory Sut { get; }

    public abstract Mock<IManagedArgumentDataRecorderMappingRegistratorContextFactory> ContextFactoryMock { get; }
}
