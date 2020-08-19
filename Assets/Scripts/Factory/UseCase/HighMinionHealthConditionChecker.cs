using Factory.Utility;
using UnityEngine;

namespace Factory.UseCase
{
    public class HighMinionHealthConditionChecker : IConditionChecker
    {
        #region Public Properties

        public ConditionType Type => ConditionType.MinionHasEnoughHealth;

        #endregion

        #region Public Methods

        public bool IsFulfilled(object value, ConditionData data)
        {
            if (value is Minion minion)
            {
                return minion.HealthAmount >= data.HealthAmount;
            }

            Debug.LogWarning("Value sent to condition is not minion!");
            return false;
        }

        #endregion
    }
}