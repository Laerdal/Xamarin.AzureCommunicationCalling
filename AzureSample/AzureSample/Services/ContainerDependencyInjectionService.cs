using AzureSample.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace AzureSample
{
    public class ContainerDependencyInjectionService
    {

        private static IServiceProvider _provider;

        public static void Init(Action<IServiceCollection> configureServices = null)
        {
            IServiceCollection services = new ServiceCollection();
            ConfigureServices(services);
            configureServices?.Invoke(services);

            _provider = services.BuildServiceProvider();
        }

        public static T GetService<T>()
        {
            return _provider.GetRequiredService<T>();
        }

        public static object GetService(Type serviceType)
        {
            return _provider.GetRequiredService(serviceType);
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            RegisterViewModels(services);
        }

        private static void RegisterViewModels(IServiceCollection services)
        {
           // services.AddTransient<>();

        }
    }
}