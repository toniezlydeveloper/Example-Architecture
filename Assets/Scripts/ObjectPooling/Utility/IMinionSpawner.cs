using System;

namespace ObjectPooling.Utility
{
    public interface IMinionSpawner
    {
        #region Events

        event Action<Minion> OnMinionSpawned;
        event Action<Minion> OnMinionDespawned;

        #endregion
    }
}