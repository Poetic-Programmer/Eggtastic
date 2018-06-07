using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudTracker : MonoBehaviour {
    public GameObject cloudPrefab;

    private const int MAX_CLOUDS_PER_ROW = 5;
    CloudSpriteSelector spriteSelector;
    private CloudCover cloudCover;
    private LowCloudTracker lowTracker;
	// Use this for initialization
	void Start () {
        spriteSelector = new CloudSpriteSelector(cloudPrefab);
        cloudCover = new CloudCover();
        lowTracker = new LowCloudTracker(cloudCover, GetLowClouds(spriteSelector));
	}
	
	// Update is called once per frame
	void Update () {
        lowTracker.Update(cloudCover, spriteSelector);
	}

    public GameObject[] GetLowClouds(CloudSpriteSelector selector)
    {
        GameObject[] cloud = new GameObject[16];
        for(int i = 0; i < 16; ++i)
        {
            cloud[i] = selector.SelectNew();
        }
        return cloud;
    }
}
