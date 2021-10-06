using System;
using FrameworkDesign.Example.Scripts.Event;
using UnityEngine;

namespace FrameworkDesign.Example.Scripts.UI
{
    public class UI : MonoBehaviour
    {
        private void Awake()
        {
            GamePassEvent.Register(OnGamePass);
        }

        private void OnGamePass()
        {
            transform.Find("Canvas/GamePassPanel").gameObject.SetActive(true);
        }

        private void OnDestroy()
        {
            GamePassEvent.UnRegister(OnGamePass);
        }
    }
}