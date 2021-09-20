 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FrameworkDesign.Example
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
