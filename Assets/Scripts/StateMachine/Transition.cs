using System;

namespace StateMachine
{
    public class Transition
    {
        #region Public Properties

        public IState To { get; }
        public Func<bool> Condition { get; }

        #endregion

        #region Constructors

        public Transition(IState to, Func<bool> condition)
        {
            To = to;
            Condition = condition;
        }

        #endregion
    }
}