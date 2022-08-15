using FlorisDeVToolsUnityExtensions.HelperFunctions;
using UnityEngine;

namespace FlorisDeVTools.FiniteStateMachine
{
    public abstract class FsmMonobehaviour<TState, TOwner> : BetterMonoBehaviour
    {
        public FiniteStateMachine<TState, TOwner> StateMachine { get; protected set; }
        
        protected virtual void OnEnable()
        {
            InitializeStateMachine();
        }

        protected override void OnDisable()
        {
            base.OnDisable();
            StateMachine.Cleanup();
        }

        protected abstract void InitializeStateMachine();
        
        protected virtual void FixedUpdate()
        {
            if (IsPaused)
                return;

            StateMachine?.FixedUpdate();
        }
        
        protected virtual void Update()
        {
            if (IsPaused)
                return;

            StateMachine?.Update(Time.deltaTime);
        }
        
        protected virtual  void OnCollisionEnter2D(Collision2D other)
        {
            StateMachine?.OnCollisionEnter2D(other);
        }
    }
}