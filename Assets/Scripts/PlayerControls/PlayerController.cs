using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Zenject;

namespace PlayerControls
{
    /// <summary>
    /// Implements character control for the player
    /// </summary>
    public class PlayerController : MonoBehaviour
    {
        private IMovable moving;
        private IAbleToAttack attacking;
        private IMovementControlsInput controlsInput;

        [Inject]
        private void InstallExternalDependencies(IMovementControlsInput movementControlsInput)
        {
            controlsInput = movementControlsInput;
        }

        private void Start()
        {
            if (gameObject.GetComponent<IMovable>() != null) moving = GetComponent<IMovable>();
            if (gameObject.GetComponent<IAbleToAttack>() != null) attacking = GetComponent<IAbleToAttack>();
        }
        void Update()
        {
            moving.Move(controlsInput.MovementDirection);
        }
        public void AttackInput()
        {
            attacking.Attack(null);
        }
    }
}
