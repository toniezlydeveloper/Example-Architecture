using System;

namespace NullObject
{
    public interface IEnemySpawner
    {
        event Action OnEnemySpawned;
    }
}