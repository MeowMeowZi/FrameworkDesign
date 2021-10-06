using FrameworkDesign.Example.Scripts.Event;
using UnityEngine;
using UnityEngine.UI;

namespace FrameworkDesign.Example.Scripts.UI
{
    public class GameStartPanel : MonoBehaviour
    {
        void Start()
        {
            transform.Find("BtnStart").GetComponent<Button>().onClick.AddListener((() =>
            {
                gameObject.SetActive(false);
                GameStartEvent.Trigger();
            }));
        }

    }
}