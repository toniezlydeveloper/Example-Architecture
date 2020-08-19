namespace StateMachine
{
    public interface IState
    {
        #region Public Methods

        void Tick();
        void OnEnter();
        void OnExit();

        #endregion
    }
}