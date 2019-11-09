using Physics;
using UnityEngine;

namespace GameLogic
{
    public class Game : MonoBehaviour
    {
        [SerializeField]
        private AbstractCatStackPhysics _physics = null;

        [SerializeField]
        private PlayerController _playerController = null;

        private void Update()
        {
            _physics.UpdatePhysics();
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
