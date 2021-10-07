using FrameworkDesign.Framework.Architecture;

namespace CountApp.Scripts
{
    public class CountApp : Architecture<CountApp>
    {
        protected override void Init()
        {
            RegisterModel<ICountModel>(new CountModel());
            Register<IStorage>(new PlayerPresStorage());
        }
    }
}