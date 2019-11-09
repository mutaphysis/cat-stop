using UnityEngine;

namespace GameLogic
{
    public class CameraController : MonoBehaviour
    {
        [SerializeField]
        private Camera _camera = null;

        [SerializeField]
        private CatStacker _catStacker = null;

        [SerializeField]
        private float _smoothTime = 1.0f;

        [SerializeField]
        private float _offset = 3f;

        private void Update()
        {
            var cameraPosition = _camera.transform.position;
            var targetCameraPosition = _catStacker.Top.y + _offset;
            var damped = Mathf.SmoothDamp(cameraPosition.y, targetCameraPosition, ref _cameraVelocity, _smoothTime);

            cameraPosition.y = damped;
            _camera.transform.position = cameraPosition;
        }

        private float _cameraVelocity = 0f;
    }
}
