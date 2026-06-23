using System.Linq;
using UnityEngine;

namespace Assets.Game.Scripts.Dialogue
{
    public class PlayerConversant : MonoBehaviour
    {
        [SerializeField] Dialogue currentDialogue;
        DialogueNode currentNode = null;

        private void Awake()
        {
            currentNode = currentDialogue.GetRootNode();
        }

        public DialogueNode GetNode()
        {
            if(currentNode == null) return null;

            return currentNode;
        }

        public void Next()
        {
            DialogueNode[] children = currentDialogue.GetAllChildren(currentNode).ToArray();
            currentNode = children.FirstOrDefault();
        }

        public bool HasNext()
        {
            return true;
        }
    }
}
