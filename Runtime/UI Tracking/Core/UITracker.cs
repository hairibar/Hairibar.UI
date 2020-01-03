using UnityEngine;
using NaughtyAttributes;

namespace Hairibar.UI.Tracking
{
    [RequireComponent(typeof(CanvasGroup))]
    public class UITracker : MonoBehaviour
    {
        /// <summary>
        /// Instantiates a UITracker with and automatically sets it up.
        /// </summary>
        public static UITracker InstantiateTracker(UITracker source, UITracked trackedObject)
        {
            //Create a canvas
            GameObject canvasGO = new GameObject($"{trackedObject.gameObject.name}'s UI Tracking Canvas");
            canvasGO.layer = LayerMask.NameToLayer("UI");

            Canvas canvas = canvasGO.AddComponent<Canvas>();
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


        [ShowIf("get_ShouldShowCameraOnInspector")]
        public new Camera camera;

        private bool ShouldShowCameraOnInspector => !GetComponent<AssignMainCameraOnTracker>();

        public UITracked TrackedObject { get; private set; }

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


        private CanvasGroup canvasGroup;
        private float previousCanvasGroupAlpha;


        private void Awake()
        {
            canvasGroup = GetComponent<CanvasGroup>();
        }
    }

}