using FrameworkDesign.Framework.BindableProperty;

namespace FrameworkDesign.Example.Scripts.Model
{
    public class GameModel
    {
        public BindableProperty<int> KillCount = new BindableProperty<int>()
        {
            Value = 0
        };

        public BindableProperty<int> Gold = new BindableProperty<int>()
        {
            Value = 0
        };

        public BindableProperty<int> Score = new BindableProperty<int>()
        {
            Value = 0
        };

        public BindableProperty<int> BaseScore = new BindableProperty<int>()
        {
            Value = 0
        };
    }
}
