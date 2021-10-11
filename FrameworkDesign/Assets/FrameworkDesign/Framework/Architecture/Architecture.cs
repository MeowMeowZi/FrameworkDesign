using System;
using System.Collections.Generic;
using FrameworkDesign.Framework.IOC;
using FrameworkDesign.Framework.Command;

namespace FrameworkDesign.Framework.Architecture
{
    public interface IArchitecture
    {
        void RegisterModel<T>(T model) where T : IModel;
        
        void RegisterSystem<T>(T system) where T : ISystem;

        void RegisterUtility<T>(T utility) where T : IUtility;

        T GetModel<T>() where T : class, IModel;
        
        T GetUtility<T>() where T : class, IUtility;

        void SendCommand<T>() where T : ICommand, new();

        void SendCommand<T>(T command) where T : ICommand;
    }
    
    public abstract class Architecture<T> : IArchitecture where T : Architecture<T>, new()
    {
        /// <summary>
        /// 是否初始化完成.
        /// </summary>
        private bool mInited = false;

        private List<IModel> mModels = new List<IModel>();

        private List<ISystem> mSystems = new List<ISystem>();

        public static Action<T> OnRegisterPatch = architecture => { };

        private static T mArchitecture;

        public static IArchitecture Interface
        {
            get
            {
                if (mArchitecture == null)
                {
                    MakeSureArchitecture();
                }

                return mArchitecture;
            }
        }

        static void MakeSureArchitecture()
        {
            if (mArchitecture == null)
            {
                mArchitecture = new T();
                mArchitecture.Init();

                OnRegisterPatch?.Invoke(mArchitecture);
                
                foreach (var architectureModel in mArchitecture.mModels)
                {
                    architectureModel.Init();
                }
                mArchitecture.mModels.Clear();
                
                foreach (var architectureSystem in mArchitecture.mSystems)
                {
                    architectureSystem.Init();
                }
                mArchitecture.mSystems.Clear();
                
                mArchitecture.mInited = true;
            }
        }

        protected abstract void Init();

        private IOCContainer mContainer = new IOCContainer();
        
        public static T Get<T>() where T : class
        {
            MakeSureArchitecture();
            
            return mArchitecture.mContainer.Get<T>();
        }

        public static void Register<T>(T instance)
        {
            MakeSureArchitecture();
            
            mArchitecture.mContainer.Register<T>(instance);
        }

        public void RegisterSystem<T>(T system) where T : ISystem
        {
            system.SetArchitecture(this);
            mContainer.Register<T>(system);

            if (!mInited)
            {
                mSystems.Add(system);
            }
            else
            {
                system.Init();
            }
        }

        public void RegisterModel<T>(T model) where T : IModel
        {
            model.SetArchitecture(this);
            mContainer.Register<T>(model);

            if (!mInited)
            {
                mModels.Add(model);
            }
            else
            {
                model.Init();
            }
        }

        public void RegisterUtility<T>(T utility) where T : IUtility
        {
            mContainer.Register<T>(utility);
        }

        public T GetModel<T>() where T : class, IModel
        {
            return mContainer.Get<T>();
        }

        public T GetUtility<T>() where T : class, IUtility
        {
            return mContainer.Get<T>();
        }

        public void SendCommand<T>() where T : ICommand, new()
        {
            var command = new T();
            command.SetArchitecture(this);
            command.Execute();
        }

        public void SendCommand<T>(T command) where T : ICommand
        {
            command.SetArchitecture(this);
            command.Execute();
        }
    }
}