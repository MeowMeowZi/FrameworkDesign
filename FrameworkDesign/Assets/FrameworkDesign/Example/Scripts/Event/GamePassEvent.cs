using System;
using UnityEngine;

namespace FrameworkDesign.Example
{
    public class GamePassEvent : MonoBehaviour
    {
        private static Action mOnevent;

        public static void Register(Action onEvent)
        {
            mOnevent += onEvent;
        }

        public static void Unregister(Action onEvent)
        {
            mOnevent -= onEvent;
        }

        public static void Trigger()
        {
            mOnevent?.Invoke();
        }
    }
}