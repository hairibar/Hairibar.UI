namespace Hairibar.UI.Tracking
{
    /// <summary>
    /// Matches the local scale of the tracked object.
    /// </summary>
    public class MatchTrackedObjectScale : BaseUITrackerBehaviour
    {
        private void Update()
        {
            transform.localScale = Tracker.TrackedObject.transform.localScale;
        }
    }
}
