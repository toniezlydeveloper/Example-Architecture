using System;

namespace NullObject
{
    public class NullEnemySpawner : IEnemySpawner
    {
        public event Action OnEnemySpawned;
    }
}