﻿using Castle.DynamicProxy;
using CoreLayer.CrossCuttingConcerns.Caching;
using CoreLayer.Utilities.Interceptors;
using CoreLayer.Utilities.IoC;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.Aspects.Autofac
{
    public class CacheAspect : MethodInterception
    {
        private int _duration;
        ICacheManager _cacheManager;
        public CacheAspect(int duration = 100)
        {
            _duration = duration;
            _cacheManager = ServiceTool.ServiceProvider.GetService<ICacheManager>();
        }
        public override void Intercept(IInvocation invocation)
        {
            var methodName = string.Format($"{invocation.Method.ReflectedType.FullName}).{invocation.Method.Name}");
            var arguments = invocation.Arguments.ToList();
            var key = $"{methodName}({string.Join(",", arguments.Select(x => x?.ToString() ?? "<Null>"))})";
            if (_cacheManager.IsAdded(key))
            {
                invocation.ReturnValue = _cacheManager.Get(key);
                return;
            }
            invocation.Proceed();
            _cacheManager.Add(key,invocation.ReturnValue,_duration);
        }
    }
}
