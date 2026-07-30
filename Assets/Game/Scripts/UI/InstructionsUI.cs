using Assets.Game.Scripts.Core;
using System.Collections;
using TMPro;
using UnityEngine;

namespace Assets.Game.Scripts.UI
{
    public class InstructionsUI : MonoBehaviour
    {
        [SerializeField] GameObject inctructionsUI;
        [SerializeField] InputReader inputReader;
        [SerializeField] TextMeshProUGUI instruction;
        [SerializeField] float visibleDuration = 5f;
        [SerializeField] AudioSource audioSource;
        [SerializeField] AudioClip openClip;
        [SerializeField] AudioClip closeClip;

        Coroutine autoHideRoutine;
        Coroutine showRoutine;

        private const float InitalDelay = 0.5f;

        void OnEnable() => inputReader.InstructionsEvent += ToggleInstructions;
        void OnDisable() => inputReader.InstructionsEvent -= ToggleInstructions;

        private void Start()
        {
            Show(InitalDelay);
        }

        public void UpdateText(string text)
        {
            instruction.text = text;
        }

        public void Show(float delay = 0f)
        {
            if (showRoutine != null) StopCoroutine(showRoutine);
            showRoutine = StartCoroutine(ShowAfterDelay(delay));
        }

        void ToggleInstructions()
        {
            bool showing = !inctructionsUI.activeSelf;
            inctructionsUI.SetActive(showing);

            if (showing)
            {
                Hide();
            }
            else
            {
                SoundManager.instance.PlayClip(audioSource, closeClip);
            }
        }

        private void Hide()
        {
            SoundManager.instance.PlayClip(audioSource, openClip);
            if (autoHideRoutine != null) StopCoroutine(autoHideRoutine);
            autoHideRoutine = StartCoroutine(AutoHide());
        }

        private IEnumerator AutoHide()
        {
            yield return new WaitForSeconds(visibleDuration);
            inctructionsUI.SetActive(false);
            SoundManager.instance.PlayClip(audioSource, closeClip);
        }

        private IEnumerator ShowAfterDelay(float delay)
        {
            if (delay > 0f) yield return new WaitForSeconds(delay);
            inctructionsUI.SetActive(true);
            Hide();
        }
    }
}
