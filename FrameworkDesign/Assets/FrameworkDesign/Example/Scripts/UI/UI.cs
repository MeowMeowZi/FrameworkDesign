using System;
using FrameworkDesign.Example.Scripts.Event;
using FrameworkDesign.Framework.Architecture;
using FrameworkDesign.Framework.Architecture.Rule;
using FrameworkDesign.Framework.Event;
using UnityEngine;

namespace FrameworkDesign.Example.Scripts.UI
{
    public class UI : MonoBehaviour, IController
    {
        private void Start()
        {
            this.RegisterEvent<GamePassEvent>(OnGamePass);
            this.RegisterEvent<OnCountDownEndEvent>(e =>
            {
                transform.Find("Canvas/GamePanel").gameObject.SetActive(false);
                transform.Find("Canvas/GameOverPanel").gameObject.SetActive(true);
            }).UnregisterWhenGameObjectDestroy(gameObject);
            this.RegisterEvent<GameStartEvent>(e =>
            {
                transform.Find("Canvas/GameStartPanel").gameObject.SetActive(false);
                transform.Find("Canvas/GamePanel").gameObject.SetActive(true);
            }).UnregisterWhenGameObjectDestroy(gameObject);
        }

        private void OnGamePass(GamePassEvent e)
        {
            transform.Find("Canvas/GamePanel").gameObject.SetActive(false);
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