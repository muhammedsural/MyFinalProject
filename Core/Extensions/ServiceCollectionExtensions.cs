using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.IoC;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Extensions
{
    public static class ServiceCollectionExtensions //Extension yapacağımız class static olmalı
    {
        public static IServiceCollection AddDependencyResolvers
        (this IServiceCollection serviceCollection, ICoreModule[] modules)//Injection edeceğimiz modulleri array olarak gönderiyoruz params veya collection olarakta gönderebiliriz.
        {
            foreach (var module in modules)
            {
                module.Load(serviceCollection);//IServiceCollection tipinde modüllerimizi yüklüyoruz
            }

            return ServiceTool.Create(serviceCollection);//Injectionı tamamlıyoruz
        }
    }
}
