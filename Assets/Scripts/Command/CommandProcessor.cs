using System.Collections.Generic;

namespace Command
{
    public class CommandProcessor
    {
        #region Private Fields

        private int currentCommandIndex;
        private List<ICommand> commands = new List<ICommand>();

        #endregion

        #region Public Methods

        public void ExecuteCommand(ICommand command)
        {
            commands.Add(command);
            command?.Execute();

            currentCommandIndex = commands.Count - 1;
        }

        public void Undo()
        {
            if (currentCommandIndex < 0)
            {
                return;
            }

            commands[currentCommandIndex].Undo();
            commands.RemoveAt(currentCommandIndex);
            currentCommandIndex--;
        }

        public void Redo()
        {
            if (currentCommandIndex >= commands.Count - 1)
            {
                return;
            }

            commands[currentCommandIndex].Execute();
            currentCommandIndex++;
        }

        #endregion
    }
}