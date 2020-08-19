using UnityEngine;

namespace Observer
{
    public abstract class Observer : MonoBehaviour
    {
        #region Public Methods

        public abstract void OnNotify(object value, NotificationType notificationType);

        #endregion
    }
}