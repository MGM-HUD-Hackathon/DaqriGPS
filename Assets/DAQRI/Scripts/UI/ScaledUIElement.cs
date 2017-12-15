//  Copyright © 2017 DAQRI, LLC and its affiliates.  All Rights Reserved.


using UnityEngine;

[ExecuteInEditMode]
/// <summary>
/// This script handles setting the transform scale for UI elements. 
/// For nested objects that each use this script, the scale is set on the highest level parent, 
/// and the rest use a scale of one.
/// </summary>
public class ScaledUIElement : MonoBehaviour
{

    private bool isFirstScaleSet = true;
    /// <summary>
    /// Pixel width in meters
    /// Calculated based on pixel density of the image used in the UI
    /// </summary>
    private float pixelMeters = 0.000942f;
    private Vector3 defaultScale = new Vector3(1, 1, 1);
    private Vector3 unscaledScale = new Vector3(1, 1, 1);

    private void Awake()
    {
        defaultScale = new Vector3(pixelMeters, pixelMeters, 1.0f);
    }

    void Update()
    {
        if (isFirstScaleSet)
        {
            ScaledUIElement[] scaledElements = GetComponentsInParent<ScaledUIElement>();

            if (scaledElements.Length > 1)
            {
                // Parent has a scaled element component which will handle the scaling
                SetScale(unscaledScale);
            }
            else
            {
                // This is the only scaled element component, so set scale here
                SetScale(defaultScale);
            }
        }
    }

    /// <summary>
    /// Sets the scale on a rect transform if applicable,
    /// sets the scale on the transform otherwise.
    /// </summary>
    /// <param name="scale">Scale to set.</param>
    private void SetScale(Vector3 scale)
    {
        RectTransform rectTransfrom = GetComponent<RectTransform>();
        isFirstScaleSet = false;

        if (rectTransfrom != null)
        {
            rectTransfrom.localScale = scale;
        }
        else
        {
            transform.localScale = scale;
        }
    }
}
