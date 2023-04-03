using Systems;
using DG.Tweening;
using UnityEngine;

namespace UI.Menu
{
    [RequireComponent(typeof(CanvasGroup))]
    public class ThemeContainer : MonoBehaviour
    {
        private const string GameScene = "Game";
        
        [SerializeField] private ThemeItem[] _themeItems;
        [SerializeField] private CanvasGroup _canvasGroup;
        
        private Preferences _cachedPreferences;

        public void Initialize()
        {
            _cachedPreferences = GlobalManager.I.Preferences;
            InitializeThemeItems();
            SharpHideContainer();
        }

        private void InitializeThemeItems()
        {
            foreach (ThemeItem themeItem in _themeItems)
            {
                themeItem.Initialize(_cachedPreferences, GameScene);
            }
        }

        private void SharpHideContainer()
        {
            _canvasGroup.alpha = 0;
            _canvasGroup.interactable = false;
            _canvasGroup.blocksRaycasts = false;
        }

        public void ShowContainer()
        {
            _canvasGroup.DOFade(1, 0.3f);
            _canvasGroup.interactable = true;
            _canvasGroup.blocksRaycasts = true;
        }
    }
}