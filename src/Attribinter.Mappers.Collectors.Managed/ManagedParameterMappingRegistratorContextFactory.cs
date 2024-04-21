namespace Attribinter.Mappers.Collectors.Managed;

using Attribinter.Mappers.Collectors;

using System;

/// <inheritdoc cref="IManagedParameterMappingRegistratorContextFactory"/>
public sealed class ManagedParameterMappingRegistratorContextFactory : IManagedParameterMappingRegistratorContextFactory
{
    /// <summary>Instantiates a <see cref="ManagedParameterMappingRegistratorContextFactory"/>, handling creation of <see cref="IManagedParameterMappingRegistratorContext{TParameter, TRecord, TData, TParameterFactory, TRecorderFactory}"/>.</summary>
    public ManagedParameterMappingRegistratorContextFactory() { }

    IManagedParameterMappingRegistratorContext<TParameter, TRecord, TData, TParameterFactory, TRecorderFactory> IManagedParameterMappingRegistratorContextFactory.Create<TParameter, TRecord, TData, TParameterFactory, TRecorderFactory>(IParameterMappingCollector<TParameter, TRecord, TData> collector, TParameterFactory parameterFactory, TRecorderFactory recorderFactory)
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

        return new ManagedParameterMappingRegistratorContext<TParameter, TRecord, TData, TParameterFactory, TRecorderFactory>(collector, parameterFactory, recorderFactory);
    }

    private sealed class ManagedParameterMappingRegistratorContext<TParameter, TRecord, TData, TParameterFactory, TRecorderFactory> : IManagedParameterMappingRegistratorContext<TParameter, TRecord, TData, TParameterFactory, TRecorderFactory>
    {
        private readonly IParameterMappingCollector<TParameter, TRecord, TData> Collector;

        private readonly TParameterFactory ParameterFactory;
        private readonly TRecorderFactory RecorderFactory;

        public ManagedParameterMappingRegistratorContext(IParameterMappingCollector<TParameter, TRecord, TData> collector, TParameterFactory parameterFactory, TRecorderFactory recorderFactory)
        {
            Collector = collector;

            ParameterFactory = parameterFactory;
            RecorderFactory = recorderFactory;
        }

        IParameterMappingCollector<TParameter, TRecord, TData> IManagedParameterMappingRegistratorContext<TParameter, TRecord, TData, TParameterFactory, TRecorderFactory>.Collector => Collector;

        TParameterFactory IManagedParameterMappingRegistratorContext<TParameter, TRecord, TData, TParameterFactory, TRecorderFactory>.ParameterFactory => ParameterFactory;
        TRecorderFactory IManagedParameterMappingRegistratorContext<TParameter, TRecord, TData, TParameterFactory, TRecorderFactory>.RecorderFactory => RecorderFactory;
    }
}
