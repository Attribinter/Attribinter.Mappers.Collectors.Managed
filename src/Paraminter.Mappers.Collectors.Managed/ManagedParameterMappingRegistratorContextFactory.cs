namespace Paraminter.Mappers.Collectors.Managed;

using Paraminter.Mappers.Collectors;

using System;

/// <inheritdoc cref="IManagedParameterMappingRegistratorContextFactory"/>
public sealed class ManagedParameterMappingRegistratorContextFactory : IManagedParameterMappingRegistratorContextFactory
{
    /// <summary>Instantiates a <see cref="ManagedParameterMappingRegistratorContextFactory"/>, handling creation of <see cref="IManagedParameterMappingRegistratorContext{TParameter, TRecord, TArgumentData, TParameterFactory, TRecorderFactory}"/>.</summary>
    public ManagedParameterMappingRegistratorContextFactory() { }

    IManagedParameterMappingRegistratorContext<TParameter, TRecord, TArgumentData, TParameterFactory, TRecorderFactory> IManagedParameterMappingRegistratorContextFactory.Create<TParameter, TRecord, TArgumentData, TParameterFactory, TRecorderFactory>(IParameterMappingCollector<TParameter, TRecord, TArgumentData> collector, TParameterFactory parameterFactory, TRecorderFactory recorderFactory)
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

        return new ManagedParameterMappingRegistratorContext<TParameter, TRecord, TArgumentData, TParameterFactory, TRecorderFactory>(collector, parameterFactory, recorderFactory);
    }

    private sealed class ManagedParameterMappingRegistratorContext<TParameter, TRecord, TArgumentData, TParameterFactory, TRecorderFactory> : IManagedParameterMappingRegistratorContext<TParameter, TRecord, TArgumentData, TParameterFactory, TRecorderFactory>
    {
        private readonly IParameterMappingCollector<TParameter, TRecord, TArgumentData> Collector;

        private readonly TParameterFactory ParameterFactory;
        private readonly TRecorderFactory RecorderFactory;

        public ManagedParameterMappingRegistratorContext(IParameterMappingCollector<TParameter, TRecord, TArgumentData> collector, TParameterFactory parameterFactory, TRecorderFactory recorderFactory)
        {
            Collector = collector;

            ParameterFactory = parameterFactory;
            RecorderFactory = recorderFactory;
        }

        IParameterMappingCollector<TParameter, TRecord, TArgumentData> IManagedParameterMappingRegistratorContext<TParameter, TRecord, TArgumentData, TParameterFactory, TRecorderFactory>.Collector => Collector;

        TParameterFactory IManagedParameterMappingRegistratorContext<TParameter, TRecord, TArgumentData, TParameterFactory, TRecorderFactory>.ParameterFactory => ParameterFactory;
        TRecorderFactory IManagedParameterMappingRegistratorContext<TParameter, TRecord, TArgumentData, TParameterFactory, TRecorderFactory>.RecorderFactory => RecorderFactory;
    }
}
