using FrameworkDesign.Example.Scripts.Event;
using FrameworkDesign.Example.Scripts.Model;
using FrameworkDesign.Framework.Command;
using FrameworkDesign.Example.Scripts.PointGame;

namespace FrameworkDesign.Example.Scripts.Command
{
    public class KillEnemyCommand : AbstractCommand
    {
        protected override void OnExecute()
        {
            var gameModel = GetArchitecture().GetModel<IGameModel>();
            
            gameModel.KillCount.Value++;

            if (gameModel.KillCount.Value == 10)
            {
                GamePassEvent.Trigger();
            }
        }
    }
}