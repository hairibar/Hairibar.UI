using UnityEngine;

#pragma warning disable 649
namespace Hairibar.UI.Tracking
{
    [AddComponentMenu("UI/Tracking/Set Visible When Off Screen"), DisallowMultipleComponent]
    public class SetTrackerVisibleWhenOffscreen : BaseUITrackerBehaviour
    {
        #region Inspector
        /// <summary>
        /// If true, the tracker will be visible when on screen and invisible when off screen.
        /// </summary>
        [Tooltip("If true, the tracker will be visible when on screen and invisible when off screen.")]
        public bool invertVisible = false;
        #endregion

        private bool TrackedObjectIsOnScreen
        {
            get
            {
                Vector3 positionInMainViewport = Tracker.camera.WorldToViewportPoint(Tracker.TrackedObject.transform.position);

                return (positionInMainViewport.x > 0 && positionInMainViewport.x < 1 &&
                    positionInMainViewport.y > 0 && positionInMainViewport.y < 1);
            }
        }

        private void LateUpdate()
        {
            Tracker.IsVisible = TrackedObjectIsOnScreen == invertVisible;
        }
    }
}