namespace Paraminter.Recorders.Mappers.Collectors.Managed;

using System;

/// <inheritdoc cref="IManagedArgumentDataRecorderMappingRegistratorContextFactory"/>
public sealed class ManagedArgumentDataRecorderMappingRegistratorContextFactory
    : IManagedArgumentDataRecorderMappingRegistratorContextFactory
{
    /// <summary>Instantiates a <see cref="ManagedArgumentDataRecorderMappingRegistratorContextFactory"/>, handling creation of <see cref="IManagedArgumentDataRecorderMappingRegistratorContext{TParameter, TRecord, TArgumentData, TParameterFactory, TRecorderFactory}"/>.</summary>
    public ManagedArgumentDataRecorderMappingRegistratorContextFactory() { }

    IManagedArgumentDataRecorderMappingRegistratorContext<TParameter, TRecord, TArgumentData, TParameterFactory, TRecorderFactory> IManagedArgumentDataRecorderMappingRegistratorContextFactory.Create<TParameter, TRecord, TArgumentData, TParameterFactory, TRecorderFactory>(
        IArgumentDataRecorderMappingCollector<TParameter, TRecord, TArgumentData> collector,
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

        return new ManagedArgumentDataRecorderMappingRegistratorContext<TParameter, TRecord, TArgumentData, TParameterFactory, TRecorderFactory>(collector, parameterFactory, recorderFactory);
    }

    private sealed class ManagedArgumentDataRecorderMappingRegistratorContext<TParameter, TRecord, TArgumentData, TParameterFactory, TRecorderFactory>
        : IManagedArgumentDataRecorderMappingRegistratorContext<TParameter, TRecord, TArgumentData, TParameterFactory, TRecorderFactory>
    {
        private readonly IArgumentDataRecorderMappingCollector<TParameter, TRecord, TArgumentData> Collector;

        private readonly TParameterFactory ParameterFactory;
        private readonly TRecorderFactory RecorderFactory;

        public ManagedArgumentDataRecorderMappingRegistratorContext(
            IArgumentDataRecorderMappingCollector<TParameter, TRecord, TArgumentData> collector,
            TParameterFactory parameterFactory,
            TRecorderFactory recorderFactory)
        {
            Collector = collector;

            ParameterFactory = parameterFactory;
            RecorderFactory = recorderFactory;
        }

        IArgumentDataRecorderMappingCollector<TParameter, TRecord, TArgumentData> IManagedArgumentDataRecorderMappingRegistratorContext<TParameter, TRecord, TArgumentData, TParameterFactory, TRecorderFactory>.Collector => Collector;

        TParameterFactory IManagedArgumentDataRecorderMappingRegistratorContext<TParameter, TRecord, TArgumentData, TParameterFactory, TRecorderFactory>.ParameterFactory => ParameterFactory;
        TRecorderFactory IManagedArgumentDataRecorderMappingRegistratorContext<TParameter, TRecord, TArgumentData, TParameterFactory, TRecorderFactory>.RecorderFactory => RecorderFactory;
    }
}
