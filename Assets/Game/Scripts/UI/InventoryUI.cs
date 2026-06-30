using Assets.Game.Scripts.Core;
using UnityEngine;

namespace Assets.Game.Scripts.UI
{
    public class InventoryUI : MonoBehaviour
    {
        [SerializeField] Transform itemsParent;
        [SerializeField] GameObject inventoryUI;
        [SerializeField] InputReader inputReader;

        Inventory.Inventory inventory;
        InventorySlot[] slots;

        void Start()
        {
            inventory = Inventory.Inventory.instance;
            inventory.onItemChangedCallback += UpdateUI;

            slots = itemsParent.GetComponentsInChildren<InventorySlot>();
        }

        void OnEnable() => inputReader.InventoryEvent += ToggleInventory;
        void OnDisable() => inputReader.InventoryEvent -= ToggleInventory;

        void ToggleInventory()
        => inventoryUI.SetActive(!inventoryUI.activeSelf);

        void UpdateUI()
        {
            for (int i = 0; i < slots.Length; i++) 
            {
                if(i < inventory.items.Count)
                {
                    slots[i].AddItem(inventory.items[i]);
                }
                else
                {
                    slots[i].ClearSlot();
                }
            }
        }
    }
}

