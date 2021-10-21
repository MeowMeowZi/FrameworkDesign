using System;
using FrameworkDesign.Example.Scripts.Command;
using FrameworkDesign.Framework.Architecture;
using FrameworkDesign.Framework.Architecture.Rule;
using UnityEngine;

namespace FrameworkDesign.Example.Scripts.Game
{
    public class MissArea : MonoBehaviour, IController
    {
        private void OnMouseDown()
        {
            this.SendCommand<MissCommand>();
        }

        public IArchitecture GetArchitecture()
        {
            return PointGame.PointGame.Interface;
        }
    }
}
