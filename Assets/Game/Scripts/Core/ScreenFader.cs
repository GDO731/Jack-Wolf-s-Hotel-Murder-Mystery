using System;
using System.Collections;
using UnityEngine;

namespace Assets.Game.Scripts.Core
{
    public class ScreenFader : MonoBehaviour
    {
        private CanvasGroup canvasGroup;
        [SerializeField] float fadeDuration = 0.5f;
        [SerializeField] float holdDuration = 0.2f;

        Coroutine activeFade;
        private void Start()
        {
            canvasGroup = GetComponent<CanvasGroup>();
        }

        public IEnumerator FadeTransition(Action duringBlackout)
        {
            yield return Fade(1f);
            duringBlackout?.Invoke();
            if (holdDuration > 0f) yield return new WaitForSeconds(holdDuration);
            yield return Fade(0f);
        }

        private IEnumerator Fade(float targetAlpha)
        {
            float startAlpha = canvasGroup.alpha;
            float elapsed = 0f;
            canvasGroup.blocksRaycasts = true;

            while (elapsed < fadeDuration)
            {
                elapsed += Time.deltaTime;
                canvasGroup.alpha = Mathf.Lerp(startAlpha, targetAlpha, elapsed / fadeDuration);
                yield return null;
            }

            canvasGroup.alpha = targetAlpha;
            canvasGroup.blocksRaycasts = targetAlpha > 0f;
        }
    }
}
