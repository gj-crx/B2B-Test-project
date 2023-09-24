using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Zenject;
using UI.Buttons;
using InventoryModule;

namespace UI
{
    public class ItemVisualization : MonoBehaviour
    {
        public Item RepresentedItem;

        [Inject]
        private void Install(Inventory inventory, ButtonConfirmItemRemoval itemRemovalButton)
        {
            GetComponent<ButtonSelectItem>().Inventory = inventory;
            GetComponent<ButtonSelectItem>().ItemRemovalButton = itemRemovalButton;
        }
    }
}
