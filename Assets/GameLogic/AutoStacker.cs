using Physics;
using UnityEngine;

namespace GameLogic
{
    public class AutoStacker : MonoBehaviour
    {
        [SerializeField]
        private float _timeToNextStack = 1;

        [SerializeField]
        private CatStacker _catStacker = null;

        [SerializeField]
        private AbstractCatStackPhysics _physics = null;

        private void Update()
        {
            if (Time.time > _lastStackTime + _timeToNextStack)
            {
                var newCat = _catStacker.GetRandomCat();
                _catStacker.StackCat(newCat, Random.Range(-1f, 1f), Random.Range(0f, 360f));
                _lastStackTime = Time.time;
            }

            if (Input.GetMouseButtonDown(0))
            {
                _catStacker.Clear();
            }

            _physics.UpdatePhysics();
        }

        private float _lastStackTime = 0;
    }
}
