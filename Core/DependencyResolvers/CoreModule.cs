﻿using System;
using System.Collections.Generic;
using System.Text;
using Core.CrossCuttingConcerns.Caching;
using Core.CrossCuttingConcerns.Caching.Microsoft;
using Core.Utilities.IoC;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Core.DependencyResolvers
{
    public class CoreModule : ICoreModule
    {
        public void Load(IServiceCollection serviceCollection)
        {
            serviceCollection.AddMemoryCache();//.net core otomatik injection yapması için IMemoryCache için eklendi
            serviceCollection.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            serviceCollection.AddSingleton<ICacheManeger, MemoryCacheManeger>();
            //serviceCollection.AddSingleton<ICacheManeger, RedisCacheManeger>(); farklı bir cache teknolojisine geçmek için yapılcak işlem örneği
        }
    }
}