using System;
using System.Collections.Generic;

namespace StateMachine
{
    public class StateMachine
    {
        #region Private Fields

        private IState currentState;
        private List<Transition> emptyTransitions = new List<Transition>();
        private List<Transition> transitionsFromAnyState = new List<Transition>();
        private List<Transition> transitionsFromCurrentState = new List<Transition>();
        private Dictionary<Type, List<Transition>> transitionsFromStates = new Dictionary<Type, List<Transition>>();

        #endregion

        #region Public Methods

        public void Tick()
        {
            if (TryGetTransition(out Transition transition))
            {
                SetState(transition.To);
            }

            currentState?.Tick();
        }

        public void AddTransition(IState from, IState to, Func<bool> condition)
        {
            if (transitionsFromStates.TryGetValue(from.GetType(), out List<Transition> transitions))
            {
                transitions.Add(new Transition(to, condition));
            }
            else
            {
                transitionsFromStates[from.GetType()] = new List<Transition> { new Transition(to, condition) };
            }
        }

        public void AddTransitionFromAnyState(IState to, Func<bool> condition)
        {
            transitionsFromAnyState.Add(new Transition(to, condition));
        }

        #endregion

        #region Private Methods

        private bool TryGetTransition(out Transition transition)
        {
            foreach (Transition t in transitionsFromAnyState)
            {
                if (!t.Condition())
                {
                    continue;
                }

                transition = t;
                return true;
            }

            foreach (Transition t in transitionsFromCurrentState)
            {
                if (!t.Condition())
                {
                    continue;
                }

                transition = t;
                return true;
            }

            transition = null;
            return false;
        }

        private void SetState(IState state)
        {
            currentState?.OnExit();
            state.OnEnter();

            if (!transitionsFromStates.TryGetValue(state.GetType(), out transitionsFromCurrentState))
            {
                transitionsFromCurrentState = emptyTransitions;
            }

            currentState = state;
        }

        #endregion
    }
}