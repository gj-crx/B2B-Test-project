using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UI;
using InventoryModule;
using Zenject;

/// <summary>
/// Connects implementation logic with object capabilities
/// </summary>
public class PlayerObject : MonoBehaviour, IMovable, IHittable, IAbleToAttack, IAbleToCollectItems
{
    public float CurrentHP { get { return healthComponent.CurrentHP; } set { healthComponent.CurrentHP = value; } }

    public Inventory PlayerInventory;

    //Local components
    [SerializeField] private HealthComponent healthComponent = new HealthComponent();
    [SerializeField] private HealthBar healthBar;

    private MovementComponent movementComponent = new MovementComponent();
    private IAttackingComponent attackingComponent = new ShootingComponent();
    private TargetAcquirerComponent targetAcquirerComponent;

    [Inject]
    private void InstallExternalDependencies(Inventory inventory, DataBase dataBase)
    {
        this.PlayerInventory = inventory;
        targetAcquirerComponent = new TargetAcquirerComponent(dataBase);
        dataBase.PlayerObject = this;
    }
    public void Move(Vector3 direction)
    {
        movementComponent.MovementIteration(direction, transform, healthComponent.MovementSpeed);
    }

    public void RecieveDamage(float damage)
    {
        if (healthComponent.RecieveDamage(damage)) Death();
        else if (healthBar != null) healthBar.ValueChanged(CurrentHP, healthComponent.MaxHP);
    }

    public void Attack(GameObject target)
    {
        if (target == null) target = targetAcquirerComponent.GetNearestEnemyFromPosition(transform.position, healthComponent.DistanceOfSight);
        if (target != null) attackingComponent.AttackUsingConsumables(target, gameObject, healthComponent, PlayerInventory);
        else Debug.Log("No viable targets in range");
    }
    public void Collect(Item aquiredItem)
    {
        PlayerInventory.AddItem(aquiredItem);
    }

    private void Death()
    {
        Debug.Log("Player is dead");
        CurrentHP = healthComponent.MaxHP;
    }
}
