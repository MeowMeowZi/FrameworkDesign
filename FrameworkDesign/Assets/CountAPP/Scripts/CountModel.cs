using FrameworkDesign.Framework.BindableProperty;

namespace CountApp.Scripts
{
    public class CountModel
    {
        public BindableProperty<int> Count = new BindableProperty<int>()
        {
            Value = 0
        };
    }
}