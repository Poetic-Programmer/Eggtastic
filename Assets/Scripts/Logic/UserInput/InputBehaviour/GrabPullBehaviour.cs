using UnityEngine;

public class GrabPullBehaviour {
    private bool grabbed;

    public GrabPullBehaviour()
    {
        grabbed = false;
    }

    public void Grab()
    {
        grabbed = true;
    }
    public void Pull()
    {

    }
    public void Release()
    {
        grabbed = false;
    }
    public bool IsGrabbed()
    {
        return grabbed;
    }
}
