//  Copyright © 2017 DAQRI, LLC and its affiliates.  All Rights Reserved.


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DAQRI;

public class ExampleScrollViewController : ScrollViewController {

    public override int NumberOfRows () {
        return int.MaxValue;
    }

    public override string TextForRow (int row) {
        return string.Format ("Row {0}", row.ToString ());
    }

    public override void DidSelectRow (int row) {
        Debug.LogFormat ("Selected row {0}!", row.ToString ());
    }
}
