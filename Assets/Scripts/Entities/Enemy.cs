using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

using Zenject;
using AI;
using InventoryModule;
using UI;

public class Enemy : MonoBehaviour, IMovable, IHittable, IAbleToAttack
{
    public float CurrentHP { get { return healthComponent.CurrentHP; } set { healthComponent.CurrentHP = value; } }

    //Local components
    [SerializeField] private HealthComponent healthComponent = new HealthComponent();
    [SerializeField] private HealthBar healthBar;
    [SerializeField] private DropOnDeathComponent dropOnDeath = new DropOnDeathComponent();

    private IAttackingComponent attackingComponent = new MeleeFightingComponent();
    private MovementComponent movementComponent = new MovementComponent();
    private IBehavior behavior;

    [Inject]
    private void InstallExternalDependecies(IBehavior behavior, DataBase dataBase)
    {
        this.behavior = behavior;
        dataBase.EnemyObjectsPool.Add(this);
    }

    private void Start()
    {
        if (behavior != null) behavior.ControlObject(gameObject, healthComponent, attackingComponent);
    }
    private void Update() => behavior.MovementControl(gameObject);


    public void Move(Vector3 direction)
    {
        movementComponent.MovementIteration(direction, transform, healthComponent.MovementSpeed);
    }

    public void RecieveDamage(float damage)
    {
        healthComponent.CurrentHP -= damage;
        if (CurrentHP <= 0) Death();
        if (healthBar != null) healthBar.ValueChanged(CurrentHP, healthComponent.MaxHP);
    }

    public void Attack(GameObject target)
    {
        attackingComponent.Attack(target, gameObject, healthComponent);
    }
    
    private void Death()
    {
        if (dropOnDeath.itemDroppedOnDeath != null)
            Instantiate(PrefabManager.CollectibleItemPrefab, transform.position, Quaternion.identity).GetComponent<CollectableObject>().storedItem = dropOnDeath.itemDroppedOnDeath;
        Destroy(gameObject);
    }
}
