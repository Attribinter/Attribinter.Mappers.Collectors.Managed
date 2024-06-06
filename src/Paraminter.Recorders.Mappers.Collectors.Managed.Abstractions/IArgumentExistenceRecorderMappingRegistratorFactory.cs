namespace Paraminter.Recorders.Mappers.Collectors.Managed;

/// <summary>Handles creation of <see cref="IArgumentExistenceRecorderMappingRegistrator{TParameter, TRecord}"/> using <see cref="IManagedArgumentExistenceRecorderMappingRegistrator{TParameter, TRecord, TParameterFactory, TRecorderFactory}"/>.</summary>
public interface IArgumentExistenceRecorderMappingRegistratorFactory
{
    /// <summary>Creates a <see cref="IArgumentExistenceRecorderMappingRegistrator{TParameter, TRecord}"/>.</summary>
    /// <typeparam name="TParameter">The type of the mapped parameters.</typeparam>
    /// <typeparam name="TRecord">The type of the record to which Existence is recorded.</typeparam>
    /// <typeparam name="TParameterFactory">The type handling creation of parameters.</typeparam>
    /// <typeparam name="TRecorderFactory">The type handling creation of recorders.</typeparam>
    /// <param name="managedRegistrator">Registers mappings from parameters to recorders with <see cref="IArgumentExistenceRecorderMappingCollector{TParameter, TRecord}"/>.</param>
    /// <param name="parameterFactory">Handles creation of parameters.</param>
    /// <param name="recorderFactory">Handles creation of recorders.</param>
    /// <returns>The created <see cref="IArgumentExistenceRecorderMappingRegistrator{TParameter, TRecord}"/>.</returns>
    public abstract IArgumentExistenceRecorderMappingRegistrator<TParameter, TRecord> Create<TParameter, TRecord, TParameterFactory, TRecorderFactory>(
        IManagedArgumentExistenceRecorderMappingRegistrator<TParameter, TRecord, TParameterFactory, TRecorderFactory> managedRegistrator,
        TParameterFactory parameterFactory,
        TRecorderFactory recorderFactory);
}
