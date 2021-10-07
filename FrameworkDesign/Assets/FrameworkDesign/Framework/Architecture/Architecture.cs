using FrameworkDesign.Framework.IOC;

namespace FrameworkDesign.Framework.Architecture
{
    public abstract class Architecture<T> where T : Architecture<T>, new()
    {
        private static T mArchitecture;

        static void MakeSureArchitecture()
        {
            if (mArchitecture == null)
            {
                mArchitecture = new T();
                mArchitecture.Init();
            }
        }

        protected abstract void Init();

        private IOCContainer mContainer = new IOCContainer();
        
        public static T Get<T>() where T : class
        {
            MakeSureArchitecture();
            
            return mArchitecture.mContainer.Get<T>();
        }

        public void Register<T>(T instance)
        {
            MakeSureArchitecture();
            
            mArchitecture.mContainer.Register<T>(instance);
        }
    }
}