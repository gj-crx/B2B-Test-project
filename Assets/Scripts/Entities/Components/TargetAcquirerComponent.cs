using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetAcquirerComponent
{
    private DataBase dataBase;

    public TargetAcquirerComponent(DataBase dataBase)
    {
        this.dataBase = dataBase;
    }
    public GameObject GetNearestEnemyFromPosition(Vector3 from, float distanceOfSight)
    {
        GameObject nearestTarget = null;
        float mininalDistance = distanceOfSight;

        foreach (var enemy in dataBase.EnemyObjectsPool) if (enemy != null)
        {
            float currentDistance = Vector3.Distance(from, enemy.transform.position);
            if (currentDistance < mininalDistance)
            {
                mininalDistance = currentDistance;
                nearestTarget = enemy.gameObject;
            }
        }

        return nearestTarget;
    }
}
