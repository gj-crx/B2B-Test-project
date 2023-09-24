using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

using Zenject;

namespace AI
{
    /// <summary>
    /// Chases and attacks player when it comes in sight
    /// </summary>
    public class PlayerChaserBehavior : IBehavior
    {
        private PlayerObject playerObjectToChase;

        private GameObject acquiredTarget = null;
        const int delayBetweenExecutions = 100;

        [Inject]
        public PlayerChaserBehavior(PlayerObject playerObject)
        {
            this.playerObjectToChase = playerObject;
        }

        /// <summary>
        /// Acquires a new target to chase it and attack
        /// </summary>
        public async void ControlObject(GameObject objectToControl, HealthComponent healthComponent, IAttackingComponent attackingComponent)
        {
            while (objectToControl != null && objectToControl.activeSelf)
            {
                acquiredTarget = null;
                if (playerObjectToChase == null) return;

                float distanceToTarget = Vector3.Distance(objectToControl.transform.position, playerObjectToChase.transform.position);
                
                if (distanceToTarget < healthComponent.AttackRangeMelee)
                {  //close enough to attack
                    attackingComponent.Attack(playerObjectToChase.gameObject, objectToControl, healthComponent);
                } 
                else if (distanceToTarget < healthComponent.DistanceOfSight)
                { //not close enough to attack but still in sight for a chase
                    acquiredTarget = playerObjectToChase.gameObject;
                }
                await Task.Delay(delayBetweenExecutions);
            }
        }
        public void MovementControl(GameObject objectToControl)
        {
            if (acquiredTarget != null)
            {
                objectToControl.GetComponent<IMovable>().Move((acquiredTarget.transform.position - objectToControl.transform.position).normalized);
            }
            else
            {
                objectToControl.GetComponent<IMovable>().Move(Vector3.zero);
            }
        }
    }
}
