using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LowCloudTracker {
    GameObject[] cloudPrefab;

    private const float minY = 0;
    private const float maxY = 2;

    private const int maxClouds = 4;
    private Vector2 heightRange;

	// Use this for initialization
	public LowCloudTracker (CloudCover cover, GameObject[] cloudPrefab) {
        this.cloudPrefab = cloudPrefab;
        heightRange = new Vector2(cover.GetMinY(), cover.GetMaxY());
        
        for(int i = 0; i < cloudPrefab.Length; ++i)
        {
            var startPos = GetRandomStartPosition(cover);
            Debug.Log(startPos);
            cloudPrefab[i].transform.position = GetRandomStartPosition(cover);
        }
	}
	
	public void Update(CloudCover cover, CloudSpriteSelector spriteSelector)
    {
        //is cloud out of screen range?
        int offset = 0;
        foreach(GameObject cloud in cloudPrefab)
        {
            if (cloud.transform.position.x < cover.GetMinX())
            {
                cloud.gameObject.GetComponent<SpriteRenderer>().sprite = spriteSelector.GetRandom();
                var newPos = new Vector3(
                    cover.GetMaxX(), Random.Range(heightRange.x, heightRange.y), 0);
                cloud.transform.position = newPos;
            }
            if (cloud.transform.position.x > cover.GetMaxX())
            {
                cloud.gameObject.GetComponent<SpriteRenderer>().sprite = spriteSelector.GetRandom();
                var newPos = new Vector3(
                    cover.GetMinX(), Random.Range(heightRange.x, heightRange.y), 0);
                cloud.transform.position = newPos;
            }
            offset++;
        }
    }

    private Vector3 GetRandomStartPosition(CloudCover cover)
    {
        var pos = new Vector3(
            Random.Range(cover.GetMinX(), cover.GetMaxX()),
            Random.Range(heightRange.x, heightRange.y), 0);
        return pos;
    }
}
