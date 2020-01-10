using UnityEngine;

#pragma warning disable 649
namespace Hairibar.UI.MenuScreenManagement
{
    /// <summary>
    /// Central component of the Menu Screen system. 
    /// Each screen should be a child GameObject of the MenuScreenManager, with a component that inherits from AMenuScreen.
    /// </summary>
    [AddComponentMenu("Menu Screens/Menu Screen Manager"), DisallowMultipleComponent]
    public class MenuScreenManager : MonoBehaviour
    {
        /// <summary>
        /// The MenuScreen that will be shown first. 
        /// If changed at runtime, it will only have effect if set before Start() is called.
        /// </summary>
        [Tooltip("The MenuScreen that will be shown first. Can also be set at runtime.")]
        public AMenuScreen startingMenuScreen;

        private AMenuScreen[] menuScreens;
        private AMenuScreen currentActiveMenuScreen;


        public void SetActiveMenuScreen<T>() where T : AMenuScreen
        {
            for (int i = 0; i < menuScreens.Length; i++)
            {
                if (menuScreens[i] && menuScreens[i] is T)
                {
                    SetActiveMenuScreen(menuScreens[i]);
                    return;
                }
            }

            Debug.LogError($"No Menu Screen \"{typeof(T).FullName}\" was found.");
        }

        public void SetActiveMenuScreen(AMenuScreen menuScreen)
        {
            AMenuScreen previousScreen = currentActiveMenuScreen;
            if (previousScreen) previousScreen.Close(menuScreen.GetType());

            currentActiveMenuScreen = menuScreen;
            menuScreen.Open(previousScreen?.GetType());
        }

        public void GoBack()
        {
            currentActiveMenuScreen.GoBack();
        }


        #region Initialization
        private void Awake()
        {
            InitializeMenuScreens();
        }

        private void InitializeMenuScreens()
        {
            menuScreens = GetComponentsInChildren<AMenuScreen>(true);
            for (int i = 0; i < menuScreens.Length; i++)
            {
                menuScreens[i].Initialize(this);
            }
        }

        private void Start()
        {
            SetActiveMenuScreen(startingMenuScreen);
        }
        #endregion
    }
}