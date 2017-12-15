//  Copyright © 2017 DAQRI, LLC and its affiliates.  All Rights Reserved.


using UnityEngine;
using System.Collections;
using System;

namespace DAQRI 
{
    /// <summary>
    /// The VIO initializer moves a game object in front of the camera when we get valid pose information,
    /// using pose from the VIN IMU.
    /// </summary>
    [Obsolete("VIOInitializer is obsolete, please use Initializer script",true)]
    public class VIOInitializer : MonoBehaviour 
    {
        public float defaultZOffsetValue = 0.5f;
        private Vector3 offset;

        // Use this for initialization
        void Start () {
            if (ServiceManager.Instance.IsRunningInEditor ()) {
                LateInitialization (); // We don't receive pose data in the editor, so set position immediately

            } else {
                ServiceManager.Instance.PositionalTrackingFound += LateInitialization;
            }
        }

        void Update () {
        }

        private void LateInitialization () 
        {
            //get the position 2.5 meters in front of where the user is looking
            offset = DisplayManager.Instance.transform.forward * defaultZOffsetValue;
            transform.position = ServiceManager.Instance.GetPosition () + offset;
            transform.RotateAround (transform.localPosition, Vector3.up, DisplayManager.Instance.transform.eulerAngles.y);
        }
    }

}
