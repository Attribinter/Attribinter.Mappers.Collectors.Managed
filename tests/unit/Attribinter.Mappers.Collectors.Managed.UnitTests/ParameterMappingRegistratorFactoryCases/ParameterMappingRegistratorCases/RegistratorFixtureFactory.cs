namespace Attribinter.Mappers.Collectors.Managed.ParameterMappingRegistratorFactoryCases.ParameterMappingRegistratorCases;

using Moq;

internal static class RegistratorFixtureFactory
{
    public static IRegistratorFixture<TParameter, TRecord, TData, TParameterFactory, TRecorderFactory> Create<TParameter, TRecord, TData, TParameterFactory, TRecorderFactory>() where TParameterFactory : class where TRecorderFactory : class
    {
        Mock<IManagedParameterMappingRegistratorContextFactory> contextFactoryMock = new();

        IParameterMappingRegistratorFactory factory = new ParameterMappingRegistratorFactory(contextFactoryMock.Object);

        Mock<IManagedParameterMappingRegistrator<TParameter, TRecord, TData, TParameterFactory, TRecorderFactory>> managedRegistratorMock = new();

        Mock<TParameterFactory> parameterFactoryMock = new();
        Mock<TRecorderFactory> recorderFactoryMock = new();

        var sut = factory.Create(managedRegistratorMock.Object, parameterFactoryMock.Object, recorderFactoryMock.Object);

        return new RegistratorFixture<TParameter, TRecord, TData, TParameterFactory, TRecorderFactory>(sut, contextFactoryMock, managedRegistratorMock, parameterFactoryMock, recorderFactoryMock);
    }

    private sealed class RegistratorFixture<TParameter, TRecord, TData, TParameterFactory, TRecorderFactory> : IRegistratorFixture<TParameter, TRecord, TData, TParameterFactory, TRecorderFactory> where TParameterFactory : class where TRecorderFactory : class
    {
        private readonly IParameterMappingRegistrator<TParameter, TRecord, TData> Sut;

        private readonly Mock<IManagedParameterMappingRegistratorContextFactory> ContextFactoryMock;

        private readonly Mock<IManagedParameterMappingRegistrator<TParameter, TRecord, TData, TParameterFactory, TRecorderFactory>> ManagedRegistratorMock;

        private readonly Mock<TParameterFactory> ParameterFactoryMock;
        private readonly Mock<TRecorderFactory> RecorderFactoryMock;

        public RegistratorFixture(IParameterMappingRegistrator<TParameter, TRecord, TData> sut, Mock<IManagedParameterMappingRegistratorContextFactory> contextFactoryMock, Mock<IManagedParameterMappingRegistrator<TParameter, TRecord, TData, TParameterFactory, TRecorderFactory>> managedRegistratorMock, Mock<TParameterFactory> parameterFactoryMock, Mock<TRecorderFactory> recorderFactoryMock)
        {
            Sut = sut;

            ContextFactoryMock = contextFactoryMock;

            ManagedRegistratorMock = managedRegistratorMock;

            ParameterFactoryMock = parameterFactoryMock;
            RecorderFactoryMock = recorderFactoryMock;
        }

        IParameterMappingRegistrator<TParameter, TRecord, TData> IRegistratorFixture<TParameter, TRecord, TData, TParameterFactory, TRecorderFactory>.Sut => Sut;

        Mock<IManagedParameterMappingRegistratorContextFactory> IRegistratorFixture<TParameter, TRecord, TData, TParameterFactory, TRecorderFactory>.ContextFactoryMock => ContextFactoryMock;

        Mock<IManagedParameterMappingRegistrator<TParameter, TRecord, TData, TParameterFactory, TRecorderFactory>> IRegistratorFixture<TParameter, TRecord, TData, TParameterFactory, TRecorderFactory>.ManagedRegistratorMock => ManagedRegistratorMock;

        Mock<TParameterFactory> IRegistratorFixture<TParameter, TRecord, TData, TParameterFactory, TRecorderFactory>.ParameterFactoryMock => ParameterFactoryMock;
        Mock<TRecorderFactory> IRegistratorFixture<TParameter, TRecord, TData, TParameterFactory, TRecorderFactory>.RecorderFactoryMock => RecorderFactoryMock;
    }
}
