//  Copyright © 2017 DAQRI, LLC and its affiliates.  All Rights Reserved.


using UnityEngine;
using UnityEditor;

namespace DAQRI {

    [InitializeOnLoad]
    internal class UnityVersionValidator {

        static UnityVersionValidator () {

            #if !UNITY_5_5_OR_NEWER
            /*EditorUtility.DisplayDialog (
                "The Vos Extension for Unity requires Unity 5.5 or newer.", 
                string.Format ("You're using Unity {0}. Please download a supported version.", Application.unityVersion), 
                "OK"
            );*/

            Debug.LogWarning ("The Vos Extension for Unity requires Unity 5.5 or newer");
            #endif
        }
    }
}
