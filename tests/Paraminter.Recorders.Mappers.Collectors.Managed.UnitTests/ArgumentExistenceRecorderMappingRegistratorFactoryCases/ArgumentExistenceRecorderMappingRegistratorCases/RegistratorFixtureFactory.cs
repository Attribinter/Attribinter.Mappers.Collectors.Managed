namespace Paraminter.Recorders.Mappers.Collectors.Managed.ArgumentExistenceRecorderMappingRegistratorFactoryCases.ArgumentExistenceRecorderMappingRegistratorCases;

using Moq;

internal static class RegistratorFixtureFactory
{
    public static IRegistratorFixture<TParameter, TRecord, TParameterFactory, TRecorderFactory> Create<TParameter, TRecord, TParameterFactory, TRecorderFactory>()
        where TParameterFactory : class
        where TRecorderFactory : class
    {
        Mock<IManagedArgumentExistenceRecorderMappingRegistratorContextFactory> contextFactoryMock = new();

        IArgumentExistenceRecorderMappingRegistratorFactory factory = new ArgumentExistenceRecorderMappingRegistratorFactory(contextFactoryMock.Object);

        Mock<IManagedArgumentExistenceRecorderMappingRegistrator<TParameter, TRecord, TParameterFactory, TRecorderFactory>> managedRegistratorMock = new();

        Mock<TParameterFactory> parameterFactoryMock = new();
        Mock<TRecorderFactory> recorderFactoryMock = new();

        var sut = factory.Create(managedRegistratorMock.Object, parameterFactoryMock.Object, recorderFactoryMock.Object);

        return new RegistratorFixture<TParameter, TRecord, TParameterFactory, TRecorderFactory>(sut, contextFactoryMock, managedRegistratorMock, parameterFactoryMock, recorderFactoryMock);
    }

    private sealed class RegistratorFixture<TParameter, TRecord, TParameterFactory, TRecorderFactory>
        : IRegistratorFixture<TParameter, TRecord, TParameterFactory, TRecorderFactory>
        where TParameterFactory : class
        where TRecorderFactory : class
    {
        private readonly IArgumentExistenceRecorderMappingRegistrator<TParameter, TRecord> Sut;

        private readonly Mock<IManagedArgumentExistenceRecorderMappingRegistratorContextFactory> ContextFactoryMock;

        private readonly Mock<IManagedArgumentExistenceRecorderMappingRegistrator<TParameter, TRecord, TParameterFactory, TRecorderFactory>> ManagedRegistratorMock;

        private readonly Mock<TParameterFactory> ParameterFactoryMock;
        private readonly Mock<TRecorderFactory> RecorderFactoryMock;

        public RegistratorFixture(
            IArgumentExistenceRecorderMappingRegistrator<TParameter, TRecord> sut,
            Mock<IManagedArgumentExistenceRecorderMappingRegistratorContextFactory> contextFactoryMock,
            Mock<IManagedArgumentExistenceRecorderMappingRegistrator<TParameter, TRecord, TParameterFactory, TRecorderFactory>> managedRegistratorMock,
            Mock<TParameterFactory> parameterFactoryMock,
            Mock<TRecorderFactory> recorderFactoryMock)
        {
            Sut = sut;

            ContextFactoryMock = contextFactoryMock;

            ManagedRegistratorMock = managedRegistratorMock;

            ParameterFactoryMock = parameterFactoryMock;
            RecorderFactoryMock = recorderFactoryMock;
        }

        IArgumentExistenceRecorderMappingRegistrator<TParameter, TRecord> IRegistratorFixture<TParameter, TRecord, TParameterFactory, TRecorderFactory>.Sut => Sut;

        Mock<IManagedArgumentExistenceRecorderMappingRegistratorContextFactory> IRegistratorFixture<TParameter, TRecord, TParameterFactory, TRecorderFactory>.ContextFactoryMock => ContextFactoryMock;

        Mock<IManagedArgumentExistenceRecorderMappingRegistrator<TParameter, TRecord, TParameterFactory, TRecorderFactory>> IRegistratorFixture<TParameter, TRecord, TParameterFactory, TRecorderFactory>.ManagedRegistratorMock => ManagedRegistratorMock;

        Mock<TParameterFactory> IRegistratorFixture<TParameter, TRecord, TParameterFactory, TRecorderFactory>.ParameterFactoryMock => ParameterFactoryMock;
        Mock<TRecorderFactory> IRegistratorFixture<TParameter, TRecord, TParameterFactory, TRecorderFactory>.RecorderFactoryMock => RecorderFactoryMock;
    }
}
