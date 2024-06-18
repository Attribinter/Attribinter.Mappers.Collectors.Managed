namespace Paraminter.Recorders.Mappers.Collectors.Managed.ManagedArgumentDataRecorderMappingRegistratorContext;

using Moq;

internal static class FixtureFactory
{
    public static IFixture<TParameter, TRecord, TArgumentData, TParameterFactory, TRecorderFactory> Create<TParameter, TRecord, TArgumentData, TParameterFactory, TRecorderFactory>()
        where TParameterFactory : class
        where TRecorderFactory : class
    {
        IManagedArgumentDataRecorderMappingRegistratorContextFactory factory = new ManagedArgumentDataRecorderMappingRegistratorContextFactory();

        Mock<IArgumentDataRecorderMappingCollector<TParameter, TRecord, TArgumentData>> collectorMock = new();

        Mock<TParameterFactory> parameterFactoryMock = new();
        Mock<TRecorderFactory> recorderFactoryMock = new();

        var sut = factory.Create(collectorMock.Object, parameterFactoryMock.Object, recorderFactoryMock.Object);

        return new Fixture<TParameter, TRecord, TArgumentData, TParameterFactory, TRecorderFactory>(sut, collectorMock, parameterFactoryMock, recorderFactoryMock);
    }

    private sealed class Fixture<TParameter, TRecord, TArgumentData, TParameterFactory, TRecorderFactory>
        : IFixture<TParameter, TRecord, TArgumentData, TParameterFactory, TRecorderFactory>
        where TParameterFactory : class
        where TRecorderFactory : class
    {
        private readonly IManagedArgumentDataRecorderMappingRegistratorContext<TParameter, TRecord, TArgumentData, TParameterFactory, TRecorderFactory> Sut;

        private readonly Mock<IArgumentDataRecorderMappingCollector<TParameter, TRecord, TArgumentData>> CollectorMock;

        private readonly Mock<TParameterFactory> ParameterFactoryMock;
        private readonly Mock<TRecorderFactory> RecorderFactoryMock;

        public Fixture(
            IManagedArgumentDataRecorderMappingRegistratorContext<TParameter, TRecord, TArgumentData, TParameterFactory, TRecorderFactory> sut,
            Mock<IArgumentDataRecorderMappingCollector<TParameter, TRecord, TArgumentData>> collectorMock,
            Mock<TParameterFactory> parameterFactoryMock,
            Mock<TRecorderFactory> recorderFactoryMock)
        {
            Sut = sut;

            CollectorMock = collectorMock;

            ParameterFactoryMock = parameterFactoryMock;
            RecorderFactoryMock = recorderFactoryMock;
        }

        IManagedArgumentDataRecorderMappingRegistratorContext<TParameter, TRecord, TArgumentData, TParameterFactory, TRecorderFactory> IFixture<TParameter, TRecord, TArgumentData, TParameterFactory, TRecorderFactory>.Sut => Sut;

        Mock<IArgumentDataRecorderMappingCollector<TParameter, TRecord, TArgumentData>> IFixture<TParameter, TRecord, TArgumentData, TParameterFactory, TRecorderFactory>.CollectorMock => CollectorMock;

        Mock<TParameterFactory> IFixture<TParameter, TRecord, TArgumentData, TParameterFactory, TRecorderFactory>.ParameterFactoryMock => ParameterFactoryMock;
        Mock<TRecorderFactory> IFixture<TParameter, TRecord, TArgumentData, TParameterFactory, TRecorderFactory>.RecorderFactoryMock => RecorderFactoryMock;
    }
}
