using UnityEngine;

namespace FlorisDeVTools.FiniteStateMachine
{
    public abstract class BaseState<TOwner> : IState
    {
        protected readonly TOwner owner;

        protected BaseState(TOwner owner)
        {
            this.owner = owner;
        }

        public virtual void Enter()
        {
            
        }

        public virtual void Exit()
        {
            
        }

        public virtual void FixedUpdate()
        {
            
        }

        public virtual void Update(float deltaTime)
        {
            
        }

        public virtual void OnCollisionEnter2D(Collision2D other)
        {
            
        }
    }
}