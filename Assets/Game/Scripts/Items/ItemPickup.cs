using Assets.Game.Scripts.Core;
using Assets.Game.Scripts.Interaction;
using UnityEngine;

namespace Assets.Game.Scripts.Items
{
    public class ItemPickup : Interactable
    {
        public Item item;

        [SerializeField] float delayBeforeDestroy = 1f;

        [Header("Audio")]
        [SerializeField] AudioClip audioClip;

        public override bool Interact()
        {
            base.Interact();
            bool wasPickedUp = Inventory.Inventory.instance.Add(item);
            if (wasPickedUp)
            {
                SoundManager.instance.PlayClip(audioClip);
                Destroy(gameObject, delayBeforeDestroy);
            }
            return true;
        }
    }
}
