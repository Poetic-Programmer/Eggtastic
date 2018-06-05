using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RawAndroidUserInput : RawUserInput {
	protected override Vector2 GetInputPosition() {
        var pos = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
        return pos;
	}
    protected override bool GetInputPressed()
    {
        return Input.touchCount > 0;
    }
}
