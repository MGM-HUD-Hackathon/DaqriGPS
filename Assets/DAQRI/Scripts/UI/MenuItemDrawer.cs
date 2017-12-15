//  Copyright © 2017 DAQRI, LLC and its affiliates.  All Rights Reserved.


using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Animator))]
public class MenuItemDrawer : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private const string INITIAL_ENTRY_STATE_NAME = "Initial State";
    private const string EXPANDED_STATE_NAME = "Expanded State";
    private const string REVERSE_CONTRACTED_STATE_NAME = "Reverse Contracted State";
    private const string QUICK_CONTRACTED_STATE_NAME = "Quick Contracted State";

    void OnEnable()
    {
        Animator animator = GetComponent<Animator>();
        animator.Play(INITIAL_ENTRY_STATE_NAME);
    }

    /// <summary>
    /// Triggers the pointer enter animation.
    /// </summary>
    /// <param name="eventData">Event data.</param>
    public void OnPointerEnter(PointerEventData eventData)
    {
        Animator animator = GetComponent<Animator>();
        animator.Play(EXPANDED_STATE_NAME);
    }

    /// <summary>
    /// Triggers the pointer exit animation.
    /// </summary>
    /// <param name="eventData">Event data.</param>
    public void OnPointerExit(PointerEventData eventData)
    {
        Animator animator = GetComponent<Animator>();
        float normalizedTime = animator.GetCurrentAnimatorStateInfo(0).normalizedTime;

        if (normalizedTime < 1f)
        {
            animator.Play(REVERSE_CONTRACTED_STATE_NAME, 0, normalizedTime);
        }
        else
        {
            animator.Play(QUICK_CONTRACTED_STATE_NAME);
        }
    }
}
