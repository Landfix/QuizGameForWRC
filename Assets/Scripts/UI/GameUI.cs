using Systems;
using Config;
using UnityEngine;

namespace UI
{
    public class GameUI : MonoBehaviour
    {
        [SerializeField] private TimeContainer _timeContainer;
        [SerializeField] private QuizContainer _quizContainer;

        private Bootstrapper _bootstrapper;

        public void Initialize(Bootstrapper bootstrapper, BootstrapperConfig bootstrapperConfig)
        {
            _bootstrapper = bootstrapper;
            _quizContainer.Initialize();
            _timeContainer.Initialize(bootstrapperConfig.GameDuration);
            _timeContainer.TimeIsUp += _bootstrapper.EndGame;
        }
    }
}