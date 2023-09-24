using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using Zenject;
using InventoryModule;

namespace UI
{
    public class InventoryVisualisation : MonoBehaviour
    {
        private Inventory inventoryToVisualize;
        private ItemVisualizationFactory itemVisualizationFactory;
        [SerializeField] private Transform itemsListContent;

        private List<ItemVisualization> visualizedItemObject = new List<ItemVisualization>();

        [Inject]
        private void Install(Inventory inventoryToVisualize, ItemVisualizationFactory itemVisualizationFactory)
        {
            this.inventoryToVisualize = inventoryToVisualize;
            this.itemVisualizationFactory = itemVisualizationFactory;

            inventoryToVisualize.OnItemAdded += AddItemVisualization;
            inventoryToVisualize.OnItemRemoved += DeleteItemVisualization;
        }


        private void AddItemVisualization(Item itemToAdd)
        {
            int itemAmount = inventoryToVisualize.GetItemAmount(itemToAdd);
            if (itemAmount > 1)
            { //using existing instance to increase its count
                GetItemVisualization(itemToAdd).transform.Find("Amount").GetComponent<Text>().text = itemAmount.ToString();
            }
            else
            { //Creating a new instance
                var newItemVisualization = itemVisualizationFactory.Create();
                newItemVisualization.gameObject.name = itemToAdd.Name;
                newItemVisualization.transform.SetParent(itemsListContent);
                newItemVisualization.RepresentedItem = itemToAdd;
                newItemVisualization.GetComponent<Image>().sprite = itemToAdd.Icon;

                visualizedItemObject.Add(newItemVisualization);
            }
        }
        private void DeleteItemVisualization(Item itemToDelete)
        {
            int itemAmount = inventoryToVisualize.GetItemAmount(itemToDelete);
            var itemVisualization = GetItemVisualization(itemToDelete);

            if (itemAmount <= 0)
            { //Last item of this type has been deleted
                visualizedItemObject.Remove(itemVisualization);
                Destroy(itemVisualization.gameObject);
            }
            else
            {
                string labelText = itemAmount == 1 ? "" : itemAmount.ToString(); //amount label hidden if item is a single copy
                itemVisualization.transform.Find("Amount").GetComponent<Text>().text = labelText;
            }
        }
        private ItemVisualization GetItemVisualization(Item itemToFind)
        {
            foreach (var itemVisualization in visualizedItemObject)
            {
                if (itemVisualization.name == itemToFind.Name) return itemVisualization;
            }
            return null;
        }
    }
}
