//  Copyright © 2017 DAQRI, LLC and its affiliates.  All Rights Reserved.


using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using DAQRI;

public class DepthControls : MonoBehaviour
{
    public GameObject depthCameraPreview;
    public Toggle depthOverlayToggle;
    public Toggle depthPreviewToggle;
    public Toggle noOverlayToggle;

    // Depth vision is overlaid on the real world
    public void DepthOverlayToggled(bool isOn)
    {
        if (isOn)
        {
            DisplayManager.Instance.TurnDepthBackgroundOn();
        }
        else
        {
            DisplayManager.Instance.TurnDepthBackgroundOff();
        }
    }

    // Depth previews are used in user interfaces
    public void DepthPreviewToggled(bool isOn)
    {
        depthCameraPreview.SetActive(isOn);
    }

    public void SetDepthFunctionalityEnabled(bool enabled)
    {
        if (!enabled)
        {
            DepthOverlayToggled(false);
            DepthPreviewToggled(false);
        }

        if (!enabled && depthOverlayToggle.isOn)
        {
            noOverlayToggle.isOn = true;
        }

        depthOverlayToggle.interactable = enabled;

        depthPreviewToggle.isOn = enabled;
        depthPreviewToggle.interactable = enabled;
    }
}
