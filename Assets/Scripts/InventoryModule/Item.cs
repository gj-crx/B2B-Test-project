using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InventoryModule
{
    [CreateAssetMenu(fileName = "Item", menuName = "ScriptableObjects/Item", order = 1)]
    public class Item : ScriptableObject
    {
        public int ItemID { get { return itemID; } }
        public string Name;
        public Sprite Icon;
        public bool IsConsumable = true;

        private int itemID = 0;

        private void OnEnable()
        {
#if UNITY_EDITOR
            if (ItemsManager.ItemTypes.Contains(this) == false) ItemsManager.ItemTypes.Add(this);
            itemID = ItemsManager.ItemTypes.IndexOf(this);
#endif
        }
    }
}
