namespace Attribinter.Mappers.Collectors.Managed;

/// <summary>Registers mappings from parameters to recorders with <see cref="IParameterMappingCollector{TParameter, TRecord, TData}"/>.</summary>
/// <typeparam name="TParameter">The type of the mapped parameters.</typeparam>
/// <typeparam name="TRecord">The type of the data record to which the mapped recorders record data.</typeparam>
/// <typeparam name="TData">The type of the data recorded by the mapped recorders.</typeparam>
/// <typeparam name="TParameterFactory">The type responsible for creating parameters.</typeparam>
/// <typeparam name="TRecorderFactory">The type handling creation of recorders.</typeparam>
public interface IManagedParameterMappingRegistrator<out TParameter, in TRecord, in TData, in TParameterFactory, in TRecorderFactory>
{
    /// <summary>Registers mappings from parameters to recorders with a <see cref="IParameterMappingCollector{TParameter, TRecord, TData}"/>.</summary>
    /// <param name="context">Provides context for the registrator.</param>
    public abstract void Register(IManagedParameterMappingRegistratorContext<TParameter, TRecord, TData, TParameterFactory, TRecorderFactory> context);
}
