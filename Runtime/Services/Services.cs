using System;
using System.Collections.Generic;
using UnityEngine;

namespace Cicanci
{
    public class Services : IDisposable
    {
        private readonly Dictionary<Type, IService> _services;

        public Services()
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

            _services.Add(typeof(T), default(T));
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

        public IService Get<T>(bool forceRegister = false) where T : IService
        {
            if(_services.TryGetValue(typeof(T), out IService service))
            {
                return service;
            }

            if(forceRegister)
            {
                service = default(T);
                _services.Add(typeof(T), service);
                return service;
            }

            return null;
        }
    }
}