namespace Paraminter.Mappers.Collectors.Managed;

using System;

/// <inheritdoc cref="IParameterMappingRegistratorFactory"/>
public sealed class ParameterMappingRegistratorFactory : IParameterMappingRegistratorFactory
{
    private readonly IManagedParameterMappingRegistratorContextFactory ContextFactory;

    /// <summary>Instantiates a <see cref="ParameterMappingRegistratorFactory"/>, handling creation of <see cref="IParameterMappingRegistrator{TParameter, TRecord, TArgumentData}"/> using <see cref="IManagedParameterMappingRegistrator{TParameter, TRecord, TArgumentData, TParameterFactory, TRecorderFactory}"/>.</summary>
    /// <param name="contextFactory">Handles creation of <see cref="IManagedParameterMappingRegistratorContext{TParameter, TRecord, TArgumentData, TParameterFactory, TRecorderFactory}"/>.</param>
    public ParameterMappingRegistratorFactory(IManagedParameterMappingRegistratorContextFactory contextFactory)
    {
        ContextFactory = contextFactory ?? throw new ArgumentNullException(nameof(contextFactory));
    }

    IParameterMappingRegistrator<TParameter, TRecord, TArgumentData> IParameterMappingRegistratorFactory.Create<TParameter, TRecord, TArgumentData, TParameterFactory, TRecorderFactory>(IManagedParameterMappingRegistrator<TParameter, TRecord, TArgumentData, TParameterFactory, TRecorderFactory> managedRegistrator, TParameterFactory parameterFactory, TRecorderFactory recorderFactory)
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

        return new ParameterMappingRegistrator<TParameter, TRecord, TArgumentData, TParameterFactory, TRecorderFactory>(managedRegistrator, ContextFactory, parameterFactory, recorderFactory);
    }

    private sealed class ParameterMappingRegistrator<TParameter, TRecord, TArgumentData, TParameterFactory, TRecorderFactory> : IParameterMappingRegistrator<TParameter, TRecord, TArgumentData>
    {
        private readonly IManagedParameterMappingRegistrator<TParameter, TRecord, TArgumentData, TParameterFactory, TRecorderFactory> ManagedRegistrator;

        private readonly IManagedParameterMappingRegistratorContextFactory ContextFactory;
        private readonly TParameterFactory ParameterFactory;
        private readonly TRecorderFactory RecorderFactory;

        public ParameterMappingRegistrator(IManagedParameterMappingRegistrator<TParameter, TRecord, TArgumentData, TParameterFactory, TRecorderFactory> managedRegistrator, IManagedParameterMappingRegistratorContextFactory contextFactory, TParameterFactory parameterFactory, TRecorderFactory recorderFactory)
        {
            ManagedRegistrator = managedRegistrator;

            ContextFactory = contextFactory;
            ParameterFactory = parameterFactory;
            RecorderFactory = recorderFactory;
        }

        void IParameterMappingRegistrator<TParameter, TRecord, TArgumentData>.Register(IParameterMappingCollector<TParameter, TRecord, TArgumentData> collector)
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
