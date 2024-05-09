namespace Paraminter.Mappers.Collectors.Managed;

/// <summary>Registers mappings from parameters to recorders with <see cref="IParameterMappingCollector{TParameter, TRecord, TArgumentData}"/>.</summary>
/// <typeparam name="TParameter">The type of the mapped parameters.</typeparam>
/// <typeparam name="TRecord">The type of the record to which data is recorded.</typeparam>
/// <typeparam name="TArgumentData">The type representing data about the arguments.</typeparam>
/// <typeparam name="TParameterFactory">The type responsible for creating parameters.</typeparam>
/// <typeparam name="TRecorderFactory">The type handling creation of recorders.</typeparam>
public interface IManagedParameterMappingRegistrator<out TParameter, in TRecord, in TArgumentData, in TParameterFactory, in TRecorderFactory>
{
    /// <summary>Registers mappings from parameters to recorders with a <see cref="IParameterMappingCollector{TParameter, TRecord, TArgumentData}"/>.</summary>
    /// <param name="context">Provides context for the registrator.</param>
    public abstract void Register(IManagedParameterMappingRegistratorContext<TParameter, TRecord, TArgumentData, TParameterFactory, TRecorderFactory> context);
}
