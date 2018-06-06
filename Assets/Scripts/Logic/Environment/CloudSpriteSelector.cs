using UnityEngine;

public class CloudSpriteSelector : MonoBehaviour{
    public GameObject cloudPrefab;

    Sprite[] mysprite;

	void Start()
    {
        mysprite = Resources.LoadAll<Sprite>("clouds");
    }

    public void SelectNew()
    {
        var Clone = (Instantiate(cloudPrefab, transform.position, transform.rotation)) as GameObject;
        int i = Random.Range(0, mysprite.Length);
        Clone.GetComponent<SpriteRenderer>().sprite = mysprite[i];
    }
}
