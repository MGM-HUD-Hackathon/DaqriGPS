//  Copyright © 2017 DAQRI, LLC and its affiliates.  All Rights Reserved.


using UnityEngine;
using System.Collections;
using DAQRI;

/// <summary>
/// Attach this to any game object to enable video see-through on a supported DAQRI smart device.
/// </summary>
public class VideoSeeThrough : MonoBehaviour {
    
    void Start () {
        StartCoroutine (StartVideoSeeThrough());
    }

    private IEnumerator StartVideoSeeThrough()
    {
        yield return new WaitForSeconds(1.0f);
        DisplayManager.Instance.TurnVideoBackgroundOn ();
    }

    void Update()
    {
        /*if (Input.GetKeyDown (KeyCode.N)){

            StartCoroutine (StartVideoSeeThrough());

        }

        if (Input.GetKeyDown (KeyCode.M)){
            DisplayManager.Instance.TurnVideoBackgroundOff ();


        }*/

    }
}
