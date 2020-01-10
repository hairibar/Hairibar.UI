using UnityEngine;
using UnityEngine.UI;

namespace Hairibar.UI
{
    /// <summary>
    /// Invokes the attached Button's OnClick when the selected key is pressed.
    /// Useful for keyboard shortcuts and confirmation buttons.
    /// </summary>
    [RequireComponent(typeof(Button)), AddComponentMenu("UI/Invoke OnClick When Key Pressed")]
    public class InvokeOnClickWhenKeyPressed : MonoBehaviour
    {
        public KeyCode key = KeyCode.Return;

        private void Update()
        {
            if (Input.GetKeyDown(key))
            {
                GetComponent<Button>().onClick.Invoke();
            }
        }
    }
}
