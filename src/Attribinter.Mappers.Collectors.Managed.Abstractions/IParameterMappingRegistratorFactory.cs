namespace Attribinter.Mappers.Collectors.Managed;

/// <summary>Handles creation of <see cref="IParameterMappingRegistrator{TParameter, TRecord, TData}"/> using <see cref="IManagedParameterMappingRegistrator{TParameter, TRecord, TData, TParameterFactory, TRecorderFactory}"/>.</summary>
public interface IParameterMappingRegistratorFactory
{
    /// <summary>Creates a <see cref="IParameterMappingRegistrator{TParameter, TRecord, TData}"/>.</summary>
    /// <typeparam name="TParameter">The type of the mapped parameters.</typeparam>
    /// <typeparam name="TRecord">The type of the data record to which the mapped recorders record data.</typeparam>
    /// <typeparam name="TData">The type of the data recorded by the mapped recorders.</typeparam>
    /// <typeparam name="TParameterFactory">The type handling creation of parameters.</typeparam>
    /// <typeparam name="TRecorderFactory">The type handling creation of recorders.</typeparam>
    /// <param name="managedRegistrator">Registers mappings from parameters to recorders with <see cref="IParameterMappingCollector{TParameter, TRecord, TData}"/>.</param>
    /// <param name="parameterFactory">Handles creation of parameters.</param>
    /// <param name="recorderFactory">Handles creation of recorders.</param>
    /// <returns>The created <see cref="IParameterMappingRegistrator{TParameter, TRecord, TData}"/>.</returns>
    public abstract IParameterMappingRegistrator<TParameter, TRecord, TData> Create<TParameter, TRecord, TData, TParameterFactory, TRecorderFactory>(IManagedParameterMappingRegistrator<TParameter, TRecord, TData, TParameterFactory, TRecorderFactory> managedRegistrator, TParameterFactory parameterFactory, TRecorderFactory recorderFactory);
}
