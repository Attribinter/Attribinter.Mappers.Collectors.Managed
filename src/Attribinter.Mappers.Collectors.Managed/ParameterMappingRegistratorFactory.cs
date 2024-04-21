namespace Attribinter.Mappers.Collectors.Managed;

using System;

/// <inheritdoc cref="IParameterMappingRegistratorFactory"/>
public sealed class ParameterMappingRegistratorFactory : IParameterMappingRegistratorFactory
{
    private readonly IManagedParameterMappingRegistratorContextFactory ContextFactory;

    /// <summary>Instantiates a <see cref="ParameterMappingRegistratorFactory"/>, handling creation of <see cref="IParameterMappingRegistrator{TParameter, TRecord, TData}"/> using <see cref="IManagedParameterMappingRegistrator{TParameter, TRecord, TData, TParameterFactory, TRecorderFactory}"/>.</summary>
    /// <param name="contextFactory">Handles creation of <see cref="IManagedParameterMappingRegistratorContext{TParameter, TRecord, TData, TParameterFactory, TRecorderFactory}"/>.</param>
    public ParameterMappingRegistratorFactory(IManagedParameterMappingRegistratorContextFactory contextFactory)
    {
        ContextFactory = contextFactory ?? throw new ArgumentNullException(nameof(contextFactory));
    }

    IParameterMappingRegistrator<TParameter, TRecord, TData> IParameterMappingRegistratorFactory.Create<TParameter, TRecord, TData, TParameterFactory, TRecorderFactory>(IManagedParameterMappingRegistrator<TParameter, TRecord, TData, TParameterFactory, TRecorderFactory> managedRegistrator, TParameterFactory parameterFactory, TRecorderFactory recorderFactory)
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

        return new ParameterMappingRegistrator<TParameter, TRecord, TData, TParameterFactory, TRecorderFactory>(managedRegistrator, ContextFactory, parameterFactory, recorderFactory);
    }

    private sealed class ParameterMappingRegistrator<TParameter, TRecord, TData, TParameterFactory, TRecorderFactory> : IParameterMappingRegistrator<TParameter, TRecord, TData>
    {
        private readonly IManagedParameterMappingRegistrator<TParameter, TRecord, TData, TParameterFactory, TRecorderFactory> ManagedRegistrator;

        private readonly IManagedParameterMappingRegistratorContextFactory ContextFactory;
        private readonly TParameterFactory ParameterFactory;
        private readonly TRecorderFactory RecorderFactory;

        public ParameterMappingRegistrator(IManagedParameterMappingRegistrator<TParameter, TRecord, TData, TParameterFactory, TRecorderFactory> managedRegistrator, IManagedParameterMappingRegistratorContextFactory contextFactory, TParameterFactory parameterFactory, TRecorderFactory recorderFactory)
        {
            ManagedRegistrator = managedRegistrator;

            ContextFactory = contextFactory;
            ParameterFactory = parameterFactory;
            RecorderFactory = recorderFactory;
        }

        void IParameterMappingRegistrator<TParameter, TRecord, TData>.Register(IParameterMappingCollector<TParameter, TRecord, TData> collector)
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
