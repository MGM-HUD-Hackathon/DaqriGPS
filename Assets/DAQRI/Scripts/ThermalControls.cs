//  Copyright © 2017 DAQRI, LLC and its affiliates.  All Rights Reserved.


using UnityEngine;
using System.Collections;
using DAQRI;

public class ThermalControls : MonoBehaviour {

    public GameObject thermalCameraPreview;

    // Thermal vision is overlaid on the real world
    public void ThermalVisionToggled (bool isOn) {
        if (isOn) {
            DisplayManager.Instance.TurnThermalBackgroundOn ();
        } else {
            DisplayManager.Instance.TurnThermalBackgroundOff ();
        }
    }

    // Thermal previews are used in user interfaces
    public void ThermalPreviewToggled (bool isOn) {
        if (isOn) {
            thermalCameraPreview.SetActive (true);
        } else {
            thermalCameraPreview.SetActive (false);
        }
    }
}
