//  Copyright © 2017 DAQRI, LLC and its affiliates.  All Rights Reserved.


using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ScrollPanelDrawer : MonoBehaviour, IPointerClickHandler
{

    public Sprite minusIcon;
    public Sprite plusIcon;
    public Animator scrollPanel;
    private bool isMinimized;

    /// <summary>
    /// Switches the open/collapsed state.
    /// </summary>
    /// <param name="eventData">Event data.</param>
    public void OnPointerClick(PointerEventData eventData)
    {
        if (scrollPanel)
        {
            scrollPanel.SetBool("minimize", isMinimized);
            isMinimized = !isMinimized;
        }

        if (isMinimized)
        {
            Image image = GetComponent<Image>();
            image.sprite = minusIcon;
        }
        else
        {
            Image image = GetComponent<Image>();
            image.sprite = plusIcon;
        }
    }

}
