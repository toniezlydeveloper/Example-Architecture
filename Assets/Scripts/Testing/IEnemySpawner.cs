using System;

namespace Testing
{
    public interface IEnemySpawner
    {
        event Action OnEnemySpawned;

        void SpawnEnemy();
    }
}