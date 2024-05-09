namespace Paraminter.Mappers.Collectors.Managed;

/// <summary>Handles creation of <see cref="IParameterMappingRegistrator{TParameter, TRecord, TArgumentData}"/> using <see cref="IManagedParameterMappingRegistrator{TParameter, TRecord, TArgumentData, TParameterFactory, TRecorderFactory}"/>.</summary>
public interface IParameterMappingRegistratorFactory
{
    /// <summary>Creates a <see cref="IParameterMappingRegistrator{TParameter, TRecord, TArgumentData}"/>.</summary>
    /// <typeparam name="TParameter">The type of the mapped parameters.</typeparam>
    /// <typeparam name="TRecord">The type of the record to which data is recorded.</typeparam>
    /// <typeparam name="TArgumentData">The type representing data about the arguments.</typeparam>
    /// <typeparam name="TParameterFactory">The type handling creation of parameters.</typeparam>
    /// <typeparam name="TRecorderFactory">The type handling creation of recorders.</typeparam>
    /// <param name="managedRegistrator">Registers mappings from parameters to recorders with <see cref="IParameterMappingCollector{TParameter, TRecord, TArgumentData}"/>.</param>
    /// <param name="parameterFactory">Handles creation of parameters.</param>
    /// <param name="recorderFactory">Handles creation of recorders.</param>
    /// <returns>The created <see cref="IParameterMappingRegistrator{TParameter, TRecord, TArgumentData}"/>.</returns>
    public abstract IParameterMappingRegistrator<TParameter, TRecord, TArgumentData> Create<TParameter, TRecord, TArgumentData, TParameterFactory, TRecorderFactory>(IManagedParameterMappingRegistrator<TParameter, TRecord, TArgumentData, TParameterFactory, TRecorderFactory> managedRegistrator, TParameterFactory parameterFactory, TRecorderFactory recorderFactory);
}
