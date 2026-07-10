using UnityEngine;
using Unity.Cinemachine;

namespace Assets.Game.Scripts.Core
{
    public class CameraSwitcher : MonoBehaviour
    {
        [SerializeField] CinemachineVirtualCameraBase[] allCameras;
        [SerializeField] CinemachineVirtualCameraBase followCamera;
        [SerializeField] int activePriority = 20;
        [SerializeField] int inactivePriority = 10;

        public void SwitchToCamera(CinemachineVirtualCameraBase targetCamera)
        {
            foreach (var cam in allCameras)
            {
                cam.Priority.Value = (cam == targetCamera) ? activePriority : inactivePriority;
            }
        }

        public void ReturnToFollowCamera()
        {
            SwitchToCamera(followCamera);
        }
    }
}