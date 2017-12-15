//  Copyright © 2017 DAQRI, LLC and its affiliates.  All Rights Reserved.


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DAQRI 
{
    /// <summary>
    /// The VIO initializer places a game object at an offset in front of the camera when we get valid pose information,
    /// using pose from VIO.
    /// </summary>
    public class Initializer : MonoBehaviour 
    {
        public Vector3 offset = new Vector3(0.0f, 0.0f, 2.5f);
        private Vector3 finalPosition;

        // Use this for initialization
        void Start () {
            ServiceManager.Instance.PositionalTrackingFound += OnPostionalTrackingFound;
            ServiceManager.Instance.PositionalTrackingLost += OnPostionalTrackingLost;
        }

        void OnPostionalTrackingFound () 
        {
            //get the position 2.5 meters in front of where the user is looking
            finalPosition = DisplayManager.Instance.transform.forward * offset.z;
            finalPosition += DisplayManager.Instance.transform.right * offset.x + DisplayManager.Instance.transform.up * offset.y;
            transform.position = ServiceManager.Instance.GetPosition () + finalPosition;
            transform.RotateAround (transform.localPosition, Vector3.up, DisplayManager.Instance.transform.eulerAngles.y);
        }

        void OnPostionalTrackingLost()
        {
            //Implement the logic for when Positional Tracking is lost
        }
    }

}
