//  Copyright © 2017 DAQRI, LLC and its affiliates.  All Rights Reserved.


using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;


public class PointerHandlerTest : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler {
    
    public Material pointerEnteredMaterial;
    public Material pointerExitMaterial;
    public Material pointerClickMaterial;
    public MeshRenderer meshRenderer;


    public void OnPointerEnter(PointerEventData eventData) 
    {
        meshRenderer.material = pointerEnteredMaterial;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        meshRenderer.material = pointerExitMaterial;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        meshRenderer.material = pointerClickMaterial;
    }
}
