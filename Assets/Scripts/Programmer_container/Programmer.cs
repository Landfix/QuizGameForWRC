using Systems;
using UnityEngine;

namespace Programmer_container
{
    public class Programmer : MonoBehaviour
    {
        [SerializeField] private ProgrammerAnimator _animator;

        public void Initialize(GameSystemHandlers gameSystemHandlers)
        {
            _animator.Initialize();
            gameSystemHandlers.GotAttempts += GotAttempts;
        }

        private void GotAttempts(int attempts)
        {
            switch (attempts)
            {
                case -1:
                    Debug.Log("Boom!");
                    break;
                case 0:
                    _animator.SetBurnState();
                    break;
                case 1:
                    _animator.SetSmokesHeavilyState();
                    break;
                case 2:
                    _animator.SetFaintlySmokesState();
                    break;
                case 3:
                    _animator.SetIdleState();
                    break;
            }
        }
    }
}