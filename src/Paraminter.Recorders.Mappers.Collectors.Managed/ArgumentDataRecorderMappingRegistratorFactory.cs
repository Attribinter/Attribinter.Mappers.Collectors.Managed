namespace Paraminter.Recorders.Mappers.Collectors.Managed;

using System;

/// <inheritdoc cref="IArgumentDataRecorderMappingRegistratorFactory"/>
public sealed class ArgumentDataRecorderMappingRegistratorFactory
    : IArgumentDataRecorderMappingRegistratorFactory
{
    private readonly IManagedArgumentDataRecorderMappingRegistratorContextFactory ContextFactory;

    /// <summary>Instantiates a <see cref="ArgumentDataRecorderMappingRegistratorFactory"/>, handling creation of <see cref="IArgumentDataRecorderMappingRegistrator{TParameter, TRecord, TArgumentData}"/> using <see cref="IManagedArgumentDataRecorderMappingRegistrator{TParameter, TRecord, TArgumentData, TParameterFactory, TRecorderFactory}"/>.</summary>
    /// <param name="contextFactory">Handles creation of <see cref="IManagedArgumentDataRecorderMappingRegistratorContext{TParameter, TRecord, TArgumentData, TParameterFactory, TRecorderFactory}"/>.</param>
    public ArgumentDataRecorderMappingRegistratorFactory(
        IManagedArgumentDataRecorderMappingRegistratorContextFactory contextFactory)
    {
        ContextFactory = contextFactory ?? throw new ArgumentNullException(nameof(contextFactory));
    }

    IArgumentDataRecorderMappingRegistrator<TParameter, TRecord, TArgumentData> IArgumentDataRecorderMappingRegistratorFactory.Create<TParameter, TRecord, TArgumentData, TParameterFactory, TRecorderFactory>(
        IManagedArgumentDataRecorderMappingRegistrator<TParameter, TRecord, TArgumentData, TParameterFactory, TRecorderFactory> managedRegistrator,
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

        return new ArgumentDataRecorderMappingRegistrator<TParameter, TRecord, TArgumentData, TParameterFactory, TRecorderFactory>(managedRegistrator, ContextFactory, parameterFactory, recorderFactory);
    }

    private sealed class ArgumentDataRecorderMappingRegistrator<TParameter, TRecord, TArgumentData, TParameterFactory, TRecorderFactory>
        : IArgumentDataRecorderMappingRegistrator<TParameter, TRecord, TArgumentData>
    {
        private readonly IManagedArgumentDataRecorderMappingRegistrator<TParameter, TRecord, TArgumentData, TParameterFactory, TRecorderFactory> ManagedRegistrator;

        private readonly IManagedArgumentDataRecorderMappingRegistratorContextFactory ContextFactory;
        private readonly TParameterFactory ParameterFactory;
        private readonly TRecorderFactory RecorderFactory;

        public ArgumentDataRecorderMappingRegistrator(
            IManagedArgumentDataRecorderMappingRegistrator<TParameter, TRecord, TArgumentData, TParameterFactory, TRecorderFactory> managedRegistrator,
            IManagedArgumentDataRecorderMappingRegistratorContextFactory contextFactory,
            TParameterFactory parameterFactory,
            TRecorderFactory recorderFactory)
        {
            ManagedRegistrator = managedRegistrator;

            ContextFactory = contextFactory;
            ParameterFactory = parameterFactory;
            RecorderFactory = recorderFactory;
        }

        void IArgumentDataRecorderMappingRegistrator<TParameter, TRecord, TArgumentData>.Register(
            IArgumentDataRecorderMappingCollector<TParameter, TRecord, TArgumentData> collector)
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
