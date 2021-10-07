using System;
using System.Collections.Generic;

namespace FrameworkDesign.Framework.IOC
{
    public class IOCContainer
    {
        private Dictionary<Type, object> mInstance = new Dictionary<Type, object>();

        public void Register<T>(T instance)
        {
            var key = typeof(T);
            if (mInstance.ContainsKey(key))
            {
                mInstance[key] = instance;
            }
            else
            {
                mInstance.Add(key, instance);
            }
        }

        public T Get<T>() where T : class
        {
            var key = typeof(T);

            if (mInstance.TryGetValue(key, out var retInstance))
            {
                return retInstance as T;
            }

            return null;
        }
    }
}