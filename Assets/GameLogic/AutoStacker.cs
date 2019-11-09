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
                var newCat = _catStacker.GetRandomCat();
                _catStacker.StackCat(newCat, Random.Range(-1, 1));
            }
        }

        private float _lastStackTime = 0;
    }
}
