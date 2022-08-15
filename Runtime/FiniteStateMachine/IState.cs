namespace FlorisDeVTools.FiniteStateMachine
{
    public interface IState
    {
        public void Enter();
        public void Exit();
        public void FixedUpdate();
        public void Update(float deltaTime);
    }
}
