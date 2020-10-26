using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace Cicanci.Utils
{
    public class Services : IDisposable
    {
        private readonly Dictionary<Type, BaseService> _services;

        public Services()
        {
            _services = new Dictionary<Type, BaseService>();
        }

        public void Dispose()
        {
            foreach(var item in _services)
            {
                item.Value.Dispose();
            }
            _services.Clear();
        }

        public void Register<T>() where T : BaseService
        {
            if(_services.TryGetValue(typeof(T), out BaseService service))
            {
                Debug.LogWarning($"[Cicanci.Services] Service {typeof(T)} already registered");
                return;
            }

            ConstructorInfo constructor = typeof(T).GetConstructor(new Type[0]);
            service = (T)constructor.Invoke(null);
            _services.Add(typeof(T), service);
        }

        public void Unregister<T>() where T : BaseService
        {
            if(!_services.TryGetValue(typeof(T), out BaseService service))
            {
                Debug.LogWarning($"[Cicanci.Services] Service {typeof(T)} not found to unregister");
                return;
            }
            
            _services.Remove(typeof(T));
        }

        public T Get<T>() where T : BaseService
        {
            if(_services.TryGetValue(typeof(T), out BaseService service))
            {
                return (T)service;
            }

            Debug.LogWarning($"[Cicanci.Services] Service {typeof(T)} not found. Did you register it?");
            return default;
        }
    }
}