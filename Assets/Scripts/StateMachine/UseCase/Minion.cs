using StateMachine.UseCase.States;
using StateMachine.Utility;
using UnityEngine;

namespace StateMachine.UseCase
{
    public class Minion : MonoBehaviour
    {
        #region Serialized Fields

        [SerializeField]
        private Gatherer gatherer;

        #endregion

        #region Private Fields

        private StateMachine stateMachine;

        #endregion

        #region Unity Callbacks

        private void Start()
        {
            stateMachine = new StateMachine();
            ConstructStatesAndTransitions();
        }

        private void Update()
        {
            stateMachine.Tick();
        }

        #endregion

        #region Private Methods

        private void ConstructStatesAndTransitions()
        {
            IdleState idle = new IdleState();
            FleeState flee = new FleeState();
            StoreResourcesState storeResources = new StoreResourcesState();
            GatherResourcesState gatherResources = new GatherResourcesState();
            MoveToResourcesState moveToResources = new MoveToResourcesState();

            stateMachine.AddTransition(gatherResources, storeResources, () => !gatherer.CanGather);
            stateMachine.AddTransition(storeResources, idle, () => gatherer.CanGather);
            stateMachine.AddTransition(idle, gatherResources, () => gatherer.HasTarget);
            stateMachine.AddTransition(moveToResources, gatherResources, () => moveToResources.HasReachedResources);
            stateMachine.AddTransitionFromAnyState(flee, () => ServiceProvider.GetService<EnemyDetector>().IsEnemyInRange(transform));
        }

        #endregion
    }
}