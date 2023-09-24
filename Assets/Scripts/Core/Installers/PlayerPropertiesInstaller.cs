using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Zenject;
using PlayerControls;
using InventoryModule;

public class PlayerPropertiesInstaller : MonoInstaller
{
    [SerializeField] private PlayerObject playerObject;
    [SerializeField] private PrefabManager prefabManagerInstance;
    public override void InstallBindings()
    {
        Container.Bind<PlayerObject>().FromInstance(playerObject).AsSingle();
        Container.Bind<PlayerController>().FromInstance(playerObject.GetComponent<PlayerController>()).AsSingle();

        Container.Bind<Inventory>().FromNew().AsSingle();
    }
}
