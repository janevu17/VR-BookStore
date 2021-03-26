using UnityEngine;

/*
 * Manages ItemObject properties
 * Allows Checkout and ItemInspection scripts to easily retrieve an item's properties/details
 */
[System.Serializable]
public class ItemObject
{
    /*
     * Add ID to constructor
     * Add getter and setter for ID
     */
    //ItemObject properties
    private string name;
    private string ID; //unique item ID
    private string info; //item description
    private float price;
    private int amount; //quantity in cart

    //ItemObject constructor
    public ItemObject(string itemName, string itemID, string itemInfo, float itemPrice, int itemAmount)
    {
        name = itemName;
        ID = itemID;
        info = itemInfo;
        price = itemPrice;
        amount = itemAmount;
    }

    //Setters for each ItemObject property
    public void SetName(string itemName)
    {
        name = itemName;
    }
    public void SetID(string itemID)
    {
        ID = itemID;
    }
    public void SetInfo(string itemInfo)
    {
        info = itemInfo;
    }
    public void SetPrice(float itemPrice)
    {
        price = itemPrice;
    }
    public void SetAmount(int itemAmount)
    {
        amount = itemAmount;
    }

    //Getters for each ItemObject property
    public string GetName()
    {
        return name;
    }
    public string GetID()
    {
        return ID;
    }
    public string GetInfo()
    {
        return info;
    }
    public float GetPrice()
    {
        return price;
    }
    public int GetAmount()
    {
        return amount;
    }
    public void IncrementAmount(int increment)
    {
        amount += increment;
    }
    public void DecrementAmount(int decrement)
    {
        amount += decrement;
    }
}
