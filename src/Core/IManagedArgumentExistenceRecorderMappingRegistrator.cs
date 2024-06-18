namespace Paraminter.Recorders.Mappers.Collectors.Managed;

/// <summary>Registers mappings from parameters to recorders with <see cref="IArgumentExistenceRecorderMappingCollector{TParameter, TRecord}"/>.</summary>
/// <typeparam name="TParameter">The type of the mapped parameters.</typeparam>
/// <typeparam name="TRecord">The type of the record to which data is recorded.</typeparam>
/// <typeparam name="TParameterFactory">The type responsible for creating parameters.</typeparam>
/// <typeparam name="TRecorderFactory">The type handling creation of recorders.</typeparam>
public interface IManagedArgumentExistenceRecorderMappingRegistrator<out TParameter, in TRecord, in TParameterFactory, in TRecorderFactory>
{
    /// <summary>Registers mappings from parameters to recorders with a <see cref="IArgumentExistenceRecorderMappingCollector{TParameter, TRecord}"/>.</summary>
    /// <param name="context">Provides context for the registrator.</param>
    public abstract void Register(
        IManagedArgumentExistenceRecorderMappingRegistratorContext<TParameter, TRecord, TParameterFactory, TRecorderFactory> context);
}
