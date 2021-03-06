using System;
using FrameworkDesign.Example.Scripts.Command;
using FrameworkDesign.Example.Scripts.Model;
using FrameworkDesign.Framework.Architecture;
using FrameworkDesign.Framework.Architecture.Rule;
using UnityEngine;
using UnityEngine.UI;

namespace FrameworkDesign.Example.Scripts.UI
{
    public class GameStartPanel : MonoBehaviour, IController
    {
        private IGameModel mGameModel;
        
        void Start()
        {
            transform.Find("BtnStart").GetComponent<Button>().onClick.AddListener((() =>
            {
                gameObject.SetActive(false);
                this.SendCommand<GameStartCommand>();
            }));
            
            transform.Find("BtnBuyLife").GetComponent<Button>().onClick.AddListener((() =>
            {
                this.SendCommand<BuyLifeCommand>();
            }));

            mGameModel = this.GetModel<IGameModel>();

            mGameModel.Life.RegisterOnValueChanged(OnLifeValueChanged);
            mGameModel.Gold.RegisterOnValueChanged(OnGoldValueChanged);

            OnLifeValueChanged(mGameModel.Life.Value);
            OnGoldValueChanged(mGameModel.Gold.Value);

            transform.Find("BestScoreText").GetComponent<Text>().text = $"最高分: {mGameModel.Score.Value}";
        }

        private void OnLifeValueChanged(int life)
        {
            transform.Find("LifeText").GetComponent<Text>().text = $"生命: {mGameModel.Life.Value}";
        }

        private void OnGoldValueChanged(int gold)
        {
            transform.Find("BtnBuyLife").gameObject.SetActive(gold > 0);

            transform.Find("GoldText").GetComponent<Text>().text = $"金币: {mGameModel.Gold.Value}";
        }

        private void OnDestroy()
        {
            mGameModel.Gold.UnregisterOnValueChanged(OnGoldValueChanged);
            mGameModel.Life.UnregisterOnValueChanged(OnLifeValueChanged);
            mGameModel = null;
        }

        IArchitecture IBelongToArchitecture.GetArchitecture()
        {
            return PointGame.PointGame.Interface;
        }
    }
}