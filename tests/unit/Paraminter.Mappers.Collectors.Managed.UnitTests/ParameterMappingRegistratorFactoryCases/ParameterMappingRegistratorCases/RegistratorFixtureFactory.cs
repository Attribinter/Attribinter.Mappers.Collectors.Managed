namespace Paraminter.Mappers.Collectors.Managed.ParameterMappingRegistratorFactoryCases.ParameterMappingRegistratorCases;

using Moq;

internal static class RegistratorFixtureFactory
{
    public static IRegistratorFixture<TParameter, TRecord, TArgumentData, TParameterFactory, TRecorderFactory> Create<TParameter, TRecord, TArgumentData, TParameterFactory, TRecorderFactory>()
        where TParameterFactory : class
        where TRecorderFactory : class
    {
        Mock<IManagedParameterMappingRegistratorContextFactory> contextFactoryMock = new();

        IParameterMappingRegistratorFactory factory = new ParameterMappingRegistratorFactory(contextFactoryMock.Object);

        Mock<IManagedParameterMappingRegistrator<TParameter, TRecord, TArgumentData, TParameterFactory, TRecorderFactory>> managedRegistratorMock = new();

        Mock<TParameterFactory> parameterFactoryMock = new();
        Mock<TRecorderFactory> recorderFactoryMock = new();

        var sut = factory.Create(managedRegistratorMock.Object, parameterFactoryMock.Object, recorderFactoryMock.Object);

        return new RegistratorFixture<TParameter, TRecord, TArgumentData, TParameterFactory, TRecorderFactory>(sut, contextFactoryMock, managedRegistratorMock, parameterFactoryMock, recorderFactoryMock);
    }

    private sealed class RegistratorFixture<TParameter, TRecord, TArgumentData, TParameterFactory, TRecorderFactory> : IRegistratorFixture<TParameter, TRecord, TArgumentData, TParameterFactory, TRecorderFactory>
        where TParameterFactory : class
        where TRecorderFactory : class
    {
        private readonly IParameterMappingRegistrator<TParameter, TRecord, TArgumentData> Sut;

        private readonly Mock<IManagedParameterMappingRegistratorContextFactory> ContextFactoryMock;

        private readonly Mock<IManagedParameterMappingRegistrator<TParameter, TRecord, TArgumentData, TParameterFactory, TRecorderFactory>> ManagedRegistratorMock;

        private readonly Mock<TParameterFactory> ParameterFactoryMock;
        private readonly Mock<TRecorderFactory> RecorderFactoryMock;

        public RegistratorFixture(IParameterMappingRegistrator<TParameter, TRecord, TArgumentData> sut, Mock<IManagedParameterMappingRegistratorContextFactory> contextFactoryMock, Mock<IManagedParameterMappingRegistrator<TParameter, TRecord, TArgumentData, TParameterFactory, TRecorderFactory>> managedRegistratorMock, Mock<TParameterFactory> parameterFactoryMock, Mock<TRecorderFactory> recorderFactoryMock)
        {
            Sut = sut;

            ContextFactoryMock = contextFactoryMock;

            ManagedRegistratorMock = managedRegistratorMock;

            ParameterFactoryMock = parameterFactoryMock;
            RecorderFactoryMock = recorderFactoryMock;
        }

        IParameterMappingRegistrator<TParameter, TRecord, TArgumentData> IRegistratorFixture<TParameter, TRecord, TArgumentData, TParameterFactory, TRecorderFactory>.Sut => Sut;

        Mock<IManagedParameterMappingRegistratorContextFactory> IRegistratorFixture<TParameter, TRecord, TArgumentData, TParameterFactory, TRecorderFactory>.ContextFactoryMock => ContextFactoryMock;

        Mock<IManagedParameterMappingRegistrator<TParameter, TRecord, TArgumentData, TParameterFactory, TRecorderFactory>> IRegistratorFixture<TParameter, TRecord, TArgumentData, TParameterFactory, TRecorderFactory>.ManagedRegistratorMock => ManagedRegistratorMock;

        Mock<TParameterFactory> IRegistratorFixture<TParameter, TRecord, TArgumentData, TParameterFactory, TRecorderFactory>.ParameterFactoryMock => ParameterFactoryMock;
        Mock<TRecorderFactory> IRegistratorFixture<TParameter, TRecord, TArgumentData, TParameterFactory, TRecorderFactory>.RecorderFactoryMock => RecorderFactoryMock;
    }
}
