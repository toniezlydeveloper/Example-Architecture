using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Testing.Tests
{
    public class EnemySpawnerTests
    {
        [Test]
        public void EnemySpawnerRaisesEventOnEnemySpawn()
        {
            bool hasRaisedEvent = false;
            IEnemySpawner enemySpawner = new EnemySpawner();
            enemySpawner.OnEnemySpawned += () => hasRaisedEvent = true;
            
            enemySpawner.SpawnEnemy();
            
            Assert.True(hasRaisedEvent);
        }
        
        [UnityTest]
        public IEnumerator EnemySpawnerCreatesNewEnemy()
        {
            int initialEnemyCount = GameObject.FindObjectsOfType<Enemy>().Length;
            IEnemySpawner enemySpawner = new EnemySpawner();
            
            enemySpawner.SpawnEnemy();
            yield return null;
            
            int enemyCountAfterSpawn = GameObject.FindObjectsOfType<Enemy>().Length;
            
            UnityEngine.Assertions.Assert.AreEqual(initialEnemyCount + 1, enemyCountAfterSpawn);
        }
    }
}