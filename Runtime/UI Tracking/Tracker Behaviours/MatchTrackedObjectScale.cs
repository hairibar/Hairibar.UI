using UnityEngine;

namespace Hairibar.UI.Tracking
{
    /// <summary>
    /// Matches the local scale of the tracked object.
    /// </summary>
    [AddComponentMenu("UI/Tracking/Match Tracked Object Scale"), DisallowMultipleComponent]
    public class MatchTrackedObjectScale : BaseUITrackerBehaviour
    {
        private void LateUpdate()
        {
            transform.localScale = Tracker.TrackedObject.transform.localScale;
        }
    }
}