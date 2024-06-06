namespace Paraminter.Recorders.Mappers.Collectors.Managed.ArgumentDataRecorderMappingRegistratorFactoryCases.ArgumentDataRecorderMappingRegistratorCases;

using Moq;

internal static class RegistratorFixtureFactory
{
    public static IRegistratorFixture<TParameter, TRecord, TArgumentData, TParameterFactory, TRecorderFactory> Create<TParameter, TRecord, TArgumentData, TParameterFactory, TRecorderFactory>()
        where TParameterFactory : class
        where TRecorderFactory : class
    {
        Mock<IManagedArgumentDataRecorderMappingRegistratorContextFactory> contextFactoryMock = new();

        IArgumentDataRecorderMappingRegistratorFactory factory = new ArgumentDataRecorderMappingRegistratorFactory(contextFactoryMock.Object);

        Mock<IManagedArgumentDataRecorderMappingRegistrator<TParameter, TRecord, TArgumentData, TParameterFactory, TRecorderFactory>> managedRegistratorMock = new();

        Mock<TParameterFactory> parameterFactoryMock = new();
        Mock<TRecorderFactory> recorderFactoryMock = new();

        var sut = factory.Create(managedRegistratorMock.Object, parameterFactoryMock.Object, recorderFactoryMock.Object);

        return new RegistratorFixture<TParameter, TRecord, TArgumentData, TParameterFactory, TRecorderFactory>(sut, contextFactoryMock, managedRegistratorMock, parameterFactoryMock, recorderFactoryMock);
    }

    private sealed class RegistratorFixture<TParameter, TRecord, TArgumentData, TParameterFactory, TRecorderFactory>
        : IRegistratorFixture<TParameter, TRecord, TArgumentData, TParameterFactory, TRecorderFactory>
        where TParameterFactory : class
        where TRecorderFactory : class
    {
        private readonly IArgumentDataRecorderMappingRegistrator<TParameter, TRecord, TArgumentData> Sut;

        private readonly Mock<IManagedArgumentDataRecorderMappingRegistratorContextFactory> ContextFactoryMock;

        private readonly Mock<IManagedArgumentDataRecorderMappingRegistrator<TParameter, TRecord, TArgumentData, TParameterFactory, TRecorderFactory>> ManagedRegistratorMock;

        private readonly Mock<TParameterFactory> ParameterFactoryMock;
        private readonly Mock<TRecorderFactory> RecorderFactoryMock;

        public RegistratorFixture(
            IArgumentDataRecorderMappingRegistrator<TParameter, TRecord, TArgumentData> sut,
            Mock<IManagedArgumentDataRecorderMappingRegistratorContextFactory> contextFactoryMock,
            Mock<IManagedArgumentDataRecorderMappingRegistrator<TParameter, TRecord, TArgumentData, TParameterFactory, TRecorderFactory>> managedRegistratorMock,
            Mock<TParameterFactory> parameterFactoryMock,
            Mock<TRecorderFactory> recorderFactoryMock)
        {
            Sut = sut;

            ContextFactoryMock = contextFactoryMock;

            ManagedRegistratorMock = managedRegistratorMock;

            ParameterFactoryMock = parameterFactoryMock;
            RecorderFactoryMock = recorderFactoryMock;
        }

        IArgumentDataRecorderMappingRegistrator<TParameter, TRecord, TArgumentData> IRegistratorFixture<TParameter, TRecord, TArgumentData, TParameterFactory, TRecorderFactory>.Sut => Sut;

        Mock<IManagedArgumentDataRecorderMappingRegistratorContextFactory> IRegistratorFixture<TParameter, TRecord, TArgumentData, TParameterFactory, TRecorderFactory>.ContextFactoryMock => ContextFactoryMock;

        Mock<IManagedArgumentDataRecorderMappingRegistrator<TParameter, TRecord, TArgumentData, TParameterFactory, TRecorderFactory>> IRegistratorFixture<TParameter, TRecord, TArgumentData, TParameterFactory, TRecorderFactory>.ManagedRegistratorMock => ManagedRegistratorMock;

        Mock<TParameterFactory> IRegistratorFixture<TParameter, TRecord, TArgumentData, TParameterFactory, TRecorderFactory>.ParameterFactoryMock => ParameterFactoryMock;
        Mock<TRecorderFactory> IRegistratorFixture<TParameter, TRecord, TArgumentData, TParameterFactory, TRecorderFactory>.RecorderFactoryMock => RecorderFactoryMock;
    }
}
