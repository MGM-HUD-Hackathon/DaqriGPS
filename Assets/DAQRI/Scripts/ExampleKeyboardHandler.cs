// Copyright © 2017 DAQRI, LLC and its affiliates.  All Rights Reserved.
using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;
using DAQRI;
using DAQRI.Events;
using UnityEngine.UI;

/// <summary>
/// Example script showing how to listen to the software keyboard events.
/// Note if you're working with Unity's InputField or Text,
/// please consider using SoftwareKeyboardInputFieldHandler or SoftwareKeyboardTextHandler.
/// </summary>
public class ExampleKeyboardHandler : KeyboardInputEventHandlerAbstractBehaviour, IPointerClickHandler
{
    public Text inputField;

    public void OnPointerClick(PointerEventData eventData)
    {
        ServiceManager.Instance.ShowKeyboard(inputField.text);
    }

    public override void OnKeyboardInputRecieved(string input)
    {
        Debug.Log("KEYBOARD INPUT RECIEVED: " + input);
        inputField.text = input;
    }

    public override void OnKeyboardInputCancelled(string input)
    {
        Debug.Log("KEYBOARD INPUT CANCELLED: " + input);
        inputField.text = "Cancelled";
    }

    public override void OnKeyboardShowing(string input)
    {
        Debug.Log("KEYBOARD SHOWING: " + input);
        inputField.text = "Type something Now";
    }
}
