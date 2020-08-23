using UnityEngine;
using UnityEngine.UI;
using NaughtyAttributes;

#pragma warning disable 649
namespace Hairibar.UI.Tracking
{
    /// <summary>
    /// Creates a UITracker assigned to this object.
    /// </summary>
    [AddComponentMenu("UI/UI Tracked")]
    public class UITracked : MonoBehaviour
    {
        [SerializeField, Required] private UITracker uiTrackerPrefab;

        public UITracker Tracker { get; private set; }

        protected virtual Canvas GetCanvas()
        {
            return null;
        }

        void Start()
        {
            Debug.Assert(uiTrackerPrefab, "UITracked must have a uiTrackerPrefab to instantiate.", this);
            Tracker = UITracker.InstantiateTracker(uiTrackerPrefab, gameObject, GetCanvas());
        }

        void OnDestroy()
        {
            if (Tracker)
            {
                Destroy(Tracker.gameObject);
            }
        }
    }
}