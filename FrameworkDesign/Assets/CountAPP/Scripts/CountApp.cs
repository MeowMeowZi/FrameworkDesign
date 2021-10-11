using FrameworkDesign.Framework.Architecture;

namespace CountApp.Scripts
{
    public class CountApp : Architecture<CountApp>
    {
        protected override void Init()
        {
            RegisterSystem<ISystem>(new AchievementSystem());
            RegisterModel<ICountModel>(new CountModel());
            RegisterUtility<IStorage>(new PlayerPresStorage());
        }
    }
}