using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DatabaseTest : MonoBehaviour
{
    public GameObject itemPrefab;
    private List<string> names;

    // Start is called before the first frame update
    void Start()
    {
        names = new List<string>();
        names.Add("Hello");
        names.Add("World!");
        Test();   
    }

    //Test that Database can set up ItemPrefab
    private void Test()
    {
        GameObject copyPrefab = Instantiate(itemPrefab, transform);
        copyPrefab.GetComponent<ObjectController>().CreateItemObject(names[0], "abc123", "this is just a test.", 500.00f, 1);
        //copyPrefab.GetComponent<InspectController>().enabled = true;

        copyPrefab = Instantiate(itemPrefab, transform);
        copyPrefab.GetComponent<ObjectController>().CreateItemObject(names[1], "def456", "Has a sprinkle of innovation", 1.00f, 1);
        //copyPrefab.GetComponent<InspectController>().enabled = true;
    }
}
