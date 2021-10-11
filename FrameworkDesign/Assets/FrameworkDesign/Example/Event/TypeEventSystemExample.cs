using System;
using FrameworkDesign.Framework.Event;
using UnityEngine;

namespace FrameworkDesign.Example.Event
{
    public class TypeEventSystemExample : MonoBehaviour
    {
        public struct EventA
        {
            
        }

        public struct EventB
        {
            public int ParamB;
        }

        public interface IEventGroup
        {
            
        }

        public struct EventC : IEventGroup
        {
            
        }
        
        public struct EventD : IEventGroup
        {
            
        }

        private TypeEventSystem mTypeEventSystem = new TypeEventSystem();
        private void Start()
        {
            mTypeEventSystem.Register<EventA>(OnEventA);
            mTypeEventSystem.Register<EventB>(b =>
            {
                Debug.Log($"OnEventB: {b.ParamB}");
            }).UnregisterWhenGameObjectDestroy(gameObject);
            mTypeEventSystem.Register<IEventGroup>(group =>
            {
                Debug.Log(group.GetType());
            }).UnregisterWhenGameObjectDestroy(gameObject);
        }

        private void OnEventA(EventA obj)
        {
            Debug.Log("OnEventA");
        }

        private void OnDestroy()
        {
            mTypeEventSystem.Unregister<EventA>(OnEventA);

            mTypeEventSystem = null;
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                mTypeEventSystem.Send<EventA>();
            }

            if (Input.GetMouseButtonDown(1))
            {
                mTypeEventSystem.Send(new EventB()
                {
                    ParamB = 123
                });
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                mTypeEventSystem.Send<IEventGroup>(new EventC());
                mTypeEventSystem.Send<IEventGroup>(new EventD());
            }
        }
    }
}
