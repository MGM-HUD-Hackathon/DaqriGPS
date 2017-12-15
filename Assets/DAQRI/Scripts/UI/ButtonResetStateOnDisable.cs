using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DAQRI
{
    /// <summary>
    /// This ensures a button is presented in the contracted state when re-enabling.
    /// </summary>
    public class ButtonResetStateOnDisable : MonoBehaviour
    {
        [SerializeField]
        private GameObject expandable;

        void OnDisable()
        {
            if (expandable != null)
            {
                expandable.SetActive(false);
            }
        }
    }
}
