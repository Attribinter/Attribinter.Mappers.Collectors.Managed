namespace Paraminter.Recorders.Mappers.Collectors.Managed;

using System;

/// <inheritdoc cref="IArgumentExistenceRecorderMappingRegistratorFactory"/>
public sealed class ArgumentExistenceRecorderMappingRegistratorFactory
    : IArgumentExistenceRecorderMappingRegistratorFactory
{
    private readonly IManagedArgumentExistenceRecorderMappingRegistratorContextFactory ContextFactory;

    /// <summary>Instantiates a <see cref="ArgumentExistenceRecorderMappingRegistratorFactory"/>, handling creation of <see cref="IArgumentExistenceRecorderMappingRegistrator{TParameter, TRecord}"/> using <see cref="IManagedArgumentExistenceRecorderMappingRegistrator{TParameter, TRecord, TParameterFactory, TRecorderFactory}"/>.</summary>
    /// <param name="contextFactory">Handles creation of <see cref="IManagedArgumentExistenceRecorderMappingRegistratorContext{TParameter, TRecord, TParameterFactory, TRecorderFactory}"/>.</param>
    public ArgumentExistenceRecorderMappingRegistratorFactory(
        IManagedArgumentExistenceRecorderMappingRegistratorContextFactory contextFactory)
    {
        ContextFactory = contextFactory ?? throw new ArgumentNullException(nameof(contextFactory));
    }

    IArgumentExistenceRecorderMappingRegistrator<TParameter, TRecord> IArgumentExistenceRecorderMappingRegistratorFactory.Create<TParameter, TRecord, TParameterFactory, TRecorderFactory>(
        IManagedArgumentExistenceRecorderMappingRegistrator<TParameter, TRecord, TParameterFactory, TRecorderFactory> managedRegistrator,
        TParameterFactory parameterFactory,
        TRecorderFactory recorderFactory)
    {
        if (managedRegistrator is null)
        {
            throw new ArgumentNullException(nameof(managedRegistrator));
        }

        if (parameterFactory is null)
        {
            throw new ArgumentNullException(nameof(parameterFactory));
        }

        if (recorderFactory is null)
        {
            throw new ArgumentNullException(nameof(recorderFactory));
        }

        return new ArgumentExistenceRecorderMappingRegistrator<TParameter, TRecord, TParameterFactory, TRecorderFactory>(managedRegistrator, ContextFactory, parameterFactory, recorderFactory);
    }

    private sealed class ArgumentExistenceRecorderMappingRegistrator<TParameter, TRecord, TParameterFactory, TRecorderFactory>
        : IArgumentExistenceRecorderMappingRegistrator<TParameter, TRecord>
    {
        private readonly IManagedArgumentExistenceRecorderMappingRegistrator<TParameter, TRecord, TParameterFactory, TRecorderFactory> ManagedRegistrator;

        private readonly IManagedArgumentExistenceRecorderMappingRegistratorContextFactory ContextFactory;
        private readonly TParameterFactory ParameterFactory;
        private readonly TRecorderFactory RecorderFactory;

        public ArgumentExistenceRecorderMappingRegistrator(
            IManagedArgumentExistenceRecorderMappingRegistrator<TParameter, TRecord, TParameterFactory, TRecorderFactory> managedRegistrator,
            IManagedArgumentExistenceRecorderMappingRegistratorContextFactory contextFactory,
            TParameterFactory parameterFactory,
            TRecorderFactory recorderFactory)
        {
            ManagedRegistrator = managedRegistrator;

            ContextFactory = contextFactory;
            ParameterFactory = parameterFactory;
            RecorderFactory = recorderFactory;
        }

        void IArgumentExistenceRecorderMappingRegistrator<TParameter, TRecord>.Register(
            IArgumentExistenceRecorderMappingCollector<TParameter, TRecord> collector)
        {
            if (collector is null)
            {
                throw new ArgumentNullException(nameof(collector));
            }

            var context = ContextFactory.Create(collector, ParameterFactory, RecorderFactory);

            ManagedRegistrator.Register(context);
        }
    }
}
