using UnityEngine;

namespace Assets.Game.Scripts.Core
{
    public class Mover : MonoBehaviour
    {
        CharacterController controller;

        void Awake()
        {
            controller = GetComponent<CharacterController>();
        }

        public void SnapToPoint(Transform targetPoint)
        {
            if (controller != null) controller.enabled = false;

            transform.position = targetPoint.position;
            transform.rotation = targetPoint.rotation;

            if (controller != null) controller.enabled = true;
        }
    }
}
