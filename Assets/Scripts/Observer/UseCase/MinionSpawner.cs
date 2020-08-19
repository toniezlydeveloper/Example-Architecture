using System.Collections.Generic;
using Observer.Utility;

namespace Observer.UseCase
{
    public class MinionSpawner : Observable
    {
        #region Private Fields

        private List<Minion> minions = new List<Minion>();

        #endregion

        #region Public Methods

        public void Spawn()
        {
            minions.Add(new Minion());
            NotifyAboutMinionCountChange();
        }

        public void Despawn(Minion minion)
        {
            minions.Remove(minion);
            NotifyAboutMinionCountChange();
        }

        #endregion

        #region Private Methods

        private void NotifyAboutMinionCountChange()
        {
            Notify(minions.Count, NotificationType.MinionCountChanged);
        }

        #endregion
    }
}