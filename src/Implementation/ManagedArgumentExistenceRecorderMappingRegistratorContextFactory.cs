namespace Paraminter.Recorders.Mappers.Collectors.Managed;

using System;

/// <inheritdoc cref="IManagedArgumentExistenceRecorderMappingRegistratorContextFactory"/>
public sealed class ManagedArgumentExistenceRecorderMappingRegistratorContextFactory
    : IManagedArgumentExistenceRecorderMappingRegistratorContextFactory
{
    /// <summary>Instantiates a <see cref="ManagedArgumentExistenceRecorderMappingRegistratorContextFactory"/>, handling creation of <see cref="IManagedArgumentExistenceRecorderMappingRegistratorContext{TParameter, TRecord, TParameterFactory, TRecorderFactory}"/>.</summary>
    public ManagedArgumentExistenceRecorderMappingRegistratorContextFactory() { }

    IManagedArgumentExistenceRecorderMappingRegistratorContext<TParameter, TRecord, TParameterFactory, TRecorderFactory> IManagedArgumentExistenceRecorderMappingRegistratorContextFactory.Create<TParameter, TRecord, TParameterFactory, TRecorderFactory>(
        IArgumentExistenceRecorderMappingCollector<TParameter, TRecord> collector,
        TParameterFactory parameterFactory,
        TRecorderFactory recorderFactory)
    {
        if (collector is null)
        {
            throw new ArgumentNullException(nameof(collector));
        }

        if (parameterFactory is null)
        {
            throw new ArgumentNullException(nameof(parameterFactory));
        }

        if (recorderFactory is null)
        {
            throw new ArgumentNullException(nameof(recorderFactory));
        }

        return new ManagedArgumentExistenceRecorderMappingRegistratorContext<TParameter, TRecord, TParameterFactory, TRecorderFactory>(collector, parameterFactory, recorderFactory);
    }

    private sealed class ManagedArgumentExistenceRecorderMappingRegistratorContext<TParameter, TRecord, TParameterFactory, TRecorderFactory>
        : IManagedArgumentExistenceRecorderMappingRegistratorContext<TParameter, TRecord, TParameterFactory, TRecorderFactory>
    {
        private readonly IArgumentExistenceRecorderMappingCollector<TParameter, TRecord> Collector;

        private readonly TParameterFactory ParameterFactory;
        private readonly TRecorderFactory RecorderFactory;

        public ManagedArgumentExistenceRecorderMappingRegistratorContext(
            IArgumentExistenceRecorderMappingCollector<TParameter, TRecord> collector,
            TParameterFactory parameterFactory,
            TRecorderFactory recorderFactory)
        {
            Collector = collector;

            ParameterFactory = parameterFactory;
            RecorderFactory = recorderFactory;
        }

        IArgumentExistenceRecorderMappingCollector<TParameter, TRecord> IManagedArgumentExistenceRecorderMappingRegistratorContext<TParameter, TRecord, TParameterFactory, TRecorderFactory>.Collector => Collector;

        TParameterFactory IManagedArgumentExistenceRecorderMappingRegistratorContext<TParameter, TRecord, TParameterFactory, TRecorderFactory>.ParameterFactory => ParameterFactory;
        TRecorderFactory IManagedArgumentExistenceRecorderMappingRegistratorContext<TParameter, TRecord, TParameterFactory, TRecorderFactory>.RecorderFactory => RecorderFactory;
    }
}
