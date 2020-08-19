using UnityEngine;

namespace Null
{
    public class SomeMonoBehaviour : MonoBehaviour
    {
        private IEnemySpawner enemySpawner;
        
        private void Start()
        {
            enemySpawner = ServiceProvider.GetService<IEnemySpawner>();

            if (enemySpawner == null)
            {
                Debug.LogWarning("There is no EnemySpawner!");
                enemySpawner = new NullEnemySpawner();
            }
        }
    }
}