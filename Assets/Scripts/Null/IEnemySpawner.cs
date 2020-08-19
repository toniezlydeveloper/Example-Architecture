using System;

namespace Null
{
    public interface IEnemySpawner
    {
        event Action OnEnemySpawned;
    }
}