using FrameworkDesign.Framework.Architecture;
using FrameworkDesign.Framework.IOC;

namespace CountApp.Scripts
{
    public class CountApp : Architecture<CountApp>
    {
        protected override void Init()
        {
            Register(new CountModel());
        }
    }
}