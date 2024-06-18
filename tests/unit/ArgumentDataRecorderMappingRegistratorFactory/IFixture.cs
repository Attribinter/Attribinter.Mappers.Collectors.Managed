namespace Paraminter.Recorders.Mappers.Collectors.Managed;

using Moq;

internal interface IFixture
{
    public abstract IArgumentDataRecorderMappingRegistratorFactory Sut { get; }

    public abstract Mock<IManagedArgumentDataRecorderMappingRegistratorContextFactory> ContextFactoryMock { get; }
}
