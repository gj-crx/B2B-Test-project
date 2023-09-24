using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementComponent 
{
    private Animator animator;

    public void MovementIteration(Vector3 direction, Transform transformToMove, float movementSpeed)
    {
        if (animator == null) animator = transformToMove.GetComponent<Animator>();

        if (direction == Vector3.zero)
        {
            animator.SetBool("IsMoving", false);
            return;
        }
        else animator.SetBool("IsMoving", true);


        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Attacking") == false) //object can't move during attack animation
        {
            transformToMove.Translate((Vector3.up * direction.y + Vector3.right * direction.x) * movementSpeed * Time.deltaTime, Space.Self);

            if (direction.x > 0) transformToMove.Find("Avatar").localEulerAngles = new Vector3(0, 0, 0);
            if (direction.x < 0) transformToMove.Find("Avatar").localEulerAngles = new Vector3(0, 180, 0);
        }
    }
}
