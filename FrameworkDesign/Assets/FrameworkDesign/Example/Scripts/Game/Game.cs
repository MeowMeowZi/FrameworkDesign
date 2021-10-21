using FrameworkDesign.Example.Scripts.Event;
using FrameworkDesign.Framework.Architecture;
using FrameworkDesign.Framework.Architecture.Rule;
using FrameworkDesign.Framework.Event;
using UnityEngine;

namespace FrameworkDesign.Example.Scripts.Game
{
    public class Game : MonoBehaviour, IController
    {
        private TypeEventSystem mTypeEventSystem = new TypeEventSystem();
        
        private void Start()
        {
            this.RegisterEvent<GameStartEvent>(OnGameStart);

            this.RegisterEvent<OnCountDownEndEvent>(e =>
            {
                transform.Find("Enemies").gameObject.SetActive(false);
            }).UnregisterWhenGameObjectDestroy(gameObject);

            this.RegisterEvent<GamePassEvent>(e =>
            {
                transform.Find("Enemies").gameObject.SetActive(false);
            }).UnregisterWhenGameObjectDestroy(gameObject);
        }

        private void OnGameStart(GameStartEvent e)
        {
            var enemyRoot = transform.Find("Enemies");

            enemyRoot.gameObject.SetActive(true);

            foreach (Transform childTrans in enemyRoot)
            {
                childTrans.gameObject.SetActive(true);
            }
        }

        private void OnDestroy()
        {
            this.Unregister<GameStartEvent>(OnGameStart);
        }

        public IArchitecture GetArchitecture()
        {
            return PointGame.PointGame.Interface;
        }
    }
}