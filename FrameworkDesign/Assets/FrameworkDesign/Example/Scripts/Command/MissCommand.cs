using FrameworkDesign.Example.Scripts.Event;
using FrameworkDesign.Example.Scripts.Model;
using FrameworkDesign.Framework.Architecture.Rule;
using FrameworkDesign.Framework.Command;

namespace FrameworkDesign.Example.Scripts.Command
{
    public class MissCommand : AbstractCommand
    {
        protected override void OnExecute()
        {
            var gameModel = this.GetModel<IGameModel>();

            if (gameModel.Life.Value > 0)
            {
                gameModel.Life.Value--;
            }
            else
            {
                this.SendEvent<OnMissEvent>();   
            }
        }
    }
}