﻿using System;
using FrameworkDesign.Example.Scripts.Command;
using FrameworkDesign.Example.Scripts.Event;
using FrameworkDesign.Example.Scripts.Model;
using UnityEngine;

namespace FrameworkDesign.Example.Scripts.Game
{
    public class Game : MonoBehaviour
    {
        private void Awake()
        {
            GameStartEvent.Register(OnGameStart);
        }

        private void OnGameStart()
        {
            transform.Find("Enemies").gameObject.SetActive(true);
        }

        private void OnDestroy()
        {
            GameStartEvent.UnRegister(OnGameStart);
        }
    }
}