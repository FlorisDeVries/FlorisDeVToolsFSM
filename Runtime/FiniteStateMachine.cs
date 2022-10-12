using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace FlorisDeVToolsFSM
{
    public class FiniteStateMachine<TStates, TOwner, TStateType> where TStateType : BaseState<TOwner>
    {
        private readonly Dictionary<TStates, TStateType> _states;
        public TStateType CurrentState { get; private set; }
        public TStates ActiveState { get; private set; }
        public UnityAction OnStateChanged = delegate { };

        public FiniteStateMachine(Dictionary<TStates, TStateType> states)
        {
            _states = states;
        }

        public void ChangeState(TStates nextState)
        {
            if (ActiveState.Equals(nextState))
            {
                return;
            }

            if (!_states.ContainsKey(nextState))
            {
                throw new ArgumentOutOfRangeException(nameof(nextState),
                    "State was not found in the states dictionary");
            }

            CurrentState?.Exit();
            ActiveState = nextState;
            CurrentState = _states[nextState];
            CurrentState?.Enter();
            OnStateChanged.Invoke();
        }

        public void FixedUpdate()
        {
            CurrentState?.FixedUpdate();
        }
        
        public void Update(float deltaTime)
        {
            CurrentState?.Update(deltaTime);
        }

        public void Cleanup()
        {
            CurrentState?.Exit();
        }

        public void OnCollisionEnter2D(Collision2D other)
        {
            CurrentState?.OnCollisionEnter2D(other);
        }
    }
}