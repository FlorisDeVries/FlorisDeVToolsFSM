using UnityEngine;

namespace FlorisDeVToolsFSM
{
    public abstract class MonobehaviourState<T> : BaseState<T> where T : MonoBehaviour
    {
        protected readonly Transform transform;
        protected readonly GameObject gameObject;
        
        protected MonobehaviourState(T owner) : base(owner)
        {
            transform = owner.transform;
            gameObject = owner.gameObject;
        }
    }
}