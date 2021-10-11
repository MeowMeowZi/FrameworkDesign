using FrameworkDesign.Framework.Command;

namespace CountApp.Scripts
{
    public class SubCountCommand : AbstractCommand
    {
        protected override void OnExecute()
        {
            GetArchitecture().GetModel<ICountModel>().Count.Value--;
        }
    }
}