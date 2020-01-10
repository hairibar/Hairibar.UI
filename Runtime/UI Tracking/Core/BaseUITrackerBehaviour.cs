using UnityEngine;

namespace Hairibar.UI.Tracking
{
    /// <summary>
    /// The base behaviour that all UITrackerBehaviours must inherit from.
    /// </summary>
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

