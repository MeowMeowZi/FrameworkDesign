using FrameworkDesign.Example.Scripts.Event;
using UnityEngine;

namespace FrameworkDesign.Example.Scripts.Game
{
    public class Enemy : MonoBehaviour
    {
        static int mKilledEnemtCount = 0;

        private void OnMouseDown()
        {
            Destroy(gameObject);

            mKilledEnemtCount++;

            if (mKilledEnemtCount == 10)
            {
                GamePassEvent.Trigger();
            }
        }
    }
}
