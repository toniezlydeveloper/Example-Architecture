namespace StateMachine.UseCase.States
{
    public class MoveToResourcesState : IState
    {
        #region Public Properties

        public bool HasReachedResources { get; } = false;

        #endregion

        #region Public Methods

        public void Tick()
        {
        }

        public void OnEnter()
        {
        }

        public void OnExit()
        {
        }

        #endregion
    }
}