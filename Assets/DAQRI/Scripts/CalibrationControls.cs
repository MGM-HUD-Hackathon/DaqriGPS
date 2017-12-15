//  Copyright © 2017 DAQRI, LLC and its affiliates.  All Rights Reserved.


using UnityEngine;
using System.Collections;
using DAQRI;

/// <summary>
/// Shows how to access the thermal camera on a supported DAQRI smart device.
/// </summary>
public class CalibrationControls : MonoBehaviour {

    void Start () {
        DisplayManager.Instance.TurnVideoBackgroundOff ();
        DisplayManager.Instance.TurnThermalBackgroundOff ();
    }

    // Thermal vision is overlaid on the real world
    public void ThermalVisionToggled (bool isOn) {
        if (isOn) {
            DisplayManager.Instance.TurnThermalBackgroundOn ();
        } else {
            DisplayManager.Instance.TurnThermalBackgroundOff ();
        }
    }

    public void VideoVisionToggled(bool isOn)
    {
        if (isOn) {
            DisplayManager.Instance.TurnVideoBackgroundOn();
        } else {
            DisplayManager.Instance.TurnVideoBackgroundOff();
        }
    }
}
