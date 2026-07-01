using Assets.Game.Scripts.Core;
using Assets.Game.Scripts.Dialogue;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
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
        [SerializeField] AudioSource audioSource;

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
                BuildChoiceList();
            }
            else
            {
                var dialogueNode = playerConversant.GetNode();
                aiText.text = dialogueNode.GetText();

                PlayClip(dialogueNode.GetAudioClip());

                nextButton.gameObject.SetActive(playerConversant.HasNext());
            }
            
        }

        private void BuildChoiceList()
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


                var button = choiceInstance.GetComponentInChildren<Button>();
                button.onClick.AddListener(() =>
                {
                    DisableAllChoiceButtons();
                    PlayClip(choice.GetAudioClip());
                    StartCoroutine(AdvanceAfterAudio());
                    playerConversant.SelectChoice(choice);
                });
            }
        }

        private void PlayClip(AudioClip clip)
        {
            audioSource.Stop();
            if (clip == null) return;
            audioSource.clip = clip;
            audioSource.Play();
        }

        private void DisableAllChoiceButtons()
        {
            foreach (Transform item in choiceRoot)
            {
                var btn = item.GetComponentInChildren<Button>();
                if (btn != null)
                {
                    btn.interactable = false;
                }
            }
        }

        IEnumerator AdvanceAfterAudio()
        {
            yield return null;
            yield return new WaitWhile(() => audioSource.isPlaying);
            playerConversant.Next();
        }
    }
}
