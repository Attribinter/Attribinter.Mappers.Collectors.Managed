namespace Paraminter.Recorders.Mappers.Collectors.Managed;

/// <summary>Handles creation of <see cref="IManagedArgumentExistenceRecorderMappingRegistratorContext{TParameter, TRecord, TParameterFactory, TRecorderFactory}"/>.</summary>
public interface IManagedArgumentExistenceRecorderMappingRegistratorContextFactory
{
    /// <summary>Creates a <see cref="IManagedArgumentExistenceRecorderMappingRegistratorContext{TParameter, TRecord, TParameterFactory, TRecorderFactory}"/>.</summary>
    /// <typeparam name="TParameter">The type of the mapped parameters.</typeparam>
    /// <typeparam name="TRecord">The type of the record to which Existence is recorded.</typeparam>
    /// <typeparam name="TParameterFactory">The type handling creation of parameters.</typeparam>
    /// <typeparam name="TRecorderFactory">The type handling creation of recorders.</typeparam>
    /// <param name="collector">Collects mappings from parameters to recorders.</param>
    /// <param name="parameterFactory">Handles creation of parameters.</param>
    /// <param name="recorderFactory">Handles creation of recorders.</param>
    /// <returns>The created <see cref="IManagedArgumentExistenceRecorderMappingRegistratorContext{TParameter, TRecord, TParameterFactory, TRecorderFactory}"/>.</returns>
    public abstract IManagedArgumentExistenceRecorderMappingRegistratorContext<TParameter, TRecord, TParameterFactory, TRecorderFactory> Create<TParameter, TRecord, TParameterFactory, TRecorderFactory>(
        IArgumentExistenceRecorderMappingCollector<TParameter, TRecord> collector,
        TParameterFactory parameterFactory,
        TRecorderFactory recorderFactory);
}
