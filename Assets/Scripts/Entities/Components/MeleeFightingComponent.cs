using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using InventoryModule;

public class MeleeFightingComponent : IAttackingComponent
{
    private Animator animator;

    public bool Attack(GameObject target, GameObject attacker, HealthComponent healthComponent)
    {
        if (animator == null) animator = attacker.GetComponent<Animator>();

        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Attack")) return false;  //wait for the end of the animation

        animator.SetBool("IsAttacking", true);
        try
        {
            target.GetComponent<IHittable>().RecieveDamage(healthComponent.Damage);
        }
        catch { Debug.Log("Attacking invalid target"); }

        return true;
    }

    public void AttackUsingConsumables(GameObject target, GameObject attacker, HealthComponent healthComponent, Inventory inventoryWithConsumables)
    {
        foreach (var item in inventoryWithConsumables.Items)
        {
            if (item.IsConsumable)
            {
                if (Attack(target, attacker, healthComponent)) inventoryWithConsumables.RemoveItem(item);
                return;
            }
        }
    }
}
