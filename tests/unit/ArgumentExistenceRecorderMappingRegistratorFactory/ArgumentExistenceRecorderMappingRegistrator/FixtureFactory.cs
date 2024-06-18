namespace Paraminter.Recorders.Mappers.Collectors.Managed.ArgumentExistenceRecorderMappingRegistrator;

using Moq;

internal static class FixtureFactory
{
    public static IFixture<TParameter, TRecord, TParameterFactory, TRecorderFactory> Create<TParameter, TRecord, TParameterFactory, TRecorderFactory>()
        where TParameterFactory : class
        where TRecorderFactory : class
    {
        Mock<IManagedArgumentExistenceRecorderMappingRegistratorContextFactory> contextFactoryMock = new();

        IArgumentExistenceRecorderMappingRegistratorFactory factory = new ArgumentExistenceRecorderMappingRegistratorFactory(contextFactoryMock.Object);

        Mock<IManagedArgumentExistenceRecorderMappingRegistrator<TParameter, TRecord, TParameterFactory, TRecorderFactory>> managedRegistratorMock = new();

        Mock<TParameterFactory> parameterFactoryMock = new();
        Mock<TRecorderFactory> recorderFactoryMock = new();

        var sut = factory.Create(managedRegistratorMock.Object, parameterFactoryMock.Object, recorderFactoryMock.Object);

        return new Fixture<TParameter, TRecord, TParameterFactory, TRecorderFactory>(sut, contextFactoryMock, managedRegistratorMock, parameterFactoryMock, recorderFactoryMock);
    }

    private sealed class Fixture<TParameter, TRecord, TParameterFactory, TRecorderFactory>
        : IFixture<TParameter, TRecord, TParameterFactory, TRecorderFactory>
        where TParameterFactory : class
        where TRecorderFactory : class
    {
        private readonly IArgumentExistenceRecorderMappingRegistrator<TParameter, TRecord> Sut;

        private readonly Mock<IManagedArgumentExistenceRecorderMappingRegistratorContextFactory> ContextFactoryMock;

        private readonly Mock<IManagedArgumentExistenceRecorderMappingRegistrator<TParameter, TRecord, TParameterFactory, TRecorderFactory>> ManagedRegistratorMock;

        private readonly Mock<TParameterFactory> ParameterFactoryMock;
        private readonly Mock<TRecorderFactory> RecorderFactoryMock;

        public Fixture(
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

        IArgumentExistenceRecorderMappingRegistrator<TParameter, TRecord> IFixture<TParameter, TRecord, TParameterFactory, TRecorderFactory>.Sut => Sut;

        Mock<IManagedArgumentExistenceRecorderMappingRegistratorContextFactory> IFixture<TParameter, TRecord, TParameterFactory, TRecorderFactory>.ContextFactoryMock => ContextFactoryMock;

        Mock<IManagedArgumentExistenceRecorderMappingRegistrator<TParameter, TRecord, TParameterFactory, TRecorderFactory>> IFixture<TParameter, TRecord, TParameterFactory, TRecorderFactory>.ManagedRegistratorMock => ManagedRegistratorMock;

        Mock<TParameterFactory> IFixture<TParameter, TRecord, TParameterFactory, TRecorderFactory>.ParameterFactoryMock => ParameterFactoryMock;
        Mock<TRecorderFactory> IFixture<TParameter, TRecord, TParameterFactory, TRecorderFactory>.RecorderFactoryMock => RecorderFactoryMock;
    }
}
