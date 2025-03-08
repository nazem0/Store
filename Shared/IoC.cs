using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Shared
{
    public static class IoC
    {
        public interface IScoped;
        public interface ISingleton;
        public interface ITransient;
        public static IServiceCollection ConfigureIoC(this IServiceCollection services, Assembly assembly)
        {
            var allTypes = assembly.GetTypes();
            var scopedType = allTypes.Where(t => t.GetInterface(nameof(IScoped)) != null).ToList();
            var singletonType = allTypes.Where(t => t.GetInterface(nameof(ISingleton)) != null).ToList();
            var transientType = allTypes.Where(t => t.GetInterface(nameof(ITransient)) != null).ToList();
            scopedType.ForEach(x => services.AddScoped(x));
            singletonType.ForEach(x => services.AddSingleton(x));
            transientType.ForEach(x => services.AddTransient(x));
            return services;
        }
    }
}