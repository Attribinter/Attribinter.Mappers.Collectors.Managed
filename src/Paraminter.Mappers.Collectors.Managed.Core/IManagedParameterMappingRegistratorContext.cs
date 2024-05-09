namespace Paraminter.Mappers.Collectors.Managed;

/// <summary>Provides context for <see cref="IManagedParameterMappingRegistrator{TParameter, TRecord, TArgumentData, TParameterFactory, TRecorderFactory}"/>.</summary>
/// <typeparam name="TParameter">The type of the mapped parameters.</typeparam>
/// <typeparam name="TRecord">The type of the record to which data is recorded.</typeparam>
/// <typeparam name="TArgumentData">The type representing data about the arguments.</typeparam>
/// <typeparam name="TParameterFactory">The type handling creation of parameters.</typeparam>
/// <typeparam name="TRecorderFactory">The type handling creation of recorders.</typeparam>
public interface IManagedParameterMappingRegistratorContext<in TParameter, out TRecord, out TArgumentData, out TParameterFactory, out TRecorderFactory>
{
    /// <summary>Collects mappings from parameters to recorders.</summary>
    public abstract IParameterMappingCollector<TParameter, TRecord, TArgumentData> Collector { get; }

    /// <summary>Handles creation of parameters.</summary>
    public abstract TParameterFactory ParameterFactory { get; }

    /// <summary>Handles creation of recorders.</summary>
    public abstract TRecorderFactory RecorderFactory { get; }
}
