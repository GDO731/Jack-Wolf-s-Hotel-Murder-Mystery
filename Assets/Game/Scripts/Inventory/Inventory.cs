using Assets.Game.Scripts.Items;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Game.Scripts.Inventory
{
    public class Inventory : MonoBehaviour
    {
        #region Singleton
        public static Inventory instance;

        private void Awake()
        {
            if(instance != null)
            {
                Debug.LogWarning("More than 1 instance found!");
                return;
            }
            instance = this;
        }
        #endregion

        public delegate void OnItemChanged();

        public OnItemChanged onItemChangedCallback;

        [SerializeField] int slots = 8;

        public List<Item> items = new List<Item>();

        public bool Add(Item item)
        {
            if (items.Count < slots)
            {
                items.Add(item);
                if (onItemChangedCallback != null)
                {
                    onItemChangedCallback.Invoke();
                }
                return true;
            }
            return false;
        }

        public void Remove(Item item)
        {
            items.Remove(item);

            if (onItemChangedCallback != null)
            {
                onItemChangedCallback.Invoke();
            }
        }
    }
}
