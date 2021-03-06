using FrameworkDesign.Example.Scripts.Command;
using FrameworkDesign.Framework.Architecture;
using FrameworkDesign.Framework.Architecture.Rule;
using UnityEngine;

namespace FrameworkDesign.Example.Scripts.Game
{
    public class Enemy : MonoBehaviour, IController
    {
        private void OnMouseDown()
        {
            gameObject.SetActive(false);
            
            this.SendCommand<KillEnemyCommand>();
        }

        IArchitecture IBelongToArchitecture.GetArchitecture()
        {
            return PointGame.PointGame.Interface;
        }
    }
}
