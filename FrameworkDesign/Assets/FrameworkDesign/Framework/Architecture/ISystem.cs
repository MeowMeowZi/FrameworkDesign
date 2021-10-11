using FrameworkDesign.Framework.Architecture.Rule;

namespace FrameworkDesign.Framework.Architecture
{
    public interface ISystem : IBelongToArchitecture, ICanSetArchitecture, ICanGetModel, ICanGetUtility, ICanRegisterEvent, ICanSendEvent
    {
        void Init();
    }
    
    public abstract class AsbtractSystem : ISystem
    {
        private IArchitecture mArchitecture;
        
        IArchitecture IBelongToArchitecture.GetArchitecture()
        {
            return mArchitecture;
        }

        void ICanSetArchitecture.SetArchitecture(IArchitecture architecture)
        {
            mArchitecture = architecture;
        }

        void ISystem.Init()
        {
            OnInit();
        }

        protected abstract void OnInit();
    }
}