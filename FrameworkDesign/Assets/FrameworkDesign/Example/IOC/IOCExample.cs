using System;
using System.ComponentModel;
using FrameworkDesign.Framework.IOC;
using UnityEngine;

namespace FrameworkDesign.Example.IOC
{
    public class IOCExample : MonoBehaviour
    {
        private void Start()
        {
            var container = new IOCContainer();

            container.Register<IBlueToothManager>(new BlueToothManager());

            var blueToothManager = container.Get<IBlueToothManager>();
            
            blueToothManager.Connect();
        }
    }

    public interface IBlueToothManager
    {
        void Connect();
    }
    
    public class BlueToothManager : IBlueToothManager
    {
        public void Connect()
        {
            Debug.Log("蓝牙链接成功");
        }
    }
}
