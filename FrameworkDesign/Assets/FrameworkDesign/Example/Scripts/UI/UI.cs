using System;
using FrameworkDesign.Example.Scripts.Event;
using FrameworkDesign.Framework.Architecture;
using FrameworkDesign.Framework.Architecture.Rule;
using UnityEngine;

namespace FrameworkDesign.Example.Scripts.UI
{
    public class UI : MonoBehaviour, IController
    {
        private void Awake()
        {
            this.RegisterEvent<GamePassEvent>(OnGamePass);
        }

        private void OnGamePass(GamePassEvent e)
        {
            transform.Find("Canvas/GamePassPanel").gameObject.SetActive(true);
        }

        private void OnDestroy()
        {
            this.Unregister<GamePassEvent>(OnGamePass);
        }

        public IArchitecture GetArchitecture()
        {
            return PointGame.PointGame.Interface;
        }
    }
}