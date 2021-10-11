using System;
using System.Collections.Generic;
using UnityEngine;

namespace FrameworkDesign.Framework.Event
{
    public interface ITypeEventSystem
    {
        void Send<T>() where T : new();
        void Send<T>(T e);
        IUnregister Register<T>(Action<T> onEvent);
        void Unregister<T>(Action<T> onEvent);
    }

    public interface IUnregister
    {
        void Unregister();
    }

    public struct TypeEventSystemUnregister<T> : IUnregister
    {
        public ITypeEventSystem TypeEventSystem { get; set; }
        public Action<T> OnEvent { get; set; }
        
        public void Unregister()
        {
            TypeEventSystem.Unregister(OnEvent);

            TypeEventSystem = null;

            OnEvent = null;
        }
    }

    public class UnregisterOnDestroyTrigger : MonoBehaviour
    {
        private HashSet<IUnregister> mUnregisters = new HashSet<IUnregister>();

        public void AddUnregister(IUnregister unregister)
        {
            mUnregisters.Add(unregister);
        }

        private void OnDestroy()
        {
            foreach (var unregister in mUnregisters)
            {
                unregister.Unregister();
            }
            
            mUnregisters.Clear();
        }
    }

    public static class UnregisterExtension
    {
        public static void UnregisterWhenGameObjectDestroy(this IUnregister unregister, GameObject gameObject)
        {
            var trigger = gameObject.GetComponent<UnregisterOnDestroyTrigger>();

            if (!trigger)
            {
                trigger = gameObject.AddComponent<UnregisterOnDestroyTrigger>();
            }

            trigger.AddUnregister(unregister);
        }
    }
    
    public class TypeEventSystem : ITypeEventSystem
    {
        public interface IRegistraions
        {
            
        }

        public class Registraions<T> : IRegistraions
        {
            public Action<T> OnEvent = e => { };
        }

        private Dictionary<Type, IRegistraions> mEventRegistraion = new Dictionary<Type, IRegistraions>();
        

        public void Send<T>() where T : new()
        {
            var e = new T();
            Send<T>(e);
        }

        public void Send<T>(T e)
        {
            var type = typeof(T);
            IRegistraions registraions;

            if (mEventRegistraion.TryGetValue(type, out registraions))
            {
                (registraions as Registraions<T>)?.OnEvent.Invoke(e);
            }
        }

        public IUnregister Register<T>(Action<T> onEvent)
        {
            var type = typeof(T);
            IRegistraions registraions;

            if (mEventRegistraion.TryGetValue(type, out registraions))
            {
                
            }
            else
            {
                registraions = new Registraions<T>();
                mEventRegistraion.Add(type, registraions);
            }
            (registraions as Registraions<T>).OnEvent += onEvent;

            return new TypeEventSystemUnregister<T>()
            {
                OnEvent = onEvent, TypeEventSystem = this
            };
        }

        public void Unregister<T>(Action<T> onEvent)
        {
            var type = typeof(T);
            IRegistraions registraions;

            if (mEventRegistraion.TryGetValue(type, out registraions))
            {
                (registraions as Registraions<T>).OnEvent -= onEvent;
            }
        }
    }
}