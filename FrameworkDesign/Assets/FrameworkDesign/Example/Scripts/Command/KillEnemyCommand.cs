using FrameworkDesign.Example.Scripts.Event;
using FrameworkDesign.Example.Scripts.Model;
using FrameworkDesign.Framework.Command;
using FrameworkDesign.Example.Scripts.PointGame;

namespace FrameworkDesign.Example.Scripts.Command
{
    public struct KillEnemyCommand : ICommand
    {
        public void Execute()
        {
            var gameModel = PointGame.PointGame.Get<IGameModel>();
            
            gameModel.KillCount.Value++;

            if (gameModel.KillCount.Value == 10)
            {
                GamePassEvent.Trigger();
            }
        }
    }
}