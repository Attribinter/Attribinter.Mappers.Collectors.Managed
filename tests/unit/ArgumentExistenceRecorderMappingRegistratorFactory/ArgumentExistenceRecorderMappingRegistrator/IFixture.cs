namespace Paraminter.Recorders.Mappers.Collectors.Managed.ArgumentExistenceRecorderMappingRegistrator;

using Moq;

internal interface IFixture<TParameter, TRecord, TParameterFactory, TRecorderFactory>
    where TParameterFactory : class
    where TRecorderFactory : class
{
    public abstract IArgumentExistenceRecorderMappingRegistrator<TParameter, TRecord> Sut { get; }

    public abstract Mock<IManagedArgumentExistenceRecorderMappingRegistratorContextFactory> ContextFactoryMock { get; }

    public abstract Mock<IManagedArgumentExistenceRecorderMappingRegistrator<TParameter, TRecord, TParameterFactory, TRecorderFactory>> ManagedRegistratorMock { get; }

    public abstract Mock<TParameterFactory> ParameterFactoryMock { get; }
    public abstract Mock<TRecorderFactory> RecorderFactoryMock { get; }
}
