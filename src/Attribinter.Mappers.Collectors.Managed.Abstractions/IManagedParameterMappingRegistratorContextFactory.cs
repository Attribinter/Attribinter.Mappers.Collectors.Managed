namespace Attribinter.Mappers.Collectors.Managed;

/// <summary>Handles creation of <see cref="IManagedParameterMappingRegistratorContext{TParameter, TRecord, TData, TParameterFactory, TRecorderFactory}"/>.</summary>
public interface IManagedParameterMappingRegistratorContextFactory
{
    /// <summary>Creates a <see cref="IManagedParameterMappingRegistratorContext{TParameter, TRecord, TData, TParameterFactory, TRecorderFactory}"/>.</summary>
    /// <typeparam name="TParameter">The type of the mapped parameters.</typeparam>
    /// <typeparam name="TRecord">The type of the data record to which the mapped recorders record data.</typeparam>
    /// <typeparam name="TData">The type of the data recorded by the mapped recorders.</typeparam>
    /// <typeparam name="TParameterFactory">The type handling creation of parameters.</typeparam>
    /// <typeparam name="TRecorderFactory">The type handling creation of recorders.</typeparam>
    /// <param name="collector">Collects mappings from parameters to recorders.</param>
    /// <param name="parameterFactory">Handles creation of parameters.</param>
    /// <param name="recorderFactory">Handles creation of recorders.</param>
    /// <returns>The created <see cref="IManagedParameterMappingRegistratorContext{TParameter, TRecord, TData, TParameterFactory, TRecorderFactory}"/>.</returns>
    public abstract IManagedParameterMappingRegistratorContext<TParameter, TRecord, TData, TParameterFactory, TRecorderFactory> Create<TParameter, TRecord, TData, TParameterFactory, TRecorderFactory>(IParameterMappingCollector<TParameter, TRecord, TData> collector, TParameterFactory parameterFactory, TRecorderFactory recorderFactory);
}
