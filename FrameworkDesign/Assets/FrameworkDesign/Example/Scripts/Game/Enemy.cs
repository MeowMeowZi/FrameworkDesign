using FrameworkDesign.Example.Scripts.Command;
using FrameworkDesign.Example.Scripts.Event;
using FrameworkDesign.Example.Scripts.Model;
using FrameworkDesign.Framework.Architecture;
using UnityEngine;

namespace FrameworkDesign.Example.Scripts.Game
{
    public class Enemy : MonoBehaviour, IController
    {
        private void OnMouseDown()
        {
            Destroy(gameObject);
            
            GetArchitecture().SendCommand<KillEnemyCommand>();
        }

        public IArchitecture GetArchitecture()
        {
            return PointGame.PointGame.Interface;
        }
    }
}
