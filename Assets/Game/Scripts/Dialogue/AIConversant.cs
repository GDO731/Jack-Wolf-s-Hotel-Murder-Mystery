using UnityEngine;

namespace Assets.Game.Scripts.Dialogue
{
    public class AIConversant : MonoBehaviour
    {
        [SerializeField] Dialogue dialogue = null;
        [SerializeField] string conversantName;

        public bool HandleRaycast(PlayerConversant playerConversant)
        {
            if (dialogue == null) return false;

            if (Input.GetMouseButtonDown(0))
            {
                playerConversant.StartDialogue(this, dialogue);
            }
            return true;
        }

        public string GetName()
        {
            return conversantName;
        }
    }
}
