using UnityEngine;

namespace Hairibar.UI.Tracking
{
    /// <summary>
    /// Rotates the tracker to face the tracked object.
    /// </summary>
    public class FaceTrackedObject : BaseUITrackerBehaviour
    {
        [SerializeField, Tooltip("The direction that the tracker faces towards without applying any rotation.")]
        private Vector2 baseFacing = new Vector2(1, 0);

        private void Update()
        { 
            float angle = Vector2.SignedAngle(baseFacing, Tracker.TargetPositionInScreenSpace - Tracker.TrackerPositionInScreenSpace);
            transform.rotation = Quaternion.Euler(0, 0, angle);
        }   
    }
}

