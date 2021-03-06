﻿using UnityEngine;
using NaughtyAttributes;

namespace Hairibar.UI.Tracking
{
    /// <summary>
    /// Central class for UI tracking behaviours to connect to.
    /// Do not create at runtime via AddComponent<>. Use InstantiateTracker instead.
    /// </summary>
    [RequireComponent(typeof(CanvasGroup)), DisallowMultipleComponent]
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
        public static UITracker InstantiateTracker(UITracker source, GameObject trackedObject, Canvas canvas = null)
        {
            bool mustCleanupCanvas = false;
            if (!canvas)
            {
                //Create a canvas
                GameObject canvasGO = new GameObject($"{trackedObject.name}'s UI Tracking Canvas");
                canvasGO.layer = LayerMask.NameToLayer("UI");

                canvas = canvasGO.AddComponent<Canvas>();
                mustCleanupCanvas = true;
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
            newTracker.mustCleanupCanvasOnDestroy = mustCleanupCanvas;

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
        /// The GameObject tracked by this UITracker.
        /// </summary>
        public GameObject TrackedObject { get; private set; }

        public Vector3 TargetPositionInWorldSpace => TrackedObject.transform.position;
        public Vector2 TargetPositionInScreenSpace => camera.WorldToScreenPoint(TargetPositionInWorldSpace);
        public Vector2 TargetPositionInViewportSpace => camera.WorldToViewportPoint(TargetPositionInWorldSpace);

        public Vector2 TrackerPositionInScreenSpace => RectTransformUtility.WorldToScreenPoint(null, transform.position);
        public Vector2 TrackerpositionInViewportSpace => camera.ScreenToViewportPoint(TrackerPositionInScreenSpace);

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

        #region Private State
        private CanvasGroup canvasGroup;
        private float previousCanvasGroupAlpha;

        private bool mustCleanupCanvasOnDestroy;
        #endregion


        private void Awake()
        {
            canvasGroup = GetComponent<CanvasGroup>();
        }

        private void OnDestroy()
        {
            if (mustCleanupCanvasOnDestroy) Destroy(transform.parent.gameObject);
        }
    }
}