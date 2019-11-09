using UnityEngine;

namespace GameLogic
{
    public class StackableCat : MonoBehaviour
    {
        [SerializeField]
        private float _weight = 1;

        public float Weight => _weight;

        public Vector2 Position => transform.position;

        private void Awake()
        {
            _rigidBody = gameObject.AddComponent<Rigidbody2D>();
            _rigidBody.mass = _weight;
            _rigidBody.simulated = false;
            _rigidBody.bodyType = RigidbodyType2D.Static;
        }

        public void AttachToCat(StackableCat previous)
        {
            _hinge = previous.gameObject.AddComponent<HingeJoint2D>();
            _hinge.useLimits = true;

            var rotationOffset = -previous.transform.eulerAngles.z;
            var limits = new JointAngleLimits2D
            {
                min = (-135f + rotationOffset + 360f) % 360f,
                max = (-45f + rotationOffset + 360f) % 360f
            };
            _hinge.limits = limits;
            _hinge.connectedBody = _rigidBody;
            var motor = new JointMotor2D
            {
                motorSpeed = 10,
                maxMotorTorque = 10000
            };
            _hinge.motor = motor;
            _hinge.useMotor = true;

            _distance = previous.gameObject.AddComponent<DistanceJoint2D>();
            _distance.autoConfigureDistance = false;
            _distance.distance = 2.5f;
            _distance.connectedBody = _rigidBody;

            _rigidBody.bodyType = RigidbodyType2D.Dynamic;
            _rigidBody.simulated = true;
        }

        public void FixToPosition()
        {
            _rigidBody.bodyType = RigidbodyType2D.Static;
            _rigidBody.simulated = true;
        }

        public float DetermineHeight()
        {
            var spriteRenderer = GetComponent<SpriteRenderer>();
            // var spriteHeight = spriteRenderer.size.y;
            var sprite = spriteRenderer.sprite;
            var border = sprite.border;
            var sizeInSprite = (border.z + border.w) / sprite.pixelsPerUnit;
            var height = sizeInSprite;
            return height;
        }

        private Rigidbody2D _rigidBody;
        private HingeJoint2D _hinge;
        private DistanceJoint2D _distance;
    }
}
