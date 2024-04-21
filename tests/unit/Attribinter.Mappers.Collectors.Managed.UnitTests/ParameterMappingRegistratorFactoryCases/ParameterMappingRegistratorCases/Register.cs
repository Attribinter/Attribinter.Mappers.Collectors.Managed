namespace Attribinter.Mappers.Collectors.Managed.ParameterMappingRegistratorFactoryCases.ParameterMappingRegistratorCases;

using Moq;

using System;

using Xunit;

public sealed class Register
{
    private static void Target<TParameter, TRecord, TData, TParameterFactory, TRecorderFactory>(IRegistratorFixture<TParameter, TRecord, TData, TParameterFactory, TRecorderFactory> fixture, IParameterMappingCollector<TParameter, TRecord, TData> collector) where TParameterFactory : class where TRecorderFactory : class => fixture.Sut.Register(collector);

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
        var context = Mock.Of<IManagedParameterMappingRegistratorContext<object, object, object, object, object>>();

        var collector = Mock.Of<IParameterMappingCollector<object, object, object>>();

        var fixture = RegistratorFixtureFactory.Create<object, object, object, object, object>();

        fixture.ContextFactoryMock.Setup((factory) => factory.Create(collector, fixture.ParameterFactoryMock.Object, fixture.RecorderFactoryMock.Object)).Returns(context);

        Target(fixture, collector);

        fixture.ManagedRegistratorMock.Verify((registrator) => registrator.Register(context), Times.Once());
        fixture.ManagedRegistratorMock.VerifyNoOtherCalls();
    }
}
