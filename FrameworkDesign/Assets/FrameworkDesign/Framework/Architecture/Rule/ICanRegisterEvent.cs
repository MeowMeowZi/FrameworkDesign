using System;
using FrameworkDesign.Framework.Event;

namespace FrameworkDesign.Framework.Architecture.Rule
{
    public interface ICanRegisterEvent : IBelongToArchitecture
    {
        
    }

    public static class CanRegisterEventExtension
    {
        public static IUnregister RegisterEvent<T>(this ICanRegisterEvent self, Action<T> onEvent)
        {
            return self.GetArchitecture().RegisterEvent<T>(onEvent);
        }

        public static void Unregister<T>(this ICanRegisterEvent self, Action<T> onEvent)
        {
            self.GetArchitecture().UnregisterEvent<T>(onEvent);
        }
    }
}