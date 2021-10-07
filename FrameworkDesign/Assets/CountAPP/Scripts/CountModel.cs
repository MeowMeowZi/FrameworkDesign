using FrameworkDesign.Framework.Architecture;
using FrameworkDesign.Framework.BindableProperty;
using UnityEngine;

namespace CountApp.Scripts
{
    public interface ICountModel : IBelongToArchitecture
    {
        BindableProperty<int> Count { get; }
    }
    
    public class CountModel : ICountModel
    {
        public CountModel()
        {
            var storage = Architecture.GetUtility<IStorage>();

            storage.LoadInt("COUNTER_COUNT", 0);

            Count.OnValueChanged += count =>
            {
                storage.SaveInt("COUNTER_COUNT", count);
            };
        }
        
        public BindableProperty<int> Count { get; } = new BindableProperty<int>()
        {
            Value = 0
        };

        public IArchitecture Architecture { get; set; }
    }
    
    
}