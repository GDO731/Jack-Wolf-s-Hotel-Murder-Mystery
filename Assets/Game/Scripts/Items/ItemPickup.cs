using Assets.Game.Scripts.Core;
using Assets.Game.Scripts.Interaction;
using UnityEngine;

namespace Assets.Game.Scripts.Items
{
    public class ItemPickup : Interactable
    {
        public Item item;

        [SerializeField] float delayBeforeDestroy = 1f;
        [SerializeField] AudioClip audioClip;
        [SerializeField] AudioSource audioSource;

        public override bool Interact()
        {
            base.Interact();
            bool wasPickedUp = Inventory.Inventory.instance.Add(item);
            if (wasPickedUp)
            {
                SoundManager.instance.PlayClip(audioSource,audioClip);
                Destroy(gameObject, delayBeforeDestroy);
            }
            return true;
        }
    }
}
