using FrameworkDesign.Framework.Command;

namespace CountApp.Scripts
{
    public class AddCountCommand : AbstractCommand
    {
        protected override void OnExecute()
        {
            GetArchitecture().GetModel<ICountModel>().Count.Value++; 
        }
    }
}
