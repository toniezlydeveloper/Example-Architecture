namespace Command
{
    public interface ICommand
    {
        #region Public Methods

        void Execute();
        void Undo();

        #endregion
    }
}