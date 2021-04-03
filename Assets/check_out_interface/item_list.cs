using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class item_list : MonoBehaviour
{

    [SerializeField]
    private GameObject item_row = null;
    private int numberOfItems = 0;  
    private float totalCost = 0;

    private items_script items_script;

    //public GameObject item_script_obj;
    
    private List<GameObject> shopping_cart_list;
    
    

    // Start is called before the first frame update
    void Start()
    {
       
        shopping_cart_list = new List<GameObject>();
        items_script = item_row.GetComponent<items_script>();


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void addItem(GameObject item)
    {
        //*****update later so that each product has an itemID*****
        //check another item of the same itemID is already in cart
        bool itemFound = false;
        for(int i = 0; i < shopping_cart_list.Count; i++)
        {
            //look for item in list
            if(shopping_cart_list[i] != null)
            {
                //is shopping_cart_list[i].GetComponent<ObjectController>().GetItemObject() == null?
                if(shopping_cart_list[i].GetComponent<ObjectController>().GetItemObject() == null)
                {
                    Debug.Log("it is equal to null");
                }
                //**this is the part where we need to check for unique item ID instead of name
                if (shopping_cart_list[i].GetComponent<ObjectController>().GetItemObject().GetName() == item.GetComponent<ObjectController>().GetItemObject().GetName())
                {
                    //if item found in list already, increment amount
                    shopping_cart_list[i].GetComponent<ObjectController>().GetItemObject().IncrementAmount(1);
                    
                    //totalCost = totalCost + shopping_cart_list[i].GetPrice();
                    updateTotalCost(shopping_cart_list[i].GetComponent<ObjectController>().GetItemObject().GetPrice());
                    //items_script.total_cost.text = totalCost.ToString();
                    //update amount 
                    items_script.itemAmount.text = shopping_cart_list[i].GetComponent<ObjectController>().GetItemObject().GetAmount().ToString();

                    itemFound = true;
                    Debug.Log("dup item: " + item.name);
                }
            }
            
            
            
        }
        
        if(itemFound == false)
        {
            //ItemObject temp = new ItemObject(item.name,"aaa1", "first item",  500.00f, 1);
            //get item object

            shopping_cart_list.Add(item);
            numberOfItems += 1;

            //create new item row if numOfInumberOfItemstems > 1
            if (numberOfItems > 1)
            {
                Debug.Log("cart items: " + shopping_cart_list.Count);
                Instantiate(item_row, transform);
            }


            for (int i = 0; i < shopping_cart_list.Count; i++)
            {
                Debug.Log("item in cart: " + shopping_cart_list[i].GetComponent<ObjectController>().GetItemObject().GetName());
            }

            if (item == null)
            {
                
            }
            
            if (item.GetComponent<ObjectController>().GetItemObject() == null)
            {
                Debug.Log("null item");
                
            }
            

            //set name
            items_script.itemName.text = item.GetComponent<ObjectController>().GetItemObject().GetName().ToString();
            //set price
            items_script.itemPrice.text = item.GetComponent<ObjectController>().GetItemObject().GetPrice().ToString();
            //set amount 
            items_script.itemAmount.text = item.GetComponent<ObjectController>().GetItemObject().GetAmount().ToString();
            Debug.Log("new item: " + item.GetComponent<ObjectController>().GetItemObject().GetName());

            
            
            //update total cost****
            
            updateTotalCost(item.GetComponent<ObjectController>().GetItemObject().GetPrice());
            //items_script.total_cost.text = totalCost.ToString();
            //Debug.Log("after updating subtotal: " + items_script.total_cost.text);
        }

       
        
    }

    //passed in item_row gameobject
    public void removeItem(GameObject passed_item_row)
    {
        Debug.Log("hello im in removeItem");
        float tempCost = 0;
        int tempAmount = 0;
        GameObject tempItem = null;
        //iterate through list to find item
        for (int i = 0; i <shopping_cart_list.Count; i++)
        {
            //get id and find in list and find in list****
            if (shopping_cart_list[i].GetComponent<ObjectController>().GetItemObject().GetName() == passed_item_row.GetComponent<ObjectController>().GetItemObject().GetName())
            {
                //store temp cost and amount 
                tempCost = shopping_cart_list[i].GetComponent<ObjectController>().GetItemObject().GetPrice();
                tempAmount = shopping_cart_list[i].GetComponent<ObjectController>().GetItemObject().GetAmount();
                tempItem = shopping_cart_list[i];



                //delete found item from list/shopping cart
                shopping_cart_list.RemoveAt(i);
            }

            //update total cost
            updateTotalCost(tempCost*tempCost);
            

        }
        //delete item row since item is deleted
        Destroy(passed_item_row);



    }

   

    //update total cost
    private void updateTotalCost(float price)
    {
        totalCost += price;
        
    }


}
