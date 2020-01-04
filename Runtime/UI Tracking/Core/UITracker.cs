using UnityEngine;
using NaughtyAttributes;

namespace Hairibar.UI.Tracking
{
    /// <summary>
    /// Central class for UI tracking behaviours to connect to.
    /// Do not create via AddComponent<>. Use InstantiateTracker instead.
    /// </summary>
    [RequireComponent(typeof(CanvasGroup))]
    public class UITracker : MonoBehaviour
    {
        #region Instantiator
        /// <summary>
        /// Instantiates a UITracker with and automatically sets it up.
        /// </summary>
        /// <param name="source">The Tracker to instantiate (normally a prefab).</param>
        /// <param name="trackedObject">The object that this UITracker will track.</param>
        /// <param name="optionalCanvas">An optional canvas to be used. If no canvas is provided, a new one with default settings will be created for this tracker.</param>
        /// <returns></returns>
        public static UITracker InstantiateTracker(UITracker source, UITracked trackedObject, Canvas canvas = null)
        {
            if (!canvas)
            {
                //Create a canvas
                GameObject canvasGO = new GameObject($"{trackedObject.gameObject.name}'s UI Tracking Canvas");
                canvasGO.layer = LayerMask.NameToLayer("UI");

                canvas = canvasGO.AddComponent<Canvas>();
            }

            canvas.renderMode = RenderMode.ScreenSpaceOverlay;

            //TODO: Add a CanvasScaler. Where do we get the reference resolution from? Does it even matter?
            /*
            CanvasScaler canvasScaler = canvasGO.AddComponent<CanvasScaler>();
            canvasScaler.uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
            canvasScaler.screenMatchMode = CanvasScaler.ScreenMatchMode.MatchWidthOrHeight;
            canvasScaler.matchWidthOrHeight = 0.5f;
            canvasScaler.referenceResolution = canvasReferenceResolution;
            */

            UITracker newTracker = Instantiate(source, canvas.transform);
            newTracker.TrackedObject = trackedObject;

            return newTracker;
        }
        #endregion

        #region Inspector
        [ShowIf("get_ShouldShowCameraOnInspector")]
        public new Camera camera;
        private bool ShouldShowCameraOnInspector => !GetComponent<AssignMainCameraOnTracker>();
        #endregion

        #region Public Properties
        /// <summary>
        /// The UITracked object tracked by this UITracker.
        /// </summary>
        public UITracked TrackedObject { get; private set; }

        public Vector3 TargetPositionInWorldSpace => TrackedObject.transform.position;
        public Vector2 TargetPositionInScreenSpace => camera.WorldToScreenPoint(TargetPositionInWorldSpace);
        public Vector2 TargetPositionInViewportSpace => camera.WorldToViewportPoint(TargetPositionInWorldSpace);

        /// <summary>
        /// Used to set visibility of the tracker.
        /// </summary>
        public bool IsVisible
        {
            get => _isVisible;
            set
            {
                if (_isVisible && !value)
                {
                    previousCanvasGroupAlpha = canvasGroup.alpha;
                    canvasGroup.alpha = 0;
                    _isVisible = false;
                }
                else if (!_isVisible && value)
                {
                    canvasGroup.alpha = previousCanvasGroupAlpha;
                    _isVisible = true;
                }
            }
        }
        private bool _isVisible = true;
        #endregion



        private CanvasGroup canvasGroup;
        private float previousCanvasGroupAlpha;


        private void Awake()
        {
            canvasGroup = GetComponent<CanvasGroup>();
        }
    }
}