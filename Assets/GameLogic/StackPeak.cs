using UnityEngine;

namespace GameLogic
{
    public class StackPeak : MonoBehaviour
    {
        /// <summary>
        /// Reference to a transform that is moved towards to top of stack
        /// </summary>
        [SerializeField]
        private Transform _stackTopTransform = default;

        [SerializeField]
        private CatStacker _stacker = default;

        [SerializeField]
        private Vector2 _offset = default;

        private void FixedUpdate()
        {
            _stackTopTransform.transform.position = _stacker.Top + _offset;
        }

        private Vector2 _vel;
    }
}
