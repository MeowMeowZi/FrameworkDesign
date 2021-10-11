using FrameworkDesign.Framework.Architecture.Rule;
using FrameworkDesign.Framework.Command;

namespace CountApp.Scripts
{
    public class SubCountCommand : AbstractCommand
    {
        protected override void OnExecute()
        {
            this.GetModel<ICountModel>().Count.Value--;
        }
    }
}