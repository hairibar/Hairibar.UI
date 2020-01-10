using UnityEngine;

namespace Hairibar.UI.Tracking
{
    /// <summary>
    /// Auto assigns the Main Camera to the UITracker on Start.
    /// </summary>
    [AddComponentMenu("UI/Tracking/Auto Assign Main Camera"), DisallowMultipleComponent]
    public class AssignMainCameraOnTracker : BaseUITrackerBehaviour
    {
        private void Start()
        {
            Camera mainCamera = Camera.main;
            Debug.Assert(mainCamera, "There is no Main Camera to auto assign.", this);
            Tracker.camera = mainCamera;

            Destroy(this);
        }
    }
}