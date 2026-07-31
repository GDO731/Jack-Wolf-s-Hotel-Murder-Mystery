using Assets.Game.Scripts.Core;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Game.Scripts.UI
{
    public class InventoryUI : MonoBehaviour
    {
        [SerializeField] Transform itemsParent;
        [SerializeField] GameObject inventoryUI;
        [SerializeField] InputReader inputReader;
        [SerializeField] Button quitButton;

        [Header("Audio")]
        [SerializeField] AudioClip openClip;
        [SerializeField] AudioClip closeClip;

        Inventory.Inventory inventory;
        InventorySlot[] slots;
        
        void Start()
        {
            inventory = Inventory.Inventory.instance;
            inventory.onItemChangedCallback += UpdateUI;

            quitButton.onClick.AddListener(() => ToggleInventory());

            slots = itemsParent.GetComponentsInChildren<InventorySlot>();
        }

        void OnEnable() => inputReader.InventoryEvent += ToggleInventory;
        void OnDisable() => inputReader.InventoryEvent -= ToggleInventory;

        void ToggleInventory()
        {
            inventoryUI.SetActive(!inventoryUI.activeSelf);

            if (inventoryUI.activeSelf)
                SoundManager.instance.PlayClip(openClip);
            else
                SoundManager.instance.PlayClip(closeClip);
        }

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

