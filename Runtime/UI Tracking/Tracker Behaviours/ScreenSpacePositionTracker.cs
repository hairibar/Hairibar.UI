using UnityEngine;

namespace Hairibar.UI.Tracking
{
    /// <summary>
    /// Matches the tracked object's screen space position.
    /// </summary>
    public class ScreenSpacePositionTracker : BaseUITrackerBehaviour
    {
        /// <summary>
        /// Should the tracker stay at the screen's border when the tracked object goes off the screen?
        /// </summary>
        [Tooltip("Should the tracker stay at the screen's border when the tracked object goes off the screen?")]
        public bool clampInsideScreen = true;


        private RectTransform rectTransform;


        private void Update()
        {
            Vector3 targetPosition = Tracker.TargetPositionInScreenSpace;

            if (clampInsideScreen)
            {
                targetPosition.x = Mathf.Clamp01(targetPosition.x);
                targetPosition.y = Mathf.Clamp01(targetPosition.y);
            }
            
            rectTransform.anchorMin = targetPosition;
            rectTransform.anchorMax = targetPosition;

            Rect viewRect = rectTransform.rect;
            Vector2 anchoredPosition = Vector2.zero;

            if (clampInsideScreen)
            {
                if (targetPosition.x == 0) anchoredPosition.x = viewRect.width / 2;
                else if (targetPosition.x == 1) anchoredPosition.x = -viewRect.width / 2;

                if (targetPosition.y == 0) anchoredPosition.y = viewRect.height / 2;
                else if (targetPosition.y == 1) anchoredPosition.y = -viewRect.height / 2;
            }
            
            rectTransform.anchoredPosition = anchoredPosition;
        }

        private void Start()
        {
            rectTransform = GetComponent<RectTransform>();
        }
    }
}
