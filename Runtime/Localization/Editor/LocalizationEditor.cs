using System.IO;
using UnityEditor;
using UnityEngine;

namespace Cicanci.Utils
{
    public class LocalizationEditor : EditorWindow
    {
#if CICANCI_ENABLE_DEV
        [MenuItem("Cicanci/Localization/Load CSV")]
#endif
        private static void LoadCSV()
        {
            string path = EditorUtility.OpenFilePanel("Load localization CSV", "", "csv");
            if (path.Length == 0)
            {
                return;
            }

            string[] fileContent = File.ReadAllLines(path);
            if (fileContent == null || fileContent.Length == 0)
            {
                return;
            }
                
            for (int i = 0; i < fileContent.Length; i++)
            {
                Logger.Log(fileContent[i]);
            }   
        }
    }
}