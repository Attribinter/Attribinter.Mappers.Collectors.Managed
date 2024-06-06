namespace Paraminter.Recorders.Mappers.Collectors.Managed.ManagedArgumentExistenceRecorderMappingRegistratorContextFactoryCases.ManagedArgumentExistenceRecorderMappingRegistratorContextCases;

using Moq;

internal static class ContextFixtureFactory
{
    public static IContextFixture<TParameter, TRecord, TParameterFactory, TRecorderFactory> Create<TParameter, TRecord, TParameterFactory, TRecorderFactory>()
        where TParameterFactory : class
        where TRecorderFactory : class
    {
        IManagedArgumentExistenceRecorderMappingRegistratorContextFactory factory = new ManagedArgumentExistenceRecorderMappingRegistratorContextFactory();

        Mock<IArgumentExistenceRecorderMappingCollector<TParameter, TRecord>> collectorMock = new();

        Mock<TParameterFactory> parameterFactoryMock = new();
        Mock<TRecorderFactory> recorderFactoryMock = new();

        var sut = factory.Create(collectorMock.Object, parameterFactoryMock.Object, recorderFactoryMock.Object);

        return new ContextFixture<TParameter, TRecord, TParameterFactory, TRecorderFactory>(sut, collectorMock, parameterFactoryMock, recorderFactoryMock);
    }

    private sealed class ContextFixture<TParameter, TRecord, TParameterFactory, TRecorderFactory>
        : IContextFixture<TParameter, TRecord, TParameterFactory, TRecorderFactory>
        where TParameterFactory : class
        where TRecorderFactory : class
    {
        private readonly IManagedArgumentExistenceRecorderMappingRegistratorContext<TParameter, TRecord, TParameterFactory, TRecorderFactory> Sut;

        private readonly Mock<IArgumentExistenceRecorderMappingCollector<TParameter, TRecord>> CollectorMock;

        private readonly Mock<TParameterFactory> ParameterFactoryMock;
        private readonly Mock<TRecorderFactory> RecorderFactoryMock;

        public ContextFixture(
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

        IManagedArgumentExistenceRecorderMappingRegistratorContext<TParameter, TRecord, TParameterFactory, TRecorderFactory> IContextFixture<TParameter, TRecord, TParameterFactory, TRecorderFactory>.Sut => Sut;

        Mock<IArgumentExistenceRecorderMappingCollector<TParameter, TRecord>> IContextFixture<TParameter, TRecord, TParameterFactory, TRecorderFactory>.CollectorMock => CollectorMock;

        Mock<TParameterFactory> IContextFixture<TParameter, TRecord, TParameterFactory, TRecorderFactory>.ParameterFactoryMock => ParameterFactoryMock;
        Mock<TRecorderFactory> IContextFixture<TParameter, TRecord, TParameterFactory, TRecorderFactory>.RecorderFactoryMock => RecorderFactoryMock;
    }
}
