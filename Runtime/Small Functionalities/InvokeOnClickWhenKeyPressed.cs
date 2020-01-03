using UnityEngine;
using UnityEngine.UI;

namespace Hairibar.UI
{
    [RequireComponent(typeof(Button))]
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
