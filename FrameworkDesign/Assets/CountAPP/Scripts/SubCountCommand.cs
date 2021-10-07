using FrameworkDesign.Framework.Command;

namespace CountApp.Scripts
{
    public struct SubCountCommand : ICommand
    {
        public void Execute()
        {
            CountApp.Get<ICountModel>().Count.Value--;
        }
    }
}