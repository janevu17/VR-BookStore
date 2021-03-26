using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class item_list : MonoBehaviour
{

    [SerializeField]
    private GameObject item_row = null;
    private int numberOfItems = 0;  
    private float totalCost = 0;

    private items_script items_script;

    //public GameObject item_script_obj;
    
    private List<ItemObject> shopping_cart_list;
    private List<GameObject> 
    

    // Start is called before the first frame update
    void Start()
    {
       
        shopping_cart_list = new List<ItemObject>();
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
            if(shopping_cart_list[i] != null)
            {
                //**this is the part where we need to check for unique item ID instead of name
                if (shopping_cart_list[i].GetName() == item.name)
                {
                    shopping_cart_list[i].IncrementAmount(1);
                    itemFound = true;
                    //totalCost = totalCost + shopping_cart_list[i].GetPrice();
                    updateTotalCost(shopping_cart_list[i].GetPrice());
                    //update amount 
                    items_script.itemAmount.text = shopping_cart_list[i].GetAmount().ToString();

                    Debug.Log("dup item: " + item.name);
                }
            }
            
            
            
        }
        if(itemFound == false)
        {
            //ItemObject temp = new ItemObject(item.name,"aaa1", "first item",  500.00f, 1);
            //get item object
            ItemObject temp = item.GetComponent<ObjectController>().GetItemObject();
            shopping_cart_list.Add(temp);
            numberOfItems += 1;

            //set name
            items_script.itemName.text = temp.GetName();
            //set price
            items_script.itemPrice.text = temp.GetPrice().ToString();
            //set amount 
            items_script.itemAmount.text = temp.GetAmount().ToString();
            Debug.Log("new item: " + temp.GetName());

            //create new item row
            Instantiate(item_row, transform);

            //update total cost****
            updateTotalCost(temp.GetPrice());
        }

        
        
    }

    public void removeItem()
    {
        //iterate through list to find item
        for(int i = 0; i <shopping_cart_list.Count; i++)
        {
            //remove all items
            if(shopping_cart_list[i].GetName() == item.name)
            {
                
                 int amountToDelete = shopping_cart_list[i].GetAmount();
                 updateTotalCost(-amountToDelete);
                
                numberOfItems -= 1;
                shopping_cart_list.RemoveAt(i);

                Destroy(item_row);
            }
        }

        

    }

    //add amount function
    public void addAmount()
    {
        updateTotalCost()
    }
    

    //remove amount function
    public void removeAmount()
    {

    }

    //update total cost
    private void updateTotalCost(float price)
    {
        totalCost += price;
    }


}
