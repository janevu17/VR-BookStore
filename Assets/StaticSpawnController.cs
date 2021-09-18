using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * Updates ItemInspection UI
 * Displays Item name, price, and info
 * Attached to all purchasable items
 */
public class StaticSpawnController : MonoBehaviour
{
    private GameObject spawnUI;
    private InspectUIManager inspectScript;
    private GameObject inspect;

    public void SetInspectUI(GameObject inspect)
    {
        spawnUI = inspect;
        inspectScript = spawnUI.GetComponent<InspectUIManager>();
    }

    public void GrabbedObject()
    {
        inspectScript.GrabbedObject(gameObject);
        if (spawnUI.GetComponent<ObjectController>().getAmount() == 0)
        {
            Debug.Log("Item out of stock");
            return;
        }
        createObject();
    }
    public void createObject()
    {
        if (inspectScript.GrabbedInteraction() == true)
        {
            return;
        }
        GameObject newObject = Instantiate(spawnUI, spawnUI.transform.position, Quaternion.identity);
        newObject.GetComponent<ObjectController>().CreateItemObject(spawnUI.name, "abc123", "this is just a test.", 500.00f, 1);
        newObject.GetComponent<InspectController>().SetInspectUI(inspect);
        spawnUI.GetComponent<ObjectController>().updateAmount(spawnUI.GetComponent<ObjectController>().getAmount() - 1);
    }

}