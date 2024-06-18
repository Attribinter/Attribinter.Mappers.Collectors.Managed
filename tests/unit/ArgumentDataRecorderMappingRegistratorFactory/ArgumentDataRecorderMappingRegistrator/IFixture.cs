namespace Paraminter.Recorders.Mappers.Collectors.Managed.ArgumentDataRecorderMappingRegistrator;

using Moq;

internal interface IFixture<TParameter, TRecord, TArgumentData, TParameterFactory, TRecorderFactory>
    where TParameterFactory : class
    where TRecorderFactory : class
{
    public abstract IArgumentDataRecorderMappingRegistrator<TParameter, TRecord, TArgumentData> Sut { get; }

    public abstract Mock<IManagedArgumentDataRecorderMappingRegistratorContextFactory> ContextFactoryMock { get; }

    public abstract Mock<IManagedArgumentDataRecorderMappingRegistrator<TParameter, TRecord, TArgumentData, TParameterFactory, TRecorderFactory>> ManagedRegistratorMock { get; }

    public abstract Mock<TParameterFactory> ParameterFactoryMock { get; }
    public abstract Mock<TRecorderFactory> RecorderFactoryMock { get; }
}
