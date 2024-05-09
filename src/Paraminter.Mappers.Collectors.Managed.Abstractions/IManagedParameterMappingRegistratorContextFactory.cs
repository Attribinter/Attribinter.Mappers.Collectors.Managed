namespace Paraminter.Mappers.Collectors.Managed;

/// <summary>Handles creation of <see cref="IManagedParameterMappingRegistratorContext{TParameter, TRecord, TArgumentData, TParameterFactory, TRecorderFactory}"/>.</summary>
public interface IManagedParameterMappingRegistratorContextFactory
{
    /// <summary>Creates a <see cref="IManagedParameterMappingRegistratorContext{TParameter, TRecord, TArgumentData, TParameterFactory, TRecorderFactory}"/>.</summary>
    /// <typeparam name="TParameter">The type of the mapped parameters.</typeparam>
    /// <typeparam name="TRecord">The type of the record to which data is recorded.</typeparam>
    /// <typeparam name="TArgumentData">The type representing data about the arguments.</typeparam>
    /// <typeparam name="TParameterFactory">The type handling creation of parameters.</typeparam>
    /// <typeparam name="TRecorderFactory">The type handling creation of recorders.</typeparam>
    /// <param name="collector">Collects mappings from parameters to recorders.</param>
    /// <param name="parameterFactory">Handles creation of parameters.</param>
    /// <param name="recorderFactory">Handles creation of recorders.</param>
    /// <returns>The created <see cref="IManagedParameterMappingRegistratorContext{TParameter, TRecord, ArgumentTData, TParameterFactory, TRecorderFactory}"/>.</returns>
    public abstract IManagedParameterMappingRegistratorContext<TParameter, TRecord, TArgumentData, TParameterFactory, TRecorderFactory> Create<TParameter, TRecord, TArgumentData, TParameterFactory, TRecorderFactory>(IParameterMappingCollector<TParameter, TRecord, TArgumentData> collector, TParameterFactory parameterFactory, TRecorderFactory recorderFactory);
}
