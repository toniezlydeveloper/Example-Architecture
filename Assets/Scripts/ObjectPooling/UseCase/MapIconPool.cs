using System.Collections.Generic;
using System.Linq;
using ObjectPooling.Utility;
using UnityEngine;

namespace ObjectPooling.UseCase
{
    public class MapIconPool : MonoBehaviour, IObjectPool<MapIcon>
    {
        #region Serialized Fields

        [SerializeField]
        private GameObject mapIconPrefab;

        #endregion

        #region Private Fields

        private List<MapIcon> pool = new List<MapIcon>();

        #endregion

        #region Constants

        private const int InitialPoolCount = 10;

        #endregion

        #region Unity Methods

        public void Start()
        {
            for (int i = 0; i < InitialPoolCount; i++)
            {
                AddMapIconToPool();
            }
        }

        #endregion

        #region Public Methods

        public MapIcon Get()
        {
            if (pool.Count == 0)
            {
                AddMapIconToPool();
            }

            MapIcon icon = pool.First();
            icon.gameObject.SetActive(true);
            pool.Remove(icon);
            return icon;
        }

        public void Return(MapIcon objectToReturn)
        {
            objectToReturn.gameObject.SetActive(false);
            pool.Add(objectToReturn);
        }

        #endregion

        #region Private Methods

        private void AddMapIconToPool()
        {
            GameObject newIconGameObject = Instantiate(mapIconPrefab);
            newIconGameObject.SetActive(false);
            pool.Add(newIconGameObject.GetComponent<MapIcon>());
        }

        #endregion
    }
}