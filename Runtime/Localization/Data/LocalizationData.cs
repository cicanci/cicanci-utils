using UnityEngine;

namespace Cicanci.Localization
{
#if CICANCI_ENABLE_DEV
    [CreateAssetMenu(fileName = "LocalizationData", menuName = "Cicanci/Localization/Create Data", order = 0)]
#endif
    public class LocalizationData : ScriptableObject 
    {
        public SystemLanguage Language = SystemLanguage.English;
    }
}