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
            if (hasFired && triggerOnce) return;
            if (!other.CompareTag(TagConstants.PlayerTag)) return;
            onTrigger.Invoke();
            hasFired = true;
        }
    }
}
