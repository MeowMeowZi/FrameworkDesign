#if UNITY_EDITOR
using UnityEditor;
#endif
using FrameworkDesign.Framework.Architecture;
using UnityEngine;

namespace CountApp.Scripts
{
    public interface IStorage : IUtility
    {
        void SaveInt(string key, int value);

        int LoadInt(string key, int defaultInt = 0);
    }

    public class PlayerPresStorage : IStorage
    {
        public void SaveInt(string key, int value)
        {
            PlayerPrefs.SetInt(key, value);
        }

        public int LoadInt(string key, int defaultInt = 0)
        {
            return PlayerPrefs.GetInt(key, defaultInt);
        }
    }

    public class EditorPresStorage : IStorage
    {
        public void SaveInt(string key, int value)
        {
#if UNITY_EDITOR
            EditorPrefs.SetInt(key, value);      
#endif
        }

        public int LoadInt(string key, int defaultInt = 0)
        {
#if UNITY_EDITOR
            return EditorPrefs.GetInt(key, defaultInt);
#else
            return 0;
#endif
        }
    }
}