using FrameworkDesign.Framework.Architecture;
using FrameworkDesign.Framework.Architecture.Rule;
using UnityEngine;
using UnityEngine.UI;

namespace CountApp.Scripts
{
    public class CounterViewController : MonoBehaviour, IController
    {
        private ICountModel mCountModel;
        
        private void Start()
        {
            mCountModel = this.GetModel<ICountModel>();
            
            // 添加委托
            mCountModel.Count.RegisterOnValueChanged(OnCountChanged);
            
            // 表现逻辑 -- 初始化
            OnCountChanged(mCountModel.Count.Value);
            
            transform.Find("AddButton").GetComponent<Button>().onClick.AddListener((() =>
            {
                // 交互逻辑
                this.SendCommand<AddCountCommand>();
            }));
            
            transform.Find("SubButton").GetComponent<Button>().onClick.AddListener((() =>
            {
                // 交互逻辑
                this.SendCommand<SubCountCommand>();
            }));
        }

        // 表现逻辑 -- 更新计数器显示
        private void OnCountChanged(int obj)
        {
            transform.Find("CountText").GetComponent<Text>().text = obj.ToString();
        }

        private void OnDestroy()
        {
            mCountModel.Count.UnregisterOnValueChanged(OnCountChanged);

            mCountModel = null;
        }

        IArchitecture IBelongToArchitecture.GetArchitecture()
        {
            return CountApp.Interface;
        }
    }
}
