using System;
using System.Threading;

namespace FrameworkDesign.Framework.Event
{
    public class Event<T> where T : Event<T>
    {
        private static Action _mOnEvent;

        /// <summary>
        /// 注册事件
        /// </summary>
        /// <param name="onEvent"></param>
        public static void Register(Action onEvent)
        {
            _mOnEvent += onEvent;
        }

        /// <summary>
        /// 注销事件
        /// </summary>
        /// <param name="onEvent"></param>
        public static void UnRegister(Action onEvent)
        {
            _mOnEvent -= onEvent;
        }

        /// <summary>
        /// 事件触发
        /// </summary>
        public static void Trigger()
        {
            _mOnEvent?.Invoke();
        }
    }
}