using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RawPCUserInput : RawUserInput {
    protected override Vector2 GetInputPosition()
    {
        var pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        return pos;
    }
    protected override bool GetInputPressed()
    {
        return Input.GetMouseButton(0);
    }
}
