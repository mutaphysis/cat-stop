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

        public void Awake()
        {
            _catStacker.StackTopChange += OnStackTopChangedHandler;
        }

        private void Update()
        {
            var cameraPosition = _camera.transform.position;
            var damped = Mathf.SmoothDamp(cameraPosition.y, _targetCameraPosition, ref _cameraVelocity, _smoothTime);

            cameraPosition.y = damped;
            _camera.transform.position = cameraPosition;
        }

        private void OnStackTopChangedHandler(Vector2 top)
        {
            _targetCameraPosition = top.y;
        }

        private float _cameraVelocity = 0f;
        private float _targetCameraPosition = 0f;
    }
}
