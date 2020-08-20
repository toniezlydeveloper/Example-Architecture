using System;
using UnityEngine;

namespace Testing
{
    public class EnemySpawner : IEnemySpawner
    {
        public event Action OnEnemySpawned;

        public void SpawnEnemy()
        {
            new GameObject().AddComponent<Enemy>();
            OnEnemySpawned?.Invoke();
        }
    }
}