using FrameworkDesign.Framework.Architecture;
using FrameworkDesign.Framework.Architecture.Rule;
using UnityEngine;

namespace CountApp.Scripts
{
    public interface IAchievementSystem : ISystem
    {
        
    }
    
    public class AchievementSystem : AbstractSystem, IAchievementSystem
    {
        protected override void OnInit()
        {
            var countMoudel = this.GetModel<ICountModel>();;

            var previousCount = countMoudel.Count.Value;

            countMoudel.Count.RegisterOnValueChanged(newCount =>
            {
                if (previousCount < 10 && newCount >= 10)
                {
                    Debug.Log("解锁点击 10 次成就!");
                }
                else if (previousCount < 20 && newCount >= 20)
                {
                    Debug.Log("解锁点击 20 次成就！");
                }

                previousCount = newCount;
            });
        }
    }
}