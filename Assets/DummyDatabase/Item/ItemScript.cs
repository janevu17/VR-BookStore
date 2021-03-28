using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Assets/Item")]
public class Item : ScriptableObject
{
    // Item objects.
    public string itemID;
    public string itemName;
    [TextArea]
    public string itemDescription;
    public double itemCost;


    


}
