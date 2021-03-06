using FrameworkDesign.Example.Scripts.Event;
using FrameworkDesign.Example.Scripts.Model;
using FrameworkDesign.Framework.Command;
using FrameworkDesign.Framework.Architecture.Rule;

namespace FrameworkDesign.Example.Scripts.Command
{
    public class KillEnemyCommand : AbstractCommand
    {
        protected override void OnExecute()
        {
            var gameModel = this.GetModel<IGameModel>();
            
            gameModel.KillCount.Value++;

            if (UnityEngine.Random.Range(0, 10) < 3)
            {
                gameModel.Gold.Value += UnityEngine.Random.Range(1, 3);
            }
            
            this.SendEvent<OnKillEnemyEvent>();

            if (gameModel.KillCount.Value == 10)
            {
                this.SendEvent<GamePassEvent>();
            }
        }
    }
}