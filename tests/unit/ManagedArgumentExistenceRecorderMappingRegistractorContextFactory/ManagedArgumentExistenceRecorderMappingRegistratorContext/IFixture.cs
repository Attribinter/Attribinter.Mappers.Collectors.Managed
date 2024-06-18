namespace Paraminter.Recorders.Mappers.Collectors.Managed.ManagedArgumentExistenceRecorderMappingRegistratorContext;

using Moq;

internal interface IFixture<TParameter, TRecord, TParameterFactory, TRecorderFactory>
    where TParameterFactory : class
    where TRecorderFactory : class
{
    public abstract IManagedArgumentExistenceRecorderMappingRegistratorContext<TParameter, TRecord, TParameterFactory, TRecorderFactory> Sut { get; }

    public abstract Mock<IArgumentExistenceRecorderMappingCollector<TParameter, TRecord>> CollectorMock { get; }

    public abstract Mock<TParameterFactory> ParameterFactoryMock { get; }
    public abstract Mock<TRecorderFactory> RecorderFactoryMock { get; }
}
