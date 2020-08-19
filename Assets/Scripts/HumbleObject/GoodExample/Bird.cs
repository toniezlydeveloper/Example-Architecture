using UnityEngine;

namespace HumbleObject.GoodExample
{
    public class Bird : MonoBehaviour, IBird
    {
        #region Serialized Fields

        [SerializeField]
        private float minHeight;
        [SerializeField]
        private float maxHeight;

        #endregion

        #region Private Fields

        private BirdMover mover;

        #endregion

        #region Public Properties

        public Vector3 Position { get => transform.position; set => transform.position = value; }
        public float MaxHeight => maxHeight;
        public float MinHeight => minHeight;

        #endregion

        #region Unity Callbacks

        private void Start()
        {
            mover = new BirdMover(this);
        }

        private void Update()
        {
            mover.Move(Input.GetAxis("Vertical"));
        }

        #endregion
    }
}