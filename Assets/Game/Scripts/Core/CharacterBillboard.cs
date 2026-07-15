using UnityEngine;

namespace Assets.Game.Scripts.Core
{
    public class CharacterBillboard : MonoBehaviour
    {
        Transform cameraTransform;

        void Start()
        {
            cameraTransform = Camera.main.transform;
        }

        void LateUpdate()
        {
            Vector3 directionToCamera = cameraTransform.position - transform.position;
            directionToCamera.y = 0f;

            if (directionToCamera.sqrMagnitude > 0.0001f)
            {
                transform.rotation = Quaternion.LookRotation(directionToCamera);
            }
        }
    }
}
