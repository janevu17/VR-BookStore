﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class Inventory
{
    public List<Itemtype> inventory;
}

[System.Serializable]
public class Itemtype
{
    public string type;
    public List<Item> item;
}

[System.Serializable]
public class Item
{
    public string ID;
    public string Name;
    public string Type;
    public float Weight;
    public string Size;
    public string Dimension;
    public string Info;
    public float Price;
    public int Amount;
    public int ToSpawn;
}

public class ItemManager : MonoBehaviour
{

    private bool CheckSurrounding(Vector3 center)
    {
        // Do check for collision with Grab (Grab layer is number 8)
        int layerMask = 1 << 8;
        //layerMask = ~layerMask;
        bool isOccupied = false;

        // Pass in any object that collides in a adjustable radius
        Collider[] hitColliders = Physics.OverlapSphere(center, 2, layerMask);

        // If any object in there, don't teleport
        foreach(Collider collider in hitColliders)
        {
            //Debug.Log("In foreach");
            if (collider.tag == "TestObj")
            {
                //Debug.Log("Hit object");
                isOccupied = true;
            }    
        }
        return isOccupied;
    }

    public TextAsset db;
    public GameObject itemprefab;
    bool notInstantiated;
    bool notSpawned;
    public Inventory inventory;
    public GameObject copyprefab;
    //private GameObject inspect;
    
    void Start()
    {
        notInstantiated = true;
        notSpawned = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (notInstantiated)
        {
            /*GameObject*/ copyprefab = Instantiate(itemprefab, transform);
            /*Inventory*/ inventory = JsonUtility.FromJson<Inventory>(db.text);
            // Spawning out of stock items
            foreach (Itemtype itemtype in inventory.inventory)
            {
                foreach (Item item in itemtype.item)
                {
                    if (item.ToSpawn == 0)
                    {
                        Debug.Log(item.ID + " " + item.Name + " " + item.Price + " " + item.Type + " " + item.Size);
                        var go = Instantiate(copyprefab, Vector3.zero, Quaternion.identity);
                        go.AddComponent<ObjectDetails>();
                        go.GetComponent<ObjectDetails>().ID = item.ID;
                        go.GetComponent<ObjectDetails>().Name = item.Name;
                        go.GetComponent<ObjectDetails>().Type = item.Type;
                        go.GetComponent<ObjectDetails>().Weight = item.Weight;
                        go.GetComponent<ObjectDetails>().Size = item.Size;
                        go.GetComponent<ObjectDetails>().Dimension = item.Dimension;
                        go.GetComponent<ObjectDetails>().Info = item.Info;
                        go.GetComponent<ObjectDetails>().Price = item.Price;
                        go.GetComponent<ObjectDetails>().Amount = item.Amount;
                        go.name = go.GetComponent<ObjectDetails>().Name;
                        //go.tag = "Item";
                        // set gravity = false;
                        //go.GetComponent<Rigidbody>().useGravity = false;

                        Vector3 temp;
                        switch (go.GetComponent<ObjectDetails>().Type)
                        {
                            case "Book":
                                temp = GameObject.Find("BookSpawningPoint").transform.position;
                                go.transform.position = temp;

                                break;
                            case "Clothing":
                                if (go.GetComponent<ObjectDetails>().Name == "ASU Beanie")
                                    temp = GameObject.Find("BeanieSpawningPoint").transform.position;
                                else
                                    temp = GameObject.Find("HoodieSpawningPoint").transform.position;
                                go.transform.position = temp;
                                break;
                            case "Office":
                                temp = GameObject.Find("OfficeSpawningPoint").transform.position;
                                go.transform.position = temp;
                                break;
                            case "Souvenir":
                                temp = GameObject.Find("CupSpawningPoint").transform.position;
                                go.transform.position = temp;
                                break;
                            default:
                                break;
                        }
                    }

                }
                //copyprefab.GetComponent<ObjectController>().CreateItemObject(item.GetName(), item.GetID(), item.GetInfo(), item.GetPrice(), 0, item.GetAmountInStock());
                //copyprefab.GetComponent<InspectController>().SetInspectUI(inspect);
            }
            notInstantiated = false;
        }


        // Spawning in stock items
        foreach (Itemtype itemtype in inventory.inventory)
        {
            Debug.Log(itemtype.type);
            foreach (Item item in itemtype.item)
            {
                if (item.ToSpawn > 0)
                {
                    Debug.Log(item.ID + " " + item.Name + " " + item.Price + " " + item.Type + " " + item.Size);
                    var go = Instantiate(copyprefab, Vector3.zero, Quaternion.identity);
                    go.AddComponent<ObjectDetails>();
                    go.GetComponent<ObjectDetails>().ID = item.ID;
                    go.GetComponent<ObjectDetails>().Name = item.Name;
                    go.GetComponent<ObjectDetails>().Type = item.Type;
                    go.GetComponent<ObjectDetails>().Weight = item.Weight;
                    go.GetComponent<ObjectDetails>().Size = item.Size;
                    go.GetComponent<ObjectDetails>().Dimension = item.Dimension;
                    go.GetComponent<ObjectDetails>().Info = item.Info;
                    go.GetComponent<ObjectDetails>().Price = item.Price;
                    go.GetComponent<ObjectDetails>().Amount = item.Amount;
                    go.name = go.GetComponent<ObjectDetails>().Name;
                    //go.tag = "Item";
                    // set gravity = false;
                    //go.GetComponent<Rigidbody>().useGravity = false;

                    Vector3 temp;
                    bool isOccupied;
                    switch (go.GetComponent<ObjectDetails>().Type)
                    {
                        case "Book":
                            temp = GameObject.Find("BookSpawningPoint").transform.position;
                            //Debug.Log(temp);
                            isOccupied = CheckSurrounding(temp);
                            //Debug.Log(isOccupied);
                            while (isOccupied)
                            {
                                temp.z = temp.z + 2;
                                //Debug.Log(temp);
                                isOccupied = CheckSurrounding(temp);
                            }
                            go.transform.position = temp;

                            break;
                        case "Clothing":
                            if (go.GetComponent<ObjectDetails>().Name == "ASU Beanie")
                                temp = GameObject.Find("BeanieSpawningPoint").transform.position;
                            else
                                temp = GameObject.Find("HoodieSpawningPoint").transform.position;
                            Debug.Log(temp);
                            isOccupied = CheckSurrounding(temp);
                            Debug.Log(isOccupied);
                            while (isOccupied)
                            {
                                temp.x = temp.x + 0.2f;
                                Debug.Log(temp);
                                isOccupied = CheckSurrounding(temp);
                            }
                            go.transform.position = temp;
                            break;
                        case "Office":
                            temp = GameObject.Find("OfficeSpawningPoint").transform.position;
                            //Debug.Log(temp);
                            isOccupied = CheckSurrounding(temp);
                            //Debug.Log(isOccupied);
                            while (isOccupied)
                            {
                                temp.z = temp.z + 2;
                                //Debug.Log(temp);
                                isOccupied = CheckSurrounding(temp);
                            }
                            go.transform.position = temp;
                            break;
                        case "Souvenir":
                            temp = GameObject.Find("CupSpawningPoint").transform.position;
                            while (CheckSurrounding(temp))
                            {
                                temp.z = temp.z + 2;
                            }
                            go.transform.position = temp;
                            break;
                        default:
                            break;
                    }
                    item.ToSpawn = item.ToSpawn - 1;
                }
                    
            }
            //copyprefab.GetComponent<ObjectController>().CreateItemObject(item.GetName(), item.GetID(), item.GetInfo(), item.GetPrice(), 0, item.GetAmountInStock());
            //copyprefab.GetComponent<InspectController>().SetInspectUI(inspect);
        }

        


    }
}