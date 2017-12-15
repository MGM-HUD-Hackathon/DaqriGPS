using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace DAQRI
{
    [RequireComponent(typeof(Animator))]
    public class DropdownAnimations : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        private const string HIDE_STATE_NAME = "Hidden";
        private const string VISIBLE_STATE_NAME = "Visible";

        public void OnPointerEnter(PointerEventData eventData)
        {
            Animator animator = GetComponent<Animator>();
            AnimatorStateInfo currentState = animator.GetCurrentAnimatorStateInfo(0);

            if (currentState.IsName(HIDE_STATE_NAME))
            {
                animator.Play(VISIBLE_STATE_NAME, 0, 1f - (currentState.normalizedTime % 1));
            }
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            Animator animator = GetComponent<Animator>();
            animator.Play(HIDE_STATE_NAME);
        }

        /// <summary>
        /// This is called by an animation event when the dropdown fully hides.
        /// </summary>
        private void OnHideAnimationComplete()
        {
            gameObject.SetActive(false);
        }
    }
}
