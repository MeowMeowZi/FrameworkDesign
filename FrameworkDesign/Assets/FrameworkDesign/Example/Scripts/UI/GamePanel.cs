using FrameworkDesign.Example.Scripts.Model;
using FrameworkDesign.Example.Scripts.System;
using FrameworkDesign.Framework.Architecture;
using FrameworkDesign.Framework.Architecture.Rule;
using UnityEngine;
using UnityEngine.UI;

namespace FrameworkDesign.Example.Scripts.UI
{
    public class GamePanel : MonoBehaviour, IController
    {
        private ICountDownSystem mCountDownSystem;
        private IGameModel mGameModel;
        
        private void Awake()
        {
            mCountDownSystem = this.GetSystem<ICountDownSystem>();

            mGameModel = this.GetModel<IGameModel>();

            mGameModel.Gold.RegisterOnValueChanged(OnGoldValueChanged);
            mGameModel.Life.RegisterOnValueChanged(OnLifeValueChanged);
            mGameModel.Score.RegisterOnValueChanged(OnScoreValueChanged);

            OnGoldValueChanged(mGameModel.Gold.Value);
            OnLifeValueChanged(mGameModel.Life.Value);
            OnScoreValueChanged(mGameModel.Score.Value);
        }

        private void OnLifeValueChanged(int life)
        {
            transform.Find("LifeText").GetComponent<Text>().text = $"生命: {mGameModel.Life.Value}";
        }

        private void OnGoldValueChanged(int gold)
        {
            transform.Find("GoldText").GetComponent<Text>().text = $"金币: {mGameModel.Gold.Value}";
        }

        private void OnScoreValueChanged(int score)
        {
            transform.Find("ScoreText").GetComponent<Text>().text = $"分数: {mGameModel.Score.Value}";
        }

        private void Update()
        {
            if (Time.frameCount % 20 == 0)
            {
                transform.Find("CountDownText").GetComponent<Text>().text =
                    $"{mCountDownSystem.CurrentRemainSeconds} S";
            }
        }

        private void OnDestroy()
        {
            mGameModel.Gold.UnregisterOnValueChanged(OnGoldValueChanged);
            mGameModel.Life.UnregisterOnValueChanged(OnLifeValueChanged);
            mGameModel.Score.UnregisterOnValueChanged(OnScoreValueChanged);
            mGameModel = null;
            mCountDownSystem = null;
        }

        public IArchitecture GetArchitecture()
        {
            return PointGame.PointGame.Interface;
        }
    }
}
