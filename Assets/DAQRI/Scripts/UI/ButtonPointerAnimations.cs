//  Copyright © 2017 DAQRI, LLC and its affiliates.  All Rights Reserved.


using UnityEngine;
using UnityEngine.EventSystems;

namespace DAQRI
{
    [RequireComponent(typeof(Animator))]
    public class ButtonPointerAnimations : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        private const string INITIAL_ENTRY_STATE_NAME = "Entry State";
        private const string ENTER_STATE_NAME = "Enter State";
        private const string EXIT_STATE_NAME = "Exit State";

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
            animator.Play(ENTER_STATE_NAME);
        }

        /// <summary>
        /// Triggers the pointer exit animation.
        /// </summary>
        /// <param name="eventData">Event data.</param>
        public void OnPointerExit(PointerEventData eventData)
        {
            Animator animator = GetComponent<Animator>();
            float normalizedTime = animator.GetCurrentAnimatorStateInfo(0).normalizedTime;

            animator.Play(EXIT_STATE_NAME, 0, 1f - Mathf.Min(normalizedTime, 1f));
        }
    }
}
