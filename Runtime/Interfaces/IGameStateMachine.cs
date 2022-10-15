using UnityEngine.Events;

namespace FlorisDeVToolsFSM.Interfaces
{
    public interface IGameStateMachine<TState>
    {
        TState ActiveState { get; }

        void RegisterOnGameStateChanged(UnityAction gameStateChanged);
        void DeRegisterOnGameStateChanged(UnityAction gameStateChanged);
        void ContinuePlaying();
        void GameOver();
        void Victory();
    }
}