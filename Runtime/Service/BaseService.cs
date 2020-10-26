using System;

namespace Cicanci.Utils
{
    public class BaseService : IDisposable, IService
    {
        public bool IsReady { get; protected set; }

        public virtual void Dispose()
        {
            IsReady = false;
        }

        public virtual void Initialize()
        {
            IsReady = true;
        }
    }
}
