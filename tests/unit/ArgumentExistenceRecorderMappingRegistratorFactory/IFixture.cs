namespace Paraminter.Recorders.Mappers.Collectors.Managed;

using Moq;

internal interface IFixture
{
    public abstract IArgumentExistenceRecorderMappingRegistratorFactory Sut { get; }

    public abstract Mock<IManagedArgumentExistenceRecorderMappingRegistratorContextFactory> ContextFactoryMock { get; }
}
