
using UnityEngine;

namespace Cicanci.Utils
{
    public class LocalizationService : BaseService
    {
        public override void Initialize()
        {
            base.Initialize();

            IsReady = true;
        }

        public int Test()
        {
            return 42;
        }
    }
}