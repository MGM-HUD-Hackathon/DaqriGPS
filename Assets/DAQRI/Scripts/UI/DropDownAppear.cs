//  Copyright © 2017 DAQRI, LLC and its affiliates.  All Rights Reserved.


using UnityEngine;
using UnityEngine.EventSystems;

public class DropDownAppear : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    MenuItemDrawer[] menuItems;

    void Start()
    {
        menuItems = GetComponentsInChildren<MenuItemDrawer>();
    }

    /// <summary>
    /// Triggers the pointer enter animation.
    /// </summary>
    /// <param name="eventData">Event data.</param>
    public void OnPointerEnter(PointerEventData eventData)
    {
        foreach (MenuItemDrawer item in menuItems)
        {
            Animator animator = item.GetComponent<Animator>();
            if (animator)
            {
                animator.SetBool("entered", true);
            }
        }

    }

    /// <summary>
    /// Triggers the pointer exit animation.
    /// </summary>
    /// <param name="eventData">Event data.</param>
    public void OnPointerExit(PointerEventData eventData)
    {
        foreach (MenuItemDrawer item in menuItems)
        {
            Animator animator = item.GetComponent<Animator>();
            if (animator)
            {
                animator.SetBool("entered", false);
            }
        }
    }

}
