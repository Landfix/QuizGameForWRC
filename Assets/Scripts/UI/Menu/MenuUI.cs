using UnityEngine;
using UnityEngine.UI;

namespace UI.Menu
{
    public class MenuUI : MonoBehaviour
    {
        [SerializeField] private Button _selectThemeBtn;
        [SerializeField] private ThemeContainer _themeContainer;
        private void Start()
        {
            _themeContainer.Initialize();
            _selectThemeBtn.onClick.AddListener(OnClickOpenThemes);
        }

        private void OnClickOpenThemes()
        {
            _themeContainer.ShowContainer();
        }
    }
}