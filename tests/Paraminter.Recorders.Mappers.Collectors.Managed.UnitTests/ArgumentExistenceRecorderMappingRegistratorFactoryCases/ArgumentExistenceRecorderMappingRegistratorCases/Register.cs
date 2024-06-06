namespace Paraminter.Recorders.Mappers.Collectors.Managed.ArgumentExistenceRecorderMappingRegistratorFactoryCases.ArgumentExistenceRecorderMappingRegistratorCases;

using Moq;

using System;

using Xunit;

public sealed class Register
{
    [Fact]
    public void NullCollector_ThrowsArgumentNullException()
    {
        var fixture = RegistratorFixtureFactory.Create<object, object, object, object>();

        var result = Record.Exception(() => Target(fixture, null!));

        Assert.IsType<ArgumentNullException>(result);
    }

    [Fact]
    public void ValidCollector_Registers()
    {
        var context = Mock.Of<IManagedArgumentExistenceRecorderMappingRegistratorContext<object, object, object, object>>();

        var collector = Mock.Of<IArgumentExistenceRecorderMappingCollector<object, object>>();

        var fixture = RegistratorFixtureFactory.Create<object, object, object, object>();

        fixture.ContextFactoryMock.Setup((factory) => factory.Create(collector, fixture.ParameterFactoryMock.Object, fixture.RecorderFactoryMock.Object)).Returns(context);

        Target(fixture, collector);

        fixture.ManagedRegistratorMock.Verify((registrator) => registrator.Register(context), Times.Once());
        fixture.ManagedRegistratorMock.VerifyNoOtherCalls();
    }

    private static void Target<TParameter, TRecord, TParameterFactory, TRecorderFactory>(
        IRegistratorFixture<TParameter, TRecord, TParameterFactory, TRecorderFactory> fixture,
        IArgumentExistenceRecorderMappingCollector<TParameter, TRecord> collector)
        where TParameterFactory : class
        where TRecorderFactory : class
    {
        fixture.Sut.Register(collector);
    }
}
