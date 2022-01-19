using MediatR;
using Microsoft.Extensions.DependencyInjection;


namespace DB.lib.commands
{
    public static class Configure
    {
        public static void AddAppMediatR(this IServiceCollection services)
        {
            var assembly = typeof(Configure).Assembly;

            services.AddMediatR(assembly);
        }
    }
}
