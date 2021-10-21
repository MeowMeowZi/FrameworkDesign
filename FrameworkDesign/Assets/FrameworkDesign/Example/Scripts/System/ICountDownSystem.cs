using System;
using FrameworkDesign.Example.Scripts.Event;
using FrameworkDesign.Framework.Architecture;
using FrameworkDesign.Framework.Architecture.Rule;
using UnityEngine;

namespace FrameworkDesign.Example.Scripts.System
{
    public interface ICountDownSystem : ISystem
    {
        int CurrentRemainSeconds { get; }

        void Update();
    }
    
    public class CountDownSystem : AbstractSystem, ICountDownSystem
    {
        protected override void OnInit()
        {
            this.RegisterEvent<GameStartEvent>(e =>
            {
                mStarted = true;
                mGameStartTime = DateTime.Now;
            });

            this.RegisterEvent<GamePassEvent>(e =>
            {
                mStarted = false;
            });
        }

        private DateTime mGameStartTime { get; set; }

        private bool mStarted = false;

        public int CurrentRemainSeconds => 10 - (int) (DateTime.Now - mGameStartTime).TotalSeconds;
        
        public void Update()
        {
            Debug.Log("GameStartTest");
            if (mStarted)
            {
                Debug.Log("GameTest");
                if (DateTime.Now - mGameStartTime > TimeSpan.FromSeconds(10))
                {
                    Debug.Log("GameOverTest");
                    this.SendEvent<OnCountDownEndEvent>();
                    mStarted = false;
                }
            }
        }
    }
}