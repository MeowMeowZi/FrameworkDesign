using FrameworkDesign.Example.Scripts.Event;
using FrameworkDesign.Framework.Command;

namespace FrameworkDesign.Example.Scripts.Command
{
    public struct GameStartCommand : ICommand
    {
        public void Execute()
        {
            GameStartEvent.Trigger();
        }
    }
}