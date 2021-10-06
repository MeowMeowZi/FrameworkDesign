using System;
using FrameworkDesign.Framework.BindableProperty;
using FrameworkDesign.Framework.Event;
using UnityEngine;
using UnityEngine.UI;

namespace CountAPP.Scripts
{
    public class CounterViewController : MonoBehaviour
    {
        private void Start()
        {
            // 添加委托
            CountModel.Count.OnValueChanged += OnCountChanged;
            
            // 表现逻辑 -- 初始化
            CountModel.Count.OnValueChanged?.Invoke(CountModel.Count.Value);
            
            transform.Find("AddButton").GetComponent<Button>().onClick.AddListener((() =>
            {
                // 交互逻辑
                CountModel.Count.Value++;
            }));
            
            transform.Find("SubButton").GetComponent<Button>().onClick.AddListener((() =>
            {
                // 交互逻辑
                CountModel.Count.Value--;
            }));
        }

        // 表现逻辑 -- 更新计数器显示
        private void OnCountChanged(int obj)
        {
            transform.Find("CountText").GetComponent<Text>().text = obj.ToString();
        }

        private void OnDestroy()
        {
            CountModel.Count.OnValueChanged -= OnCountChanged;
        }
    }
    
    public class CountModel : Event<CountModel>
    {
        public static BindableProperty<int> Count = new BindableProperty<int>()
        {
            Value = 0
        };
    }
}
