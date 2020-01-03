using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace Hairibar.UI.Tracking
{
    public class AssignMainCameraOnTracker : BaseUITrackerBehaviour
    {
        private void Start()
        {
            Camera mainCamera = Camera.main;
            Assert.IsNotNull(mainCamera, "There is no Main Camera to auto assign.");
            Tracker.camera = mainCamera;

            Destroy(this);
        }
    }

}
