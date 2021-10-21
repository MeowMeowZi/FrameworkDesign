using FrameworkDesign.Example.Scripts.Model;
using FrameworkDesign.Example.Scripts.System;
using FrameworkDesign.Example.Scripts.Utility;
using FrameworkDesign.Framework.Architecture;

namespace FrameworkDesign.Example.Scripts.PointGame
{
    public class PointGame : Architecture<PointGame>
    {
        protected override void Init()
        {
            RegisterSystem<ICountDownSystem>(new CountDownSystem());

            RegisterSystem<IAchievementSystem>(new AchievementSystem());
            
            RegisterSystem<IScoreSystem>(new ScoreSystem());
            
            RegisterModel<IGameModel>(new GameModel());

            RegisterUtility<IStorage>(new PlayerPrefsStorage());
        }
    }
}