using FrameworkDesign.Framework.Architecture;
using FrameworkDesign.Framework.BindableProperty;
using UnityEngine;
using UnityEngine.UI;

namespace CountApp.Scripts
{
    public class CounterViewController : MonoBehaviour, IController
    {
        private ICountModel mCountModel;
        
        private void Start()
        {
            mCountModel = GetArchitecture().GetModel<ICountModel>();
            
            // 添加委托
            mCountModel.Count.OnValueChanged += OnCountChanged;
            
            // 表现逻辑 -- 初始化
            mCountModel.Count.OnValueChanged?.Invoke(mCountModel.Count.Value);
            
            transform.Find("AddButton").GetComponent<Button>().onClick.AddListener((() =>
            {
                // 交互逻辑
                GetArchitecture().SendCommand<AddCountCommand>();
            }));
            
            transform.Find("SubButton").GetComponent<Button>().onClick.AddListener((() =>
            {
                // 交互逻辑
                GetArchitecture().SendCommand<SubCountCommand>();
            }));
        }

        // 表现逻辑 -- 更新计数器显示
        private void OnCountChanged(int obj)
        {
            transform.Find("CountText").GetComponent<Text>().text = obj.ToString();
        }

        private void OnDestroy()
        {
            mCountModel.Count.OnValueChanged -= OnCountChanged;

            mCountModel = null;
        }

        public IArchitecture GetArchitecture()
        {
            return CountApp.Interface;
        }
    }
}
