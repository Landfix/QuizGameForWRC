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
        private BootstrapperConfig _bootstrapperConfig;

        public void Initialize(Bootstrapper bootstrapper, BootstrapperConfig bootstrapperConfig)
        {
            _bootstrapper = bootstrapper;
            _bootstrapperConfig = bootstrapperConfig;
            _quizContainer.Initialize();
            _timeContainer.Initialize(_bootstrapperConfig.GameDuration);
            _timeContainer.TimeIsUp += TimeIsUp;
        }

        private void TimeIsUp()
        {
            _quizContainer.UpdateQuiz(false);
            _timeContainer.TimeIsUp -= TimeIsUp;
            _timeContainer.Initialize(_bootstrapperConfig.GameDuration);
        }
    }
}