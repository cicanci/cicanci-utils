using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace Cicanci.Utils
{
    public class Service : IDisposable
    {
        private readonly Dictionary<Type, IService> _services;

        public Service()
        {
            _services = new Dictionary<Type, IService>();
        }

        public void Dispose()
        {
            // TODO
        }

        public void Register<T>() where T : IService
        {
            if(_services.TryGetValue(typeof(T), out IService service))
            {
                Debug.LogWarning($"[Cicanci.Services] Service {typeof(T)} already registered");
                return;
            }

            ConstructorInfo constructor = typeof(T).GetConstructor(new Type[0]);
            service = (T)constructor.Invoke(null);
            _services.Add(typeof(T), service);
        }

        public void Unregister<T>() where T : IService
        {
            if(!_services.TryGetValue(typeof(T), out IService service))
            {
                Debug.LogWarning($"[Cicanci.Services] Service {typeof(T)} not found to unregister");
                return;
            }
            
            _services.Remove(typeof(T));
        }

        public IService Get<T>() where T : IService
        {
            if(_services.TryGetValue(typeof(T), out IService service))
            {
                return service;
            }

            return null;
        }
    }
}