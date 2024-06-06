namespace Paraminter.Recorders.Mappers.Collectors.Managed.ManagedArgumentExistenceRecorderMappingRegistratorContextFactoryCases.ManagedArgumentExistenceRecorderMappingRegistratorContextCases;

using Moq;

internal interface IContextFixture<TParameter, TRecord, TParameterFactory, TRecorderFactory>
    where TParameterFactory : class
    where TRecorderFactory : class
{
    public abstract IManagedArgumentExistenceRecorderMappingRegistratorContext<TParameter, TRecord, TParameterFactory, TRecorderFactory> Sut { get; }

    public abstract Mock<IArgumentExistenceRecorderMappingCollector<TParameter, TRecord>> CollectorMock { get; }

    public abstract Mock<TParameterFactory> ParameterFactoryMock { get; }
    public abstract Mock<TRecorderFactory> RecorderFactoryMock { get; }
}
