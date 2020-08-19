using UnityEngine;
using UnityEngine.UI;

namespace ObjectPooling.Utility
{
    public class MapIcon : MonoBehaviour
    {
        #region Private Fields

        private Image image;

        #endregion

        #region Public Properties

        public Sprite Icon { set => image.sprite = value; }

        public Minion Target { get; set; }

        #endregion

        #region Public Methods

        public void TrackTarget()
        {
        }

        #endregion
    }
}