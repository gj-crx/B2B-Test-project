using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Zenject;

public class GameScenarioRunner
{
    private EnemyFactory enemyFactory;
    private DataBase dataBase;

    [Inject]
    private GameScenarioRunner(EnemyFactory enemyFactory, DataBase dataBase)
    {
        this.enemyFactory = enemyFactory;
        this.dataBase = dataBase;
    }

    public void RunScenario(LevelScenario scenarioToRun)
    {
        for (int enemiesToSpawnCounter = dataBase.EnemyObjectsPool.Count; enemiesToSpawnCounter < scenarioToRun.countEnemiesToSpawn; enemiesToSpawnCounter++)
        {
            var newEnemy = enemyFactory.Create();
            newEnemy.transform.position = new Vector3(Random.Range(-scenarioToRun.MapRadius, scenarioToRun.MapRadius), Random.Range(-scenarioToRun.MapRadius, scenarioToRun.MapRadius), 0);
        }
    }
}
