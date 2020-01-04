using UnityEngine;

namespace Hairibar.UI
{
    public class RectMargin : MonoBehaviour
    {
        public float marginSize;

        private void Start()
        {
            RectTransform marginHolder = new GameObject("Margin", typeof(RectTransform)).GetComponent<RectTransform>();
            marginHolder.SetParent(transform.parent);

            marginHolder.anchorMin = Vector2.zero;
            marginHolder.anchorMax = Vector2.one;
            marginHolder.offsetMin = new Vector2(marginSize, marginSize);
            marginHolder.offsetMax = new Vector2(-marginSize, -marginSize);

            transform.SetParent(marginHolder);

            Destroy(this);
        }
    }

}
