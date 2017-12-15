// Copyright © 2017 DAQRI, LLC and its affiliates.  All Rights Reserved.
using UnityEngine;
using UnityEngine.UI;
using DAQRI.UI;

/// <summary>
/// Allows the use of the DAQRI software keyboard with a Unity Text component.
/// If you're using an InputField, please use SoftwareKeyboardInputFieldHandler instead.
/// Note the software keyboard is only available when running on a DAQRI Smart Device.
/// </summary>
[RequireComponent(typeof(Text))]
public class SoftwareKeyboardTextHandler : SoftwareKeyboardTextHandlerAbstraction { }
