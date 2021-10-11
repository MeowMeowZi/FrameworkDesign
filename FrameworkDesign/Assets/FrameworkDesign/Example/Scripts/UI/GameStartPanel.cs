using FrameworkDesign.Example.Scripts.Command;
using FrameworkDesign.Framework.Architecture;
using FrameworkDesign.Framework.Architecture.Rule;
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
                this.SendCommand<GameStartCommand>();
            }));
        }

        IArchitecture IBelongToArchitecture.GetArchitecture()
        {
            return PointGame.PointGame.Interface;
        }
    }
}