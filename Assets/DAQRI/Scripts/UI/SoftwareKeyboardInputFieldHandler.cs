// Copyright © 2017 DAQRI, LLC and its affiliates.  All Rights Reserved.
using UnityEngine;
using UnityEngine.UI;
using DAQRI.UI;

/// <summary>
/// Allows the use of the DAQRI software keyboard with a Unity InputField.
/// Note the software keyboard is only available when running on a DAQRI Smart Device.
/// When running in the Unity editor, use your computer keyboard to enter text in the InputField. 
/// </summary>
[RequireComponent(typeof(InputField))]
public class SoftwareKeyboardInputFieldHandler : SoftwareKeyboardInputFieldHandlerAbstraction { }
