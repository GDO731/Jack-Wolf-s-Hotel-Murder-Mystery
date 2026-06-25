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
        [SerializeField] TextMeshProUGUI conversantName;
        [SerializeField] Button nextButton;
        [SerializeField] Button quitButton;        
        [SerializeField] Transform choiceRoot;
        [SerializeField] GameObject aiResponse;
        [SerializeField] GameObject choiceButtonPrefab;

        AudioSource audioSource;

        PlayerConversant playerConversant;

        void Start()
        {
            playerConversant = GameObject.FindGameObjectWithTag(TagConstants.PlayerTag).GetComponent<PlayerConversant>();
            playerConversant.onConversationUpdated += UpdateDialogue;
            nextButton.onClick.AddListener(() => playerConversant.Next());
            quitButton.onClick.AddListener(() => playerConversant.Quit());

            UpdateDialogue();
        }

        private void UpdateDialogue()
        {
            gameObject.SetActive(playerConversant.IsActive());
            if (!playerConversant.IsActive()) return;

            conversantName.text = playerConversant.GetCurrentConversantName();
            aiResponse.SetActive(!playerConversant.IsChosing());
            choiceRoot.gameObject.SetActive(playerConversant.IsChosing());

            if (playerConversant.IsChosing())
            {
                BUildChoiceList();
            }
            else
            {
                var dialogueNode = playerConversant.GetNode();
                aiText.text = dialogueNode.GetText();
                // dialogueNode.GetAudioSource().Play();

                nextButton.gameObject.SetActive(playerConversant.HasNext());
            }
            
        }

        private void BUildChoiceList()
        {
            foreach (Transform item in choiceRoot)
            {
                Destroy(item.gameObject);
            }

            foreach (var choice in playerConversant.GetChoices())
            {
                var choiceInstance = Instantiate(choiceButtonPrefab, choiceRoot);
                var textComponent = choiceInstance.GetComponentInChildren<TextMeshProUGUI>();
                textComponent.text = choice.GetText();
                // choice.GetAudioSource().Play();

                var button = choiceInstance.GetComponentInChildren<Button>();
                button.onClick.AddListener(() =>
                {
                    playerConversant.SelectChoice(choice);
                });
            }
        }
    }
}
