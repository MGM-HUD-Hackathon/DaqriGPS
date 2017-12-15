//  Copyright © 2017 DAQRI, LLC and its affiliates.  All Rights Reserved.


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using DAQRI;
using DAQRI.Input;

public class ExampleDwellProgress : MonoBehaviour, IPointerDwellHandler, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler {

    private const float HELMET_GREY = 120 / 255.0F; // Approximate red green and blue value for the helmet gray

    public MeshRenderer meshRenderer;

    private Material dwellMaterial;
    private Material normalMaterial;
    private Color daqriColor = new Color (23 / 255.0F, 23 / 255.0F, 150 / 255.0F);


    void Start () {
        normalMaterial = meshRenderer.material;
        dwellMaterial = new Material (Shader.Find("Standard"));
    }

    void IPointerDwellHandler.OnPointerDwellProgress (float fractionCompleted) {
        Color dwellColor = daqriColor;
        dwellColor.r = ((HELMET_GREY - daqriColor.r) * (1 - fractionCompleted) + daqriColor.r);
        dwellColor.g = ((HELMET_GREY - daqriColor.g) * (1 - fractionCompleted) + daqriColor.g);
        dwellColor.b = ((daqriColor.b - HELMET_GREY) * fractionCompleted + HELMET_GREY);

        dwellMaterial.color = dwellColor;
        meshRenderer.material = dwellMaterial;
    }

    void IPointerEnterHandler.OnPointerEnter (PointerEventData eventData) {
        // noop
    }

    void IPointerExitHandler.OnPointerExit (PointerEventData eventData) {
        meshRenderer.material = normalMaterial;
    }

    void IPointerClickHandler.OnPointerClick (PointerEventData eventData) {
        meshRenderer.material.color = daqriColor;
    }
}
