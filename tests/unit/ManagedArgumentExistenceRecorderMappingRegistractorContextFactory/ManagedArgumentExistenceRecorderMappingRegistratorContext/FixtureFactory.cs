namespace Paraminter.Recorders.Mappers.Collectors.Managed.ManagedArgumentExistenceRecorderMappingRegistratorContext;

using Moq;

internal static class FixtureFactory
{
    public static IFixture<TParameter, TRecord, TParameterFactory, TRecorderFactory> Create<TParameter, TRecord, TParameterFactory, TRecorderFactory>()
        where TParameterFactory : class
        where TRecorderFactory : class
    {
        IManagedArgumentExistenceRecorderMappingRegistratorContextFactory factory = new ManagedArgumentExistenceRecorderMappingRegistratorContextFactory();

        Mock<IArgumentExistenceRecorderMappingCollector<TParameter, TRecord>> collectorMock = new();

        Mock<TParameterFactory> parameterFactoryMock = new();
        Mock<TRecorderFactory> recorderFactoryMock = new();

        var sut = factory.Create(collectorMock.Object, parameterFactoryMock.Object, recorderFactoryMock.Object);

        return new Fixture<TParameter, TRecord, TParameterFactory, TRecorderFactory>(sut, collectorMock, parameterFactoryMock, recorderFactoryMock);
    }

    private sealed class Fixture<TParameter, TRecord, TParameterFactory, TRecorderFactory>
        : IFixture<TParameter, TRecord, TParameterFactory, TRecorderFactory>
        where TParameterFactory : class
        where TRecorderFactory : class
    {
        private readonly IManagedArgumentExistenceRecorderMappingRegistratorContext<TParameter, TRecord, TParameterFactory, TRecorderFactory> Sut;

        private readonly Mock<IArgumentExistenceRecorderMappingCollector<TParameter, TRecord>> CollectorMock;

        private readonly Mock<TParameterFactory> ParameterFactoryMock;
        private readonly Mock<TRecorderFactory> RecorderFactoryMock;

        public Fixture(
            IManagedArgumentExistenceRecorderMappingRegistratorContext<TParameter, TRecord, TParameterFactory, TRecorderFactory> sut,
            Mock<IArgumentExistenceRecorderMappingCollector<TParameter, TRecord>> collectorMock,
            Mock<TParameterFactory> parameterFactoryMock,
            Mock<TRecorderFactory> recorderFactoryMock)
        {
            Sut = sut;

            CollectorMock = collectorMock;

            ParameterFactoryMock = parameterFactoryMock;
            RecorderFactoryMock = recorderFactoryMock;
        }

        IManagedArgumentExistenceRecorderMappingRegistratorContext<TParameter, TRecord, TParameterFactory, TRecorderFactory> IFixture<TParameter, TRecord, TParameterFactory, TRecorderFactory>.Sut => Sut;

        Mock<IArgumentExistenceRecorderMappingCollector<TParameter, TRecord>> IFixture<TParameter, TRecord, TParameterFactory, TRecorderFactory>.CollectorMock => CollectorMock;

        Mock<TParameterFactory> IFixture<TParameter, TRecord, TParameterFactory, TRecorderFactory>.ParameterFactoryMock => ParameterFactoryMock;
        Mock<TRecorderFactory> IFixture<TParameter, TRecord, TParameterFactory, TRecorderFactory>.RecorderFactoryMock => RecorderFactoryMock;
    }
}
