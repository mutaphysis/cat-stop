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
        private Vector2 _offset = new Vector2(0f, 3f);

        private void Update()
        {
            var cameraPosition = _camera.transform.position;
            var targetCameraPosition = _catStacker.Top + _offset;
            var damped = Vector3.SmoothDamp(cameraPosition, targetCameraPosition, ref _cameraVelocity, _smoothTime);
            _camera.transform.position = new Vector3(damped.x, damped.y, cameraPosition.z);
            ;
        }

        private Vector3 _cameraVelocity = Vector2.zero;
    }
}
