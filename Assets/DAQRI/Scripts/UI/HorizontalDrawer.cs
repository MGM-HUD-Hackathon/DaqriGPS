//  Copyright © 2017 DAQRI, LLC and its affiliates.  All Rights Reserved.


using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class HorizontalDrawer : MonoBehaviour,  IPointerEnterHandler, IPointerExitHandler
{
    /// <summary>
    /// Triggers the pointer enter animation.
    /// </summary>
    /// <param name="eventData">Event data.</param>
    public void OnPointerEnter(PointerEventData eventData)
    {
        Animator animator = GetComponent<Animator>();
        if (animator)
        {
            animator.SetBool("expand", true);
        }
    }

    /// <summary>
    /// Triggers the pointer exit animation.
    /// </summary>
    /// <param name="eventData">Event data.</param>
    public void OnPointerExit(PointerEventData eventData)
    {
        Animator animator = GetComponent<Animator>();
        if (animator)
        {
            animator.SetBool("expand", false);
        }
    }

}
