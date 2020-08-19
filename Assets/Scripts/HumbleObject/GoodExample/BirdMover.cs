using UnityEngine;

namespace HumbleObject.GoodExample
{
    public class BirdMover
    {
        #region Private Fields

        private IBird bird;

        #endregion

        #region Constructors

        public BirdMover(IBird bird)
        {
            this.bird = bird;
        }

        #endregion

        #region Public Methods

        public void Move(float verticalInput)
        {
            Vector3 newPosition = bird.Position + Vector3.up * verticalInput;

            if (bird.MaxHeight < newPosition.y)
            {
                newPosition.y = bird.MaxHeight;
            }

            if (bird.MinHeight > newPosition.y)
            {
                newPosition.y = bird.MinHeight;
            }

            bird.Position = newPosition;
        }

        #endregion
    }
}