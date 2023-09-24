using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Zenject;
using PlayerControls;
using UI.Buttons;

namespace UI {
    public class UIDependenciesInstaller : MonoInstaller
    {
        [SerializeField] private GameObject joystickController;
        [SerializeField] private ButtonConfirmItemRemoval itemRemovalButton;
        [SerializeField] private PrefabManager prefabManagerInstance;
        public override void InstallBindings()
        {
            Container.Bind<IMovementControlsInput>().FromInstance(joystickController.GetComponent<IMovementControlsInput>()).AsSingle();

            Container.Bind<ButtonConfirmItemRemoval>().FromInstance(itemRemovalButton).AsSingle();
            Container.BindFactory<ItemVisualization, ItemVisualizationFactory>().FromComponentInNewPrefab(PrefabManager.GetItemVisualizationPrefab(prefabManagerInstance)).AsSingle();
        }
    }
}
