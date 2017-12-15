//  Copyright © 2017 DAQRI, LLC and its affiliates.  All Rights Reserved.


using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;
using DAQRI;

public class ReticleLogger : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log ("Reticle Entered: " + name);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log ("Reticle Exited: " + name);
    }
}
