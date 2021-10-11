using FrameworkDesign.Example.Scripts.Event;
using FrameworkDesign.Framework.Architecture.Rule;
using FrameworkDesign.Framework.Command;

namespace FrameworkDesign.Example.Scripts.Command
{
    public class GameStartCommand : AbstractCommand
    {
        protected override void OnExecute()
        {
            this.SendEvent<GameStartEvent>();
        }
    }
}