using UnityEngine;

namespace GameLogic
{
    public class AutoStacker : MonoBehaviour
    {
        [SerializeField]
        private float _timeToNextStack = 1;

        [SerializeField]
        private CatStacker _catStacker = null;

        private void Update()
        {
            if (Time.time > _lastStackTime + _timeToNextStack)
            {
                var newCat = _catStacker.GetRandomCatPrefab();
                _catStacker.StackCat(newCat, Random.Range(-1f, 1f), Random.Range(0f, 360f));
                _lastStackTime = Time.time;
            }

            if (Input.GetMouseButtonDown(0))
            {
                _catStacker.Clear();
            }
        }

        private float _lastStackTime = 0;
    }
}
