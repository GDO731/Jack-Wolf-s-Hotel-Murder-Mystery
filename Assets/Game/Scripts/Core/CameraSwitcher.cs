using UnityEngine;
using Unity.Cinemachine;
using System.Collections;

namespace Assets.Game.Scripts.Core
{
    public class CameraSwitcher : MonoBehaviour
    {
        [SerializeField] CinemachineVirtualCameraBase[] allCameras;
        [SerializeField] CinemachineVirtualCameraBase followCamera;
        [SerializeField] int activePriority = 20;
        [SerializeField] int inactivePriority = 10;
        [SerializeField] ScreenFader screenFader;

        bool isTransitioning;

        public void SwitchToCamera(CinemachineVirtualCameraBase targetCamera)
        {
            if (isTransitioning) return;
            StartCoroutine(RunTransition(targetCamera));
        }

        public void ReturnToFollowCamera() => SwitchToCamera(followCamera);

        private IEnumerator RunTransition(CinemachineVirtualCameraBase targetCamera)
        {
            isTransitioning = true;
            yield return screenFader.FadeTransition(() => ApplyPriorities(targetCamera));
            isTransitioning = false;
        }

        private void ApplyPriorities(CinemachineVirtualCameraBase targetCamera)
        {
            foreach (var cam in allCameras)
                cam.Priority.Value = (cam == targetCamera) ? activePriority : inactivePriority;
        }
    }
}