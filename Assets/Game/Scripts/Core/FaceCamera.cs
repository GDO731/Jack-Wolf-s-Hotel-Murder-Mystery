using UnityEngine;

namespace Assets.Game.Scripts.Core
{
    public class FaceCamera : MonoBehaviour
    {
        void Update()
        {
            transform.forward = Camera.main.transform.forward;
        }
    }
}
