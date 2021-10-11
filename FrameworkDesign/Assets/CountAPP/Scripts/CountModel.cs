using FrameworkDesign.Framework.Architecture;
using FrameworkDesign.Framework.Architecture.Rule;
using FrameworkDesign.Framework.BindableProperty;
using UnityEngine;

namespace CountApp.Scripts
{
    public interface ICountModel : IModel
    {
        BindableProperty<int> Count { get; }
    }
    
    public class CountModel : AbstractModel, ICountModel
    {
        protected override void OnInit()
        {
            var storage = this.GetUtility<IStorage>();

            Count.Value = storage.LoadInt("COUNTER_COUNT", 0);

            Count.OnValueChanged += count =>
            {
                storage.SaveInt("COUNTER_COUNT", count);
            };
        }

        public BindableProperty<int> Count { get; } = new BindableProperty<int>()
        {
            Value = 0
        };
    }
    
    
}