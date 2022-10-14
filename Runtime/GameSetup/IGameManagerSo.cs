using System;
using UnityEngine;
using UnityEngine.Events;

namespace FlorisDeVToolsFSM.GameSetup
{
    public interface IGameManagerSo
    {
        bool IsGamePaused { get; }
        Transform PlayerTransform { get; }

        void RegisterOnGameStateChanged(UnityAction gameStateChanged);
        void DeRegisterOnGameStateChanged(UnityAction gameStateChanged);
    }
}