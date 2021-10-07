using FrameworkDesign.Example.Scripts.Model;
using FrameworkDesign.Framework.Architecture;
using FrameworkDesign.Framework.IOC;

namespace FrameworkDesign.Example.Scripts.PointGame
{
    public class PointGame : Architecture<PointGame>
    {
        protected override void Init()
        {
            Register(new GameModel());
        }
    }
}