using UnityEngine;

public abstract class RawUserInput {
    private Vector2 position;
    private Vector2 velocity;

    // Update is called once per frame
    protected abstract Vector2 GetInputPosition();
    protected abstract bool GetInputPressed();

    public void CapturePositionVelocity()
    {
        var newPosition = GetInputPosition();

        velocity = (newPosition - position) / Time.deltaTime;

        position = newPosition;
    }

    public Vector2 GetPosition() { return position; }
    public Vector2 GetVelocity() { return velocity; }
    public bool IsPressed() { return GetInputPressed(); }
}