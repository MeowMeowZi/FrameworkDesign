using System;
using UnityEngine;

namespace FrameworkDesign.Example.Scripts.Event
{
    public static class GamePassEvent
    {
        private static Action mOnEvent;

        public static void Register(Action onEvent)
        {
            mOnEvent += onEvent;
        }

        public static void Unregister(Action onEvent)
        {
            mOnEvent -= onEvent;
        }

        public static void Trigger()
        {
            mOnEvent?.Invoke();
        }
    }
}