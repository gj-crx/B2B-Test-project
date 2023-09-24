using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using Zenject;
using InventoryModule;

namespace UI.Buttons
{
    public class ButtonConfirmItemRemoval : MonoBehaviour
    {
        private Inventory inventory;

        private void Awake() => GetComponent<Button>().onClick.AddListener(RemoveItem);

        [Inject]
        private void Install(Inventory inventory)
        {
            this.inventory = inventory;
        }

        private void RemoveItem()
        {
            inventory.RemoveItem(inventory.SelectedItem);
            gameObject.SetActive(false);
        }
    }
}
