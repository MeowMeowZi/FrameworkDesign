using FrameworkDesign.Framework.Command;

namespace CountApp.Scripts
{
    public struct AddCountCommand : ICommand
    {
        public void Execute()
        {
            CountApp.Get<CountModel>().Count.Value++;
        }
    }
}
