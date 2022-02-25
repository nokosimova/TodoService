using System.Reflection;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace TodoService.Application.Extentions
{
    public static class DependencyInjection
    {
            public static IServiceCollection AddApplication(this IServiceCollection services)
            {
                services.AddAutoMapper(Assembly.GetExecutingAssembly());
                services.AddMediatR(Assembly.GetExecutingAssembly());
                return services;
            }
    }
}