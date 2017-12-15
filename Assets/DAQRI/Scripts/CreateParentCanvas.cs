//  Copyright © 2017 DAQRI, LLC and its affiliates.  All Rights Reserved.


using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace DAQRI {

    [ExecuteInEditMode]
    /// <summary>
    /// If no canvas is present as a parent component, this class automatically creates one.
    /// </summary>
    public class CreateParentCanvas : MonoBehaviour {

        private static Vector2 DEFAULT_CANVAS_SIZE = new Vector2 (1.28f, 0.72f);

        void Update () {
            Canvas canvas = GetComponentInParent<Canvas> ();

            if (canvas == null) {
                GameObject parent = new GameObject ();
                parent.name = "Canvas";

                canvas = parent.AddComponent<Canvas> ();
                canvas.gameObject.AddComponent<CanvasScaler> ();

                RectTransform rectTransform = canvas.GetComponent<RectTransform> ();
                rectTransform.sizeDelta = DEFAULT_CANVAS_SIZE;

                this.transform.parent = parent.transform;
            }
        }
    }
}
