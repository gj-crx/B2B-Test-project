using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Zenject;
using SaveLoadSystem;

public class CoreComponentsInstaller : MonoInstaller
{
    [SerializeField] private PrefabManager prefabManagerInstance;
    [SerializeField] private DataBase dataBase;
    public override void InstallBindings()
    {
        Container.Bind<PrefabManager>().FromInstance(prefabManagerInstance);
        Container.Bind<DataBase>().FromInstance(dataBase);
        Container.Bind<GameScenarioRunner>().FromNew().AsSingle();
        Container.Bind<GameSaveLoader>().FromNew().AsSingle();
        Container.BindFactory<Enemy, EnemyFactory>().FromComponentInNewPrefab(PrefabManager.GetEnemyPrefab(prefabManagerInstance));
    }
}
