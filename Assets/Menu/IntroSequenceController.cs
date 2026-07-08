using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class IntroSequenceController : MonoBehaviour
{
    [Header("UI Text References")]
    public TextMeshProUGUI studioNameText;
    public TextMeshProUGUI gameTitleText;

    [Header("Scene to Load")]
    public string nextSceneName = "MainMenu";

    void Start()
    {
        StartCoroutine(ExecuteTimeline());
    }

    IEnumerator ExecuteTimeline()
    {
        // --- 1) STUDIO NAME TIMELINE ---
        yield return new WaitForSeconds(1f); // Wait 1 Second
        yield return StartCoroutine(FadeText(studioNameText, 0f, 1f, 1f)); // Fade in (Sec 1 to 2)
        yield return new WaitForSeconds(1f); // Stay on screen for 2 seconds (Sec 2 to 3)
        yield return StartCoroutine(FadeText(studioNameText, 1f, 0f, 1f)); // Fade out (Sec 3 to 4)

        // --- 2) GAME TITLE TIMELINE ---
        yield return new WaitForSeconds(1f); // Wait 1 second (Sec 4 to 5)
        yield return StartCoroutine(FadeText(gameTitleText, 0f, 1f, 1f)); // Fade in (Sec 5 to 6)
        yield return new WaitForSeconds(2f); // Stay on screen for 2 seconds (Sec 6 to 8)
        yield return StartCoroutine(FadeText(gameTitleText, 1f, 0f, 1f)); // Fade out (Sec 8 to 9)

        // --- 3) LOAD NEW SCENE ---
        yield return new WaitForSeconds(2f); // Wait 1 more second (Sec 9 to 10)
        SceneManager.LoadScene("MenuMain");
    }

    // Helper function to smoothly fade any TMP text element
    IEnumerator FadeText(TextMeshProUGUI textElement, float startAlpha, float endAlpha, float duration)
    {
        float currentTime = 0f;
        Color originalColor = textElement.color;

        while (currentTime < duration)
        {
            currentTime += Time.deltaTime;
            float alpha = Mathf.Lerp(startAlpha, endAlpha, currentTime / duration);
            textElement.color = new Color(originalColor.r, originalColor.g, originalColor.b, alpha);
            yield return null;
        }

        // Ensure it strictly hits the target alpha at the end
        textElement.color = new Color(originalColor.r, originalColor.g, originalColor.b, endAlpha);
    }
}