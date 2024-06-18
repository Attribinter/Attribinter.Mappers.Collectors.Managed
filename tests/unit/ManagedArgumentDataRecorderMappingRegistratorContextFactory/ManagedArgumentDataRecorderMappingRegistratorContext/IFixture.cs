namespace Paraminter.Recorders.Mappers.Collectors.Managed.ManagedArgumentDataRecorderMappingRegistratorContext;

using Moq;

internal interface IFixture<TParameter, TRecord, TArgumentData, TParameterFactory, TRecorderFactory>
    where TParameterFactory : class
    where TRecorderFactory : class
{
    public abstract IManagedArgumentDataRecorderMappingRegistratorContext<TParameter, TRecord, TArgumentData, TParameterFactory, TRecorderFactory> Sut { get; }

    public abstract Mock<IArgumentDataRecorderMappingCollector<TParameter, TRecord, TArgumentData>> CollectorMock { get; }

    public abstract Mock<TParameterFactory> ParameterFactoryMock { get; }
    public abstract Mock<TRecorderFactory> RecorderFactoryMock { get; }
}
