using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hairibar.UI.Tracking
{
    public class ScreenSpacePositionTracker : BaseUITrackerBehaviour
    {
        private RectTransform rectTransform;

        private void Update()
        {
            Vector3 newPos = transform.position;

            Vector3 unclampedPos = Tracker.camera.WorldToViewportPoint(Tracker.TrackedObject.transform.position);

            Vector3 normalizedPos;
            normalizedPos.x = Mathf.Clamp01(unclampedPos.x);
            normalizedPos.y = Mathf.Clamp01(unclampedPos.y);
            normalizedPos.z = unclampedPos.z;

            rectTransform.anchorMin = normalizedPos;
            rectTransform.anchorMax = normalizedPos;

            Rect viewRect = rectTransform.rect;
            Vector2 anchoredPosition = Vector2.zero;

            if (normalizedPos.x == 0) anchoredPosition.x = viewRect.width / 2;
            else if (normalizedPos.x == 1) anchoredPosition.x = -viewRect.width / 2;

            if (normalizedPos.y == 0) anchoredPosition.y = viewRect.height / 2;
            else if (normalizedPos.y == 1) anchoredPosition.y = -viewRect.height / 2;

            rectTransform.anchoredPosition = anchoredPosition;
        }

        private void Start()
        {
            rectTransform = GetComponent<RectTransform>();
        }
    }
}
