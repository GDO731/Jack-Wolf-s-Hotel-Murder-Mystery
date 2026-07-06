using UnityEngine;
using UnityEngine.Audio;

public class PlayerWeatherAudio : MonoBehaviour
{
    [Header("Player Collider")]
    public Collider playerCollider; //Player Collider

    [Header("Audio")] // Audio Snapshot fields from Audio Mixer
    public AudioMixerSnapshot outdoorSnapshot;
    public AudioMixerSnapshot indoorSnapshot;
    // Adjustable transition time variable
    public float transitionTime = 1.5f;

    [Header("Layer")] // Layer field that must include colliders, type doesn't matter
    public LayerMask weatherBlockLayer;

    private bool isIndoors = false;

    void Update()
    {
        if (playerCollider == null) return;

        // Check if the player Collider is overlapping with layer field colliders
        bool nowIndoors = Physics.CheckCapsule(
            playerCollider.bounds.center - Vector3.up * 0.5f,
            playerCollider.bounds.center + Vector3.up * 0.5f,
            playerCollider.bounds.extents.x * 0.8f,
            weatherBlockLayer
        );

        if (nowIndoors != isIndoors)
        {
            isIndoors = nowIndoors;
            AudioMixerSnapshot target = isIndoors ? indoorSnapshot : outdoorSnapshot;
            target.TransitionTo(transitionTime);
        }
    }
}
