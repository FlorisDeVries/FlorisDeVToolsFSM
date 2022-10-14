using System;
using UnityEngine;

namespace FlorisDeVToolsFSM.GameSetup
{
    public interface IGameManagerSo
    {
        bool IsGamePaused { get; }
        Transform PlayerTransform { get; }

        void RegisterOnGameStateChanged(Action gameStateChanged);
    }
}