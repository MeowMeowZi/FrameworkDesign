using FrameworkDesign.Example.Scripts.Model;
using FrameworkDesign.Example.Scripts.System;
using FrameworkDesign.Framework.Architecture;
using FrameworkDesign.Framework.Architecture.Rule;
using UnityEngine;
using UnityEngine.UI;

namespace FrameworkDesign.Example.Scripts.UI
{
    public class GamePassPanel : MonoBehaviour, IController
    {
        private void Start()
        {
            transform.Find("RemainSecondsText").GetComponent<Text>().text =
                $"剩余时间: {this.GetSystem<ICountDownSystem>().CurrentRemainSeconds}S";

            var gameModel = this.GetModel<IGameModel>();

            transform.Find("ScoreText").GetComponent<Text>().text = $"分数: {gameModel.Score.Value}";

            transform.Find("BestScoreText").GetComponent<Text>().text = $"最高分: {gameModel.BestScore.Value}";
        }

        public IArchitecture GetArchitecture()
        {
            return PointGame.PointGame.Interface;
        }
    }
}
