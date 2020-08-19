using UnityEngine;

namespace Observer.UseCase
{
    public class GameOverController : Observer
    {
        #region Unity Callbacks

        private void Start()
        {
            ServiceProvider.GetService<MinionSpawner>().Register(this);
        }

        private void OnDestroy()
        {
            ServiceProvider.GetService<MinionSpawner>().Unregister(this);
        }

        #endregion

        #region Public Methods

        public override void OnNotify(object value, NotificationType notificationType)
        {
            if (notificationType != NotificationType.MinionCountChanged)
            {
                return;
            }

            if (value is int minionCount && minionCount < 1)
            {
                DoGameOver();
            }
        }

        #endregion

        #region Private Methods

        private void DoGameOver()
        {
            Debug.Log("It's over Anakin.");
        }

        #endregion
    }
}