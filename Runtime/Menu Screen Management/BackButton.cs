using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Hairibar.UI.MenuScreenManagement
{
    /// <summary>
    /// Button that calls GoBack on a parent MenuScreenManager.
    /// </summary>
    [RequireComponent(typeof(Button))]
    public class BackButton : MonoBehaviour
    {
        /// <summary>
        /// Goes back from the current MenuScreen.
        /// </summary>
        public void GoBack()
        {
            AMenuScreen menuScreen = GetComponentInParent<AMenuScreen>();
            if (menuScreen) menuScreen.GoBack();
            else Debug.LogError("BackButton isn't a child of any AMenuScreen.", this);
        }

        private void Start()
        {
            UnityEvent onClick = GetComponent<Button>().onClick;

            for (int i = 0; i < onClick.GetPersistentEventCount(); i++)
            {
                if (onClick.GetPersistentTarget(i) == this)
                {
                    onClick.SetPersistentListenerState(i, UnityEventCallState.Off);
                }
            }

            onClick.AddListener(GoBack);
        }
    }
}

