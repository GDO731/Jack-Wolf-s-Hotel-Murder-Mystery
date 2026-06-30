using Assets.Game.Scripts.Core;
using Assets.Game.Scripts.Interaction;
using UnityEngine;

namespace Assets.Game.Scripts.Dialogue
{
    public class AIConversant : Interactable
    {
        [SerializeField] Dialogue dialogue = null;
        [SerializeField] string conversantName;
        [SerializeField] PlayerConversant playerConversant = null;

        public void Start()
        {
            if (playerConversant == null) 
            { 
                playerConversant = GameObject.FindWithTag(TagConstants.PlayerTag)
                    .GetComponent<PlayerConversant>();
            }
        }

        public override bool Interact()
        {
            base.Interact();

            if (dialogue == null) return false;

            playerConversant.StartDialogue(this, dialogue);

            return true;
        }


        public string GetName()
        {
            return conversantName;
        }
    }
}
