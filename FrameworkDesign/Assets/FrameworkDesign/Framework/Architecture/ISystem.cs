namespace FrameworkDesign.Framework.Architecture
{
    public interface ISystem : IBelongToArchitecture, ICanSetArchitecture
    {
        void Init();
    }
    
    public abstract class AsbtractSystem : ISystem
    {
        private IArchitecture mArchitecture;
        
        public IArchitecture GetArchitecture()
        {
            return mArchitecture;
        }

        public void SetArchitecture(IArchitecture architecture)
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