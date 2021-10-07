using FrameworkDesign.Example.Scripts.Command;
using FrameworkDesign.Example.Scripts.Event;
using FrameworkDesign.Example.Scripts.Model;
using UnityEngine;

namespace FrameworkDesign.Example.Scripts.Game
{
    public class Enemy : MonoBehaviour
    {
        private void OnMouseDown()
        {
            Destroy(gameObject);

            new KillEnemyCommand()
                .Execute();
        }
    }
}
