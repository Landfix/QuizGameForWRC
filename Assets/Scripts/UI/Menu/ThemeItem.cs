using Systems;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace UI.Menu
{
    [RequireComponent(typeof(Button))]
    public class ThemeItem : MonoBehaviour
    {
        [SerializeField] private ThemeType _themeType;
        [SerializeField] private Button _selectedThemeBtn;

        private Preferences _preferences;
        private string _nextScene;
        
        public void Initialize(Preferences preferences, string nextScene)
        {
            _preferences = preferences;
            _nextScene = nextScene;
            _selectedThemeBtn.onClick.AddListener(OnClickSelectedTheme);
        }

        private void OnClickSelectedTheme()
        {
            _preferences.SetTheme((int)_themeType);
            _selectedThemeBtn.onClick.RemoveListener(OnClickSelectedTheme);
            SceneManager.LoadScene(_nextScene);
        }
    }
}