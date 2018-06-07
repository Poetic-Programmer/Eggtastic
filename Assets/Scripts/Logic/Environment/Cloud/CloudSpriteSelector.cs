using UnityEngine;

public class CloudSpriteSelector{
    GameObject cloudPrefab;

    Sprite[] mysprite;

	public CloudSpriteSelector(GameObject cloudPrefab)
    {
        this.cloudPrefab = cloudPrefab;
        mysprite = Resources.LoadAll<Sprite>("clouds");
    }

    public GameObject SelectNew()
    {
        var Clone = (Object.Instantiate(cloudPrefab)) as GameObject;
        int i = Random.Range(0, mysprite.Length);
        Clone.GetComponent<SpriteRenderer>().sprite = mysprite[i];
        return Clone;
    }

    public Sprite GetRandom()
    {
        int i = Random.Range(0, mysprite.Length);
        return mysprite[i];
    }
}