//  Copyright © 2017 DAQRI, LLC and its affiliates.  All Rights Reserved.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DAQRI;

/// <summary>
/// Used in the sensor access example scene, this component turns off the thermal UI
/// if the DAQRI device does not have a thermal camera.
/// </summary>
public class NoThermalHardwareHandler : MonoBehaviour
{
    [SerializeField]
    private Toggle thermalOverlayToggle;

    [SerializeField]
    private Toggle thermalPreviewToggle;

    void Start()
    {
        if (!ServiceManager.Instance.GetThermalCameraHardwareAvailable())
        {
            Debug.Log("No thermal hardware on this DAQRI Smart Device. Disabling thermal functionality.");

            if (thermalOverlayToggle != null)
            {
                thermalOverlayToggle.isOn = false;
                thermalOverlayToggle.interactable = false;
            }

            if (thermalPreviewToggle != null)
            {
                thermalPreviewToggle.isOn = false;
                thermalPreviewToggle.interactable = false;
            }
        }
    }
}
