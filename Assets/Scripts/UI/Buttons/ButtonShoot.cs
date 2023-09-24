using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using PlayerControls;
using Zenject;

namespace UI.Buttons
{
    public class ButtonShoot : MonoBehaviour
    {
        private PlayerController playerController;

        private void Awake() => GetComponent<Button>().onClick.AddListener(ButtonClicked);
        [Inject]
        private void Install(PlayerController playerController)
        {
            this.playerController = playerController;
        }


        private void ButtonClicked()
        {
            playerController.AttackInput();
        }
    }
}
