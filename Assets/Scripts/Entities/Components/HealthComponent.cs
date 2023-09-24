using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class HealthComponent
{
    [Header("Stats")]
    public float MaxHP = 100;
    public float Damage = 20;
    public float AttackRangeMelee = 1.4f;
    public float MovementSpeed = 3f;
    public float DistanceOfSight = 10;

    public float CurrentHP = 0;

    public HealthComponent()
    {
        CurrentHP = MaxHP;
    }
    /// <summary>
    /// Return true if unit is damage was fatal
    /// </summary>
    public bool RecieveDamage(float damage)
    {
        CurrentHP -= damage;
        if (CurrentHP <= 0) return true;
        return false;
    }
}
