using FrameworkDesign.Example.Scripts.Model;
using FrameworkDesign.Framework.Architecture.Rule;
using FrameworkDesign.Framework.Command;

namespace FrameworkDesign.Example.Scripts.Command
{
    public class BuyLifeCommand : AbstractCommand
    {
        protected override void OnExecute()
        {
            var gameModel = this.GetModel<IGameModel>();

            gameModel.Gold.Value--;
            gameModel.Life.Value++;
        }
    }
}