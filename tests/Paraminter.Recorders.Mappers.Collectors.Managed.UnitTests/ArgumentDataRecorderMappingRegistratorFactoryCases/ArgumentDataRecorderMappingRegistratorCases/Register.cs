namespace Paraminter.Recorders.Mappers.Collectors.Managed.ArgumentDataRecorderMappingRegistratorFactoryCases.ArgumentDataRecorderMappingRegistratorCases;

using Moq;

using System;

using Xunit;

public sealed class Register
{
    [Fact]
    public void NullCollector_ThrowsArgumentNullException()
    {
        var fixture = RegistratorFixtureFactory.Create<object, object, object, object, object>();

        var result = Record.Exception(() => Target(fixture, null!));

        Assert.IsType<ArgumentNullException>(result);
    }

    [Fact]
    public void ValidCollector_Registers()
    {
        var context = Mock.Of<IManagedArgumentDataRecorderMappingRegistratorContext<object, object, object, object, object>>();

        var collector = Mock.Of<IArgumentDataRecorderMappingCollector<object, object, object>>();

        var fixture = RegistratorFixtureFactory.Create<object, object, object, object, object>();

        fixture.ContextFactoryMock.Setup((factory) => factory.Create(collector, fixture.ParameterFactoryMock.Object, fixture.RecorderFactoryMock.Object)).Returns(context);

        Target(fixture, collector);

        fixture.ManagedRegistratorMock.Verify((registrator) => registrator.Register(context), Times.Once());
        fixture.ManagedRegistratorMock.VerifyNoOtherCalls();
    }

    private static void Target<TParameter, TRecord, TArgumentData, TParameterFactory, TRecorderFactory>(
        IRegistratorFixture<TParameter, TRecord, TArgumentData, TParameterFactory, TRecorderFactory> fixture,
        IArgumentDataRecorderMappingCollector<TParameter, TRecord, TArgumentData> collector)
        where TParameterFactory : class
        where TRecorderFactory : class
    {
        fixture.Sut.Register(collector);
    }
}
