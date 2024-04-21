namespace Attribinter.Mappers.Collectors.Managed.ManagedParameterMappingRegistratorContextFactoryCases.ManagedParameterMappingRegistratorContextCases;

using Moq;

internal interface IContextFixture<TParameter, TRecord, TData, TParameterFactory, TRecorderFactory> where TParameterFactory : class where TRecorderFactory : class
{
    public abstract IManagedParameterMappingRegistratorContext<TParameter, TRecord, TData, TParameterFactory, TRecorderFactory> Sut { get; }

    public abstract Mock<IParameterMappingCollector<TParameter, TRecord, TData>> CollectorMock { get; }

    public abstract Mock<TParameterFactory> ParameterFactoryMock { get; }
    public abstract Mock<TRecorderFactory> RecorderFactoryMock { get; }
}
