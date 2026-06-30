using Assets.Game.Scripts.Interaction;

namespace Assets.Game.Scripts.Items
{
    public class ItemPickup : Interactable
    {
        public Item item;

        public override bool Interact()
        {
            base.Interact();
            bool wasPickedUp = Inventory.Inventory.instance.Add(item);
            if (wasPickedUp)
            {
                Destroy(gameObject);
            }
            return true;
        }
    }
}
