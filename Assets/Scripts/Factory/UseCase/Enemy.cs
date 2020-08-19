using Factory.Utility;
using UnityEngine;

namespace Factory.UseCase
{
    public class Enemy : MonoBehaviour
    {
        #region Private Fields

        private Minion target;

        #endregion

        #region Unity Callbacks

        private void Update()
        {
            ConditionData conditionData = new ConditionData { HealthAmount = 10 };

            if (ConditionCheckerFactory.ConditionCheckerByType(ConditionType.MinionHasEnoughHealth).IsFulfilled(target, conditionData))
            {
                ActAggressive();
            }
            else
            {
                ActPeacefully();
            }
        }

        #endregion

        #region Private Methods

        private void ActAggressive()
        {
        }

        private void ActPeacefully()
        {
        }

        #endregion
    }
}