using System.Collections.Generic;
using UnityEngine;

namespace Observer
{
    public class Observable : MonoBehaviour
    {
        #region Private Fields

        private List<Observer> observers = new List<Observer>();

        #endregion

        #region Public Methods

        public void Register(Observer observer)
        {
            observers.Add(observer);
        }

        public void Unregister(Observer observer)
        {
            observers.Remove(observer);
        }

        #endregion

        #region Protected Methods

        protected void Notify(object value, NotificationType notificationType)
        {
            foreach (Observer observer in observers)
            {
                observer.OnNotify(value, notificationType);
            }
        }

        #endregion
    }
}