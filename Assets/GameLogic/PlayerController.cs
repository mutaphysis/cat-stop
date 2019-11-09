using UnityEngine;

namespace GameLogic
{
    /// <summary>
    /// Controls character and placement of cats
    /// </summary>
    public class PlayerController : MonoBehaviour
    {
        [SerializeField]
        private CatStacker _catStacker = default;
        
        [SerializeField] private float _catScale = 0.4f;

        [SerializeField] private float _catRotationMin = 10;
        [SerializeField] private float _catRotationMax = 90;
        
        [Header("--- internal prefab references ------")]
        [SerializeField]
        private float _placementPeriod = 2;

        [SerializeField]
        private Animator _animator = default;

        [SerializeField]
        private float _limitMouseRange = 5f;

        [SerializeField]
        private Transform _handTransform = default;

        
        
        private StackableCat _grabbedCat = null;

        public void PlaceCats()
        {
            var normalized = Input.mousePosition.x / Screen.width;
            normalized = (normalized - 0.5f) * _limitMouseRange + 0.5f;

            _animator.SetFloat(_placementPropertyName, normalized);

            var catAge = Time.time - _lastPlacementTime;
            var shouldPlaceCat = catAge > _placementPeriod;
            if (shouldPlaceCat)
            {
                PlaceNewCat();
            }

            if (_grabbedCat)
                _grabbedCat.transform.localScale = Vector3.one * _catScaleUp.Evaluate(catAge) * _catScale;
        }

        private void PlaceNewCat()
        {
            _animator.SetBool(_grammingPropertyName, true);
            _lastPlacementTime = Time.time;
            Invoke("ResetGrabbing", 0.2f);
            PlaceAndGrabNewCat();
        }

        private void PlaceAndGrabNewCat()
        {
            if (_grabbedCat)
            {
                _catStacker.StackInstantiatedCat(_grabbedCat);
                _grabbedCat = null;
            }

            var randomCatPrefab = _catStacker.GetRandomCatPrefab();
            _grabbedCat = Instantiate(randomCatPrefab, _handTransform);
            _grabbedCat.transform.Translate(Vector3.back* 0.2f);
            var angles = _grabbedCat.transform.localEulerAngles;
            angles.z += Random.Range(_catRotationMin, _catRotationMax);
            _grabbedCat.transform.localEulerAngles = angles;
            //_grabbedCat.transform.RotateAround();
            _grabbedCat.transform.localScale = Vector3.zero;
        }

        private void ResetGrabbing()
        {
            _animator.SetBool(_grammingPropertyName, false);
        }

        private float _lastPlacementTime;
        private const string _placementPropertyName = "placement";
        private const string _grammingPropertyName = "grabbing";


        public AnimationCurve _catScaleUp = default;
    }
}
