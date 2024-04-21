namespace Attribinter.Mappers.Collectors.Managed.ParameterMappingRegistratorFactoryCases.ParameterMappingRegistratorCases;

using Moq;

internal interface IRegistratorFixture<TParameter, TRecord, TData, TParameterFactory, TRecorderFactory> where TParameterFactory : class where TRecorderFactory : class
{
    public abstract IParameterMappingRegistrator<TParameter, TRecord, TData> Sut { get; }

    public abstract Mock<IManagedParameterMappingRegistratorContextFactory> ContextFactoryMock { get; }

    public abstract Mock<IManagedParameterMappingRegistrator<TParameter, TRecord, TData, TParameterFactory, TRecorderFactory>> ManagedRegistratorMock { get; }

    public abstract Mock<TParameterFactory> ParameterFactoryMock { get; }
    public abstract Mock<TRecorderFactory> RecorderFactoryMock { get; }
}
