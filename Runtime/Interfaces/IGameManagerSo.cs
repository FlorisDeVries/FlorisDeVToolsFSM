using UnityEngine;
using UnityEngine.Events;

namespace FlorisDeVToolsFSM.Interfaces
{
    public interface IGameManagerSo<TGameState>
    {
        bool IsGamePaused { get; }
        Transform PlayerTransform { get; }
        IGameStateMachine<TGameState> GameStateMachine { get; }


        void RegisterOnGameStateChanged(UnityAction action);
        void DeRegisterOnGameStateChanged(UnityAction action);

        void SetGameStateMachine(IGameStateMachine<TGameState> gameStateMachine);
    }
}