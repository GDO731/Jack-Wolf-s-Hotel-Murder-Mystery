using UnityEngine;

namespace Assets.Game.Scripts.Items
{
    [CreateAssetMenu(fileName = "New Item", menuName = "Item", order = 0)]
    public class Item : ScriptableObject
    {
        new public string name = "New Item";
        public Sprite icon = null;
        public string detription = "";

        public virtual void Use()
        {
            Debug.Log("Using" +  name);
        }
    }
}
