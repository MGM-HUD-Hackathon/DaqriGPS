//  Copyright © 2017 DAQRI, LLC and its affiliates.  All Rights Reserved.


using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using DAQRI;

public class AdditionalControls : MonoBehaviour
{
    public DepthControls depthControls;

    public Toggle colorHDToggle;

    private void Start()
    {
        if (colorHDToggle != null)
        {
            colorHDToggle.isOn = ServiceManager.Instance.GetColorCameraHDOnOff();
        }
    }

    public void CameraHDResolutionOnOff(bool isHD)
    {
        if (isHD)
        {
            // Turn depth off before we go HD
            depthControls.SetDepthFunctionalityEnabled(false);
        }

        DAQRI.ServiceManager.Instance.RegisterVideoTextureUser(this, isHD);

        if (!isHD)
        {
            // Make sure HD has been turned off before starting depth
            depthControls.SetDepthFunctionalityEnabled(true);
        }
    }

    public void DepthHistogramOnOff(bool isOn)
    {
        DAQRI.ServiceManager.Instance.SetDepthRenderType(
            isOn ? 
            DAQRI.Sensors.DeviceDepthRenderType.HISTOGRAM : 
            DAQRI.Sensors.DeviceDepthRenderType.RAW
        );
    }

    public void ColorCameraWhiteBalanceOnOff(bool isOn)
    {
        DAQRI.ServiceManager.Instance.SetWhiteBalanceOnOff(isOn);
    }

    public void ColorCameraAutoExposureOnOff(bool isOn)
    {
        DAQRI.ServiceManager.Instance.SetAutoExposureOnOff(isOn);
    }
}
