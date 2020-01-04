using UnityEngine;
using UnityEngine.Assertions;
using NaughtyAttributes;

#pragma warning disable 649
namespace Hairibar.UI.Tracking
{
    public class UITracked : MonoBehaviour
    {
        [SerializeField, Required] private UITracker uiTrackerPrefab;

        public UITracker Tracker { get; private set; }

        private void Awake()
        {
            Assert.IsNotNull(uiTrackerPrefab, "UITracked must have a uiTrackerPrefab to instantiate.");
            Tracker = UITracker.InstantiateTracker(uiTrackerPrefab, this);
        }

        private void OnDestroy()
        {
            Destroy(Tracker.gameObject);
        }
    }
}