using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using InventoryModule;

[System.Serializable]
public class ShootingComponent : IAttackingComponent
{
    private Animator animator;

    public bool Attack(GameObject target, GameObject attacker, HealthComponent healthComponent)
    { //attack -> shoot

        if (animator == null) animator = attacker.GetComponent<Animator>();
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Attack")) return false; //wait for the end of the attack animation to attack again
 
        animator.SetBool("IsAttacking", true);

        Bullet newBullet = GameObject.Instantiate(PrefabManager.BulletPrefabs[0]).GetComponent<Bullet>();
        newBullet.Damage = healthComponent.Damage;

        Vector3 shootingDelta = attacker.transform.position - target.transform.position;
        newBullet.transform.localEulerAngles = new Vector3(0, 0, Mathf.Atan2(shootingDelta.y, shootingDelta.x) * Mathf.Rad2Deg + 90); //bullet will be guided by facing angle
        newBullet.transform.position = attacker.transform.position + newBullet.transform.up; //initial offset

        if (shootingDelta.x < 0) attacker.transform.Find("Avatar").localEulerAngles = new Vector3(0, 0, 0);
        if (shootingDelta.x > 0) attacker.transform.Find("Avatar").localEulerAngles = new Vector3(0, 180, 0);

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
        Debug.Log("No more bullets to shoot");
    }
}
