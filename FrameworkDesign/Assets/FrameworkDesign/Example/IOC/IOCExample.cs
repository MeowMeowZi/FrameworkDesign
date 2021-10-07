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

            container.Register(new BlueToothManager());

            var blueToothManager = container.Get<BlueToothManager>();
            
            blueToothManager.Connect();
        }
    }

    public class BlueToothManager
    {
        public void Connect()
        {
            Debug.Log("蓝牙链接成功");
        }
    }
}
