using ChallangeMottu.Application.UseCase;
using Microsoft.Extensions.DependencyInjection;

namespace ChallangeMottu.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IMotoService, MotoService>();
        services.AddScoped<ILocalizacaoAtualService, LocalizacaoAtualService>();
        
        return services;
    }
}