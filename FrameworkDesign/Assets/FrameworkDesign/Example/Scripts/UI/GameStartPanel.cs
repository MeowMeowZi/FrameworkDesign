using FrameworkDesign.Example.Scripts.Command;
using FrameworkDesign.Example.Scripts.Event;
using FrameworkDesign.Framework.Architecture;
using UnityEngine;
using UnityEngine.UI;

namespace FrameworkDesign.Example.Scripts.UI
{
    public class GameStartPanel : MonoBehaviour, IController
    {
        void Start()
        {
            transform.Find("BtnStart").GetComponent<Button>().onClick.AddListener((() =>
            {
                gameObject.SetActive(false);
                GetArchitecture().SendCommand<GameStartCommand>();
            }));
        }

        public IArchitecture GetArchitecture()
        {
            return PointGame.PointGame.Interface;
        }
    }
}