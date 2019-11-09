using UnityEngine;

namespace GameLogic
{
    public class Game : MonoBehaviour
    {
        [SerializeField]
        private PlayerController _playerController = null;

        private void Update()
        {
            _playerController.PlaceCats();
        }

        public enum GameStates
        {
            Start,
            Intro,
            Stack,
            TransitionToStart
        }
    }
}
