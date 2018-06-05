using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudSpriteSelector {
    Sprite[] sprite;
    SpriteRenderer renderer;
    
	public CloudSpriteSelector(SpriteRenderer renderer, Sprite[] sprite)
    {
        this.renderer = renderer;
        this.sprite = sprite;

        int index = Random.Range(0, (int)sprite.Length-2);
        this.renderer.sprite = this.sprite[index];
    }

    public void SelectNew()
    {
        int index = Random.Range(0, (int)sprite.Length - 1);
        renderer.sprite = sprite[index];
    }
}
