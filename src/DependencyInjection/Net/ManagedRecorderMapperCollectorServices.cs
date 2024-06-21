namespace Paraminter.Recorders.Mappers.Collectors.Managed;

using Microsoft.Extensions.DependencyInjection;

using System;

/// <summary>Allows the services provided by <i>Paraminter.RecordersMappers.Collectors.Managed</i> to be registered with a <see cref="IServiceCollection"/>.</summary>
public static class ManagedRecorderMapperCollectorServices
{
    /// <summary>Registers the services provided by <i>Paraminter.Recorders.Mappers.Collectors.Managed</i> with the provided <see cref="IServiceCollection"/>.</summary>
    /// <param name="services">The <see cref="IServiceCollection"/> with which services are registered.</param>
    /// <returns>The provided <see cref="IServiceCollection"/>, so that calls can be chained.</returns>
    public static IServiceCollection AddParaminterManagedRecorderMapperCollectors(this IServiceCollection services)
    {
        if (services is null)
        {
            throw new ArgumentNullException(nameof(services));
        }

        services.AddTransient<IManagedArgumentDataRecorderMappingRegistratorContextFactory, ManagedArgumentDataRecorderMappingRegistratorContextFactory>();
        services.AddTransient<IManagedArgumentExistenceRecorderMappingRegistratorContextFactory, ManagedArgumentExistenceRecorderMappingRegistratorContextFactory>();

        services.AddTransient<IArgumentDataRecorderMappingRegistratorFactory, ArgumentDataRecorderMappingRegistratorFactory>();
        services.AddTransient<IArgumentExistenceRecorderMappingRegistratorFactory, ArgumentExistenceRecorderMappingRegistratorFactory>();

        return services;
    }
}
