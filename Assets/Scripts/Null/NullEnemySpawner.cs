using System;

namespace Null
{
    public class NullEnemySpawner : IEnemySpawner
    {
        public event Action OnEnemySpawned;
    }
}