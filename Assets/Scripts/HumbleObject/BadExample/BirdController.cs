using UnityEngine;

namespace HumbleObject.BadExample
{
    public class BirdController : MonoBehaviour
    {
        #region Serialized Fields

        [SerializeField]
        private float minHeight;
        [SerializeField]
        private float maxHeight;

        #endregion

        #region Unity Callbacks

        private void Update()
        {
            float verticalInput = Input.GetAxis("Vertical");
            Vector3 newPosition = transform.position + Vector3.up * verticalInput;

            if (maxHeight < newPosition.y)
            {
                newPosition.y = maxHeight;
            }

            if (minHeight > newPosition.y)
            {
                newPosition.y = minHeight;
            }

            transform.position = newPosition;
        }

        #endregion
    }
}