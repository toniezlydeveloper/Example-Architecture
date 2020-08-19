using UnityEngine;

namespace HumbleObject.GoodExample
{
    public interface IBird
    {
        #region Public Properties

        Vector3 Position { get; set; }
        float MaxHeight { get; }
        float MinHeight { get; }

        #endregion
    }
}