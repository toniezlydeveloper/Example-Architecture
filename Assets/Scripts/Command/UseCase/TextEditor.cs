using Command.Utility;
using UnityEditor;
using UnityEngine;

namespace Command.UseCase
{
    public class TextEditor : EditorWindow
    {
        #region Private Fields

        private CommandProcessor commandProcessor;

        #endregion

        #region Unity Callbacks

        private void OnGUI()
        {
            commandProcessor = commandProcessor ?? new CommandProcessor();

            if (GUILayout.Button("Add Text On End"))
            {
                commandProcessor.ExecuteCommand(new AddTextOnEnd("Text to add."));
            }

            if (GUILayout.Button("Undo"))
            {
                commandProcessor.Undo();
            }

            if (GUILayout.Button("Redo"))
            {
                commandProcessor.Redo();
            }
        }

        #endregion
    }
}