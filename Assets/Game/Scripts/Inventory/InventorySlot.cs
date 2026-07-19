using Assets.Game.Scripts.Inventory;
using Assets.Game.Scripts.Items;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    [SerializeField] Image icon;
    [SerializeField] TextMeshProUGUI itemDescription;
    [SerializeField] TextMeshProUGUI itemName;
    Item item;

    public void AddItem(Item newItem)
    {
        item = newItem;
        icon.sprite = item.icon;
        icon.enabled = true;
    }

    public void ClearSlot()
    {
        item = null;
        icon.sprite = null;
        icon.enabled = false;
    }

    public void UseItem()
    {
        if (item != null) 
        {
            itemName.text = item.name;
            itemDescription.text = item.detription;

            item.Use();
        }
    }
}
