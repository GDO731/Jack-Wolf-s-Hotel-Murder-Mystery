using Assets.Game.Scripts.Core;
using Assets.Game.Scripts.Dialogue;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Game.Scripts.UI
{
    public class DialogueUI : MonoBehaviour
    {
        [SerializeField] TextMeshProUGUI aiText;
        [SerializeField] Button nextButton;

        AudioSource audioSource;

        PlayerConversant playerConversant;

        void Start()
        {
            playerConversant = GameObject.FindGameObjectWithTag(TagConstants.PlayerTag).GetComponent<PlayerConversant>();
            nextButton.onClick.AddListener(Next);

            UpdateDialogue();
        }
        void Next()
        {
            playerConversant.Next();
            UpdateDialogue();
        }

        private void UpdateDialogue()
        {
            var dialogueNode = playerConversant.GetNode();
            aiText.text = dialogueNode.GetText();
            // dialogueNode.GetAudioSource().Play();

        }
    }
}
