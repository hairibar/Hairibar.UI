using UnityEngine;

namespace Hairibar.UI.Tracking
{
    [RequireComponent(typeof(UITracker))]
    public abstract class BaseUITrackerBehaviour : MonoBehaviour
    {
        public UITracker Tracker { get; private set; }

        private void Awake()
        {
            Tracker = GetComponent<UITracker>();
        }
    }
}

