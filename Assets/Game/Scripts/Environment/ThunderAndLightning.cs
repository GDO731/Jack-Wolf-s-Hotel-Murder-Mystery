using UnityEngine;
using UnityEngine.Audio;

public class ThunderAndLightning : MonoBehaviour
{
    [Header("Thunder Audio")]
    public AudioSource thunderSource; // Seperate Thunder Audio Source
    public AudioClip[] thunderClips; // Ability to add multiple clips for randomness

    [Header("Timing")]
    // Adjustable Lightning Timing
    public float minTimeBetweenThunder = 15f;
    public float maxTimeBetweenThunder = 45f;

    [Header("Indoor Muffling")]
    public AudioMixerSnapshot outdoorSnapshot;
    public AudioMixerSnapshot indoorSnapshot;


    private float nextThunderTime;

    void Start()
    {
        nextThunderTime = Time.time + Random.Range(8f, 20f);
    }

    void Update()
    {
        // Check if player is indoors
        bool isIndoors = Physics.CheckSphere(transform.position, 1.5f, LayerMask.GetMask("WeatherBlock"));

        if (Time.time >= nextThunderTime)
        {
            // Call Thunder Function
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
