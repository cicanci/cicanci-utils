
namespace Cicanci
{
    public class BaseService : IService
    {
        public bool IsReady { get; protected set; }

        public virtual void Initialize()
        {
            //
        }
    }
}
