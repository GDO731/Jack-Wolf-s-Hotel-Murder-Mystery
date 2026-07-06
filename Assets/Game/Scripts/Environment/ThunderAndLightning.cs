using UnityEngine;
using UnityEngine.Audio;

public class ThunderAndLightning : MonoBehaviour
{
    [Header("Thunder Audio")]
    public AudioSource thunderSource;
    public AudioClip[] thunderClips; // Ability to add multiple clips for randomness

    [Header("Timing")]
    // Adjustable Lightning Timing
    public float minTimeBetweenThunder = 15f;
    public float maxTimeBetweenThunder = 45f;

    private float nextThunderTime;

    void Start()
    {
        nextThunderTime = Time.time + Random.Range(8f, 20f);
    }

    void Update()
    {
        if (Time.time >= nextThunderTime)
        {
            TriggerThunder();

            // Schedule next thunder time
            nextThunderTime = Time.time + Random.Range(minTimeBetweenThunder, maxTimeBetweenThunder);
        }
    }

    void TriggerThunder()
    {
        // Play random thunder sound
        if (thunderClips.Length > 0 && thunderSource != null)
        {
            thunderSource.clip = thunderClips[Random.Range(0, thunderClips.Length)];
            thunderSource.Play();
        }

    }

}
