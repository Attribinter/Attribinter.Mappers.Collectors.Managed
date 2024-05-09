namespace Paraminter.Mappers.Collectors.Managed;

using Microsoft.Extensions.DependencyInjection;

using System;

/// <summary>Allows the services provided by <i>Paraminter.Mappers.Collectors.Managed</i> to be registered with a <see cref="IServiceCollection"/>.</summary>
public static class ParaminterManagedMapperCollectorsServices
{
    /// <summary>Registers the services provided by <i>Paraminter.Mappers.Collectors.Managed</i> with the provided <see cref="IServiceCollection"/>.</summary>
    /// <param name="services">The <see cref="IServiceCollection"/> with which services are registered.</param>
    /// <returns>The provided <see cref="IServiceCollection"/>, so that calls can be chained.</returns>
    public static IServiceCollection AddParaminterManagedMapperCollectors(this IServiceCollection services)
    {
        if (services is null)
        {
            throw new ArgumentNullException(nameof(services));
        }

        services.AddTransient<IManagedParameterMappingRegistratorContextFactory, ManagedParameterMappingRegistratorContextFactory>();

        services.AddTransient<IParameterMappingRegistratorFactory, ParameterMappingRegistratorFactory>();

        return services;
    }
}
