//  Copyright © 2017 DAQRI, LLC and its affiliates.  All Rights Reserved.


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace DAQRI.Internal {

    /// <summary>
    /// The int parameter indicates the row number of the clicked cell.
    /// </summary>
    public class CellClickEvent : UnityEvent<int> { }
}
