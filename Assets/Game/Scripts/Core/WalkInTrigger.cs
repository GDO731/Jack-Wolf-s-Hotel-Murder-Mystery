using UnityEngine;
using UnityEngine.Events;

namespace Assets.Game.Scripts.Core
{
    [RequireComponent(typeof(Collider))]
    public class WalkInTrigger : MonoBehaviour
    {
        [SerializeField] UnityEvent onTrigger;
        [SerializeField] bool triggerOnce = true;

        bool hasFired = false;

        private void OnTriggerEnter(Collider other)
        {
            Debug.Log("Here");
            if (hasFired && triggerOnce) return;
            if (!other.CompareTag(TagConstants.PlayerTag)) return;
            Debug.Log("Here2");
            onTrigger.Invoke();
            hasFired = true;
        }
    }
}
