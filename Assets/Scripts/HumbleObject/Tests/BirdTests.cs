using HumbleObject.GoodExample;
using NUnit.Framework;
using UnityEngine;

namespace HumbleObject.Tests
{
    public class BirdTests
    {
        #region Constants

        private const float MaxBirdHeight = 3f;
        private const float MinBirdHeight = -3f;
        private const float HugeVerticalInput = 100f;

        #endregion

        #region Public Methods

        [Test]
        public void BirdStopsAtMinHeight()
        {
            IBird bird = new MockBird { MinHeight = MinBirdHeight, MaxHeight = MaxBirdHeight };
            BirdMover mover = new BirdMover(bird);

            mover.Move(-HugeVerticalInput);

            Assert.AreEqual(bird.MinHeight, bird.Position.y);
        }

        [Test]
        public void BirdStopsAtMaxHeight()
        {
            IBird bird = new MockBird { MinHeight = MinBirdHeight, MaxHeight = MaxBirdHeight };
            BirdMover mover = new BirdMover(bird);

            mover.Move(HugeVerticalInput);

            Assert.AreEqual(bird.MaxHeight, bird.Position.y);
        }

        #endregion

        private class MockBird : IBird
        {
            #region Public Properties

            public Vector3 Position { get; set; } = Vector3.zero;
            public float MaxHeight { get; set; }
            public float MinHeight { get; set; }

            #endregion
        }
    }
}