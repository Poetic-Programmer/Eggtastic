using UnityEngine;

public class InputSpriteSelector {
    SpriteRenderer renderer;
    Sprite[] sprite;
    InputSpriteType spriteType;
	
    public InputSpriteSelector(SpriteRenderer renderer, Sprite[] sprite)
    {
        this.renderer = renderer;
        this.sprite = sprite;
        spriteType = InputSpriteType.IDLE;
    }
	
	public void FlipIdle()
    {
        spriteType = InputSpriteType.IDLE;
        UpdateSpriteRenderer();
    }

    public void FlipPressed()
    {
        spriteType = InputSpriteType.PRESSED;
        UpdateSpriteRenderer();
    }

    public void FlipColliding()
    {
        spriteType = InputSpriteType.PRESSED_COLLIDING;
        UpdateSpriteRenderer();
    }

    private void UpdateSpriteRenderer()
    {
        renderer.sprite = sprite[(int)spriteType];
    }
}
