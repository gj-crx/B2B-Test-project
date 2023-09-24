using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using InventoryModule;

public interface IAttackingComponent 
{
    bool Attack(GameObject target, GameObject attacker, HealthComponent healthComponent);
    void AttackUsingConsumables(GameObject target, GameObject attacker, HealthComponent healthComponent, Inventory inventoryWithConsumables);
}
