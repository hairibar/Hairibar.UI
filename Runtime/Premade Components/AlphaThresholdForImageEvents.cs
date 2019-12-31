using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Sets a minimum alpha for Pointer Events to apply to this Image. Requires read/write enabled on the sprite.
/// </summary>
[RequireComponent(typeof(Image))]
public class AlphaThresholdForImageEvents : MonoBehaviour
{
    [SerializeField, Range(0, 1)] private float alphaThreshold = 0.1f;

    private void Start()
    {
        Apply();
    }

    private void OnValidate()
    {
        Apply();
    }

    private void Apply()
    {
        GetComponent<Image>().alphaHitTestMinimumThreshold = alphaThreshold;
    }

}
