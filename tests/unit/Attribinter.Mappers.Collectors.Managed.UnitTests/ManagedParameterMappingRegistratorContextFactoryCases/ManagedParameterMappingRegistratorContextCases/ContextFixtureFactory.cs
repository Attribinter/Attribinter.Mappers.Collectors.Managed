namespace Attribinter.Mappers.Collectors.Managed.ManagedParameterMappingRegistratorContextFactoryCases.ManagedParameterMappingRegistratorContextCases;

using Moq;

internal static class ContextFixtureFactory
{
    public static IContextFixture<TParameter, TRecord, TData, TParameterFactory, TRecorderFactory> Create<TParameter, TRecord, TData, TParameterFactory, TRecorderFactory>()
        where TParameterFactory : class
        where TRecorderFactory : class
    {
        IManagedParameterMappingRegistratorContextFactory factory = new ManagedParameterMappingRegistratorContextFactory();

        Mock<IParameterMappingCollector<TParameter, TRecord, TData>> collectorMock = new();

        Mock<TParameterFactory> parameterFactoryMock = new();
        Mock<TRecorderFactory> recorderFactoryMock = new();

        var sut = factory.Create(collectorMock.Object, parameterFactoryMock.Object, recorderFactoryMock.Object);

        return new ContextFixture<TParameter, TRecord, TData, TParameterFactory, TRecorderFactory>(sut, collectorMock, parameterFactoryMock, recorderFactoryMock);
    }

    private sealed class ContextFixture<TParameter, TRecord, TData, TParameterFactory, TRecorderFactory> : IContextFixture<TParameter, TRecord, TData, TParameterFactory, TRecorderFactory>
        where TParameterFactory : class
        where TRecorderFactory : class
    {
        private readonly IManagedParameterMappingRegistratorContext<TParameter, TRecord, TData, TParameterFactory, TRecorderFactory> Sut;

        private readonly Mock<IParameterMappingCollector<TParameter, TRecord, TData>> CollectorMock;

        private readonly Mock<TParameterFactory> ParameterFactoryMock;
        private readonly Mock<TRecorderFactory> RecorderFactoryMock;

        public ContextFixture(IManagedParameterMappingRegistratorContext<TParameter, TRecord, TData, TParameterFactory, TRecorderFactory> sut, Mock<IParameterMappingCollector<TParameter, TRecord, TData>> collectorMock, Mock<TParameterFactory> parameterFactoryMock, Mock<TRecorderFactory> recorderFactoryMock)
        {
            Sut = sut;

            CollectorMock = collectorMock;

            ParameterFactoryMock = parameterFactoryMock;
            RecorderFactoryMock = recorderFactoryMock;
        }

        IManagedParameterMappingRegistratorContext<TParameter, TRecord, TData, TParameterFactory, TRecorderFactory> IContextFixture<TParameter, TRecord, TData, TParameterFactory, TRecorderFactory>.Sut => Sut;

        Mock<IParameterMappingCollector<TParameter, TRecord, TData>> IContextFixture<TParameter, TRecord, TData, TParameterFactory, TRecorderFactory>.CollectorMock => CollectorMock;

        Mock<TParameterFactory> IContextFixture<TParameter, TRecord, TData, TParameterFactory, TRecorderFactory>.ParameterFactoryMock => ParameterFactoryMock;
        Mock<TRecorderFactory> IContextFixture<TParameter, TRecord, TData, TParameterFactory, TRecorderFactory>.RecorderFactoryMock => RecorderFactoryMock;
    }
}
