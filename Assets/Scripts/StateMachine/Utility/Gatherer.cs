using UnityEngine;

namespace StateMachine.Utility
{
    public class Gatherer : MonoBehaviour
    {
        #region Private Fields

        private GameObject _target;
        private int storedItemCount = 10;

        public Gatherer(GameObject target)
        {
            _target = target;
        }

        #endregion

        #region Constants

        private const int StoredItemCountThreshold = 10;

        #endregion

        #region Public Properties

        public bool HasTarget => _target != null;
        public bool CanGather => storedItemCount < StoredItemCountThreshold;

        #endregion
    }
}