using UnityEngine;

namespace Assets.Game.Scripts.Core
{
    public class SoundManager : MonoBehaviour
    {
        public static SoundManager instance;

        private void Awake()
        {
            instance = this;
        }

        public void PlayClip(AudioSource audioSource, AudioClip audioClip)
        {
            audioSource.Stop();
            if (audioClip == null) return;
            audioSource.clip = audioClip;
            audioSource.Play();
        }
    }
}
