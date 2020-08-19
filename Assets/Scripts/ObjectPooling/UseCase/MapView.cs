using System.Collections.Generic;
using System.Linq;
using ObjectPooling.Utility;
using UnityEngine;

namespace ObjectPooling.UseCase
{
    public class MapView : MonoBehaviour
    {
        #region Serialized Fields

        [SerializeField]
        private Dictionary<MinionType, Sprite> minionIcons;

        #endregion

        #region Private Fields

        private IObjectPool<MapIcon> mapIconPool;
        private List<MapIcon> activeIcons = new List<MapIcon>();

        #endregion

        #region Unity Callbacks

        private void Start()
        {
            mapIconPool = ServiceProvider.GetService<IObjectPool<MapIcon>>();
            ServiceProvider.GetService<IMinionSpawner>().OnMinionSpawned += ActivateIcon;
            ServiceProvider.GetService<IMinionSpawner>().OnMinionDespawned += DeactivateIcon;
        }

        private void Update()
        {
            foreach (MapIcon icon in activeIcons)
            {
                icon.TrackTarget();
            }
        }

        #endregion

        #region Private Methods

        private void ActivateIcon(Minion minion)
        {
            if (minionIcons.TryGetValue(minion.Type, out Sprite icon))
            {
                MapIcon mapIcon = mapIconPool.Get();
                mapIcon.Icon = icon;
                mapIcon.Target = minion;
            }
        }

        private void DeactivateIcon(Minion minion)
        {
            MapIcon iconToDeactivate = activeIcons.FirstOrDefault(icon => icon.Target == minion);

            if (iconToDeactivate == default)
            {
                return;
            }

            mapIconPool.Return(iconToDeactivate);
            activeIcons.Remove(iconToDeactivate);
        }

        #endregion
    }
}