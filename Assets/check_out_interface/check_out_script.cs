
using UnityEngine;
using UnityEngine.UI;

public class check_out_script : MonoBehaviour
{
 
    [SerializeField]
    private Text total_cost;
    [SerializeField]
    private Button tempAddTextbook;
    [SerializeField]
    private Button tempRemoveTextbook;
    [SerializeField]
    private CanvasGroup item_group_canvas;
    [SerializeField]
    private CanvasGroup item1_group;
    [SerializeField]
    private CanvasGroup item2_group;
    [SerializeField]
    private CanvasGroup item3_group;
    [SerializeField]
    private CanvasGroup item4_group;
    [SerializeField]
    private CanvasGroup item5_group;
    [SerializeField]
    private CanvasGroup item6_group;

    [SerializeField]
    private Text item1_Name;
    [SerializeField]
    private Text item2_Name;
    [SerializeField]
    private Text item3_Name;
    [SerializeField]
    private Text item4_Name;
    [SerializeField]
    private Text item5_Name;
    [SerializeField]
    private Text item6_Name;

    [SerializeField]
    private Text item1_Price;
    [SerializeField]
    private Text item2_Price;
    [SerializeField]
    private Text item3_Price;
    [SerializeField]
    private Text item4_Price;
    [SerializeField]
    private Text item5_Price;
    [SerializeField]
    private Text item6_Price;

    [SerializeField]
    private Text item1_Amount;
    [SerializeField]
    private Text item2_Amount;
    [SerializeField]
    private Text item3_Amount;
    [SerializeField]
    private Text item4_Amount;
    [SerializeField]
    private Text item5_Amount;
    [SerializeField]
    private Text item6_Amount;


    [SerializeField]
    private Button item1_addAmount;
    [SerializeField]
    private Button item1_removeAmount;


    private int itemsInCart = 0;
    private int totalCost = 0;
    private int numOfItems = 1;

    void Start()
    {
        item1_group.alpha = 0f;
        item1_group.interactable = false;
        item1_group.blocksRaycasts = false;
        item2_group.alpha = 0f;
        item2_group.interactable = false;
        item2_group.blocksRaycasts = false;
        item3_group.alpha = 0f;
        item3_group.interactable = false;
        item3_group.blocksRaycasts = false;
        item4_group.alpha = 0f;
        item4_group.interactable = false;
        item4_group.blocksRaycasts = false;
        item5_group.alpha = 0f;
        item5_group.interactable = false;
        item5_group.blocksRaycasts = false;
        item6_group.alpha = 0f;
        item6_group.interactable = false;
        item6_group.blocksRaycasts = false;
        //myDialogBalloon.gameObject.SetActive(false);               hide text

        Button btn1 = tempAddTextbook.GetComponent<Button>();
        //btn1.onClick.AddListener(addTextbook);

        Button btn2 = tempRemoveTextbook.GetComponent<Button>();
        //btn2.onClick.AddListener(removeTextbook);

        Button btn3 = item1_addAmount.GetComponent<Button>();
        Button btn4 = item1_removeAmount.GetComponent<Button>();
    }


    //add parameters for item passed in and also get item price
    public void addItem()
    {
        switch(itemsInCart)
        {
            case 0:
                Debug.Log("hello?");
                item1_Name.GetComponent<UnityEngine.UI.Text>().text = "textbook1";
                item1_Price.GetComponent<UnityEngine.UI.Text>().text = "$500";
                item1_Amount.GetComponent<UnityEngine.UI.Text>().text = numOfItems.ToString();
                item1_group.alpha = 1f;
                item1_group.interactable = true;
                item1_group.blocksRaycasts = true;
                itemsInCart++;
                totalCost += 500;       //add price of item
                break;
            case 1:
                item2_Name.GetComponent<UnityEngine.UI.Text>().text = "textbook2";
                item2_Price.GetComponent<UnityEngine.UI.Text>().text = "$500";
                item2_Amount.GetComponent<UnityEngine.UI.Text>().text = numOfItems.ToString();
                item2_group.alpha = 1f;
                item2_group.interactable = true;
                item2_group.blocksRaycasts = true;
                itemsInCart++;
                totalCost += 500;
                break;
            case 2:
                item3_Name.GetComponent<UnityEngine.UI.Text>().text = "textbook3";
                item3_Price.GetComponent<UnityEngine.UI.Text>().text = "$500";
                item3_Amount.GetComponent<UnityEngine.UI.Text>().text = numOfItems.ToString();
                item3_group.alpha = 1f;
                item3_group.interactable = true;
                item3_group.blocksRaycasts = true;
                itemsInCart++;
                totalCost += 500;
                break;
            case 3:
                item4_Name.GetComponent<UnityEngine.UI.Text>().text = "textbook4";
                item4_Price.GetComponent<UnityEngine.UI.Text>().text = "$500";
                item4_Amount.GetComponent<UnityEngine.UI.Text>().text = numOfItems.ToString();
                item4_group.alpha = 1f;
                item4_group.interactable = true;
                item4_group.blocksRaycasts = true;
                itemsInCart++;
                totalCost += 500;
                break;
            case 4:
                item5_Name.GetComponent<UnityEngine.UI.Text>().text = "textbook5";
                item5_Price.GetComponent<UnityEngine.UI.Text>().text = "$500";
                item5_Amount.GetComponent<UnityEngine.UI.Text>().text = numOfItems.ToString();
                item5_group.alpha = 1f;
                item5_group.interactable = true;
                item5_group.blocksRaycasts = true;
                itemsInCart++;
                totalCost += 500;
                break;
            case 5:
                item6_Name.GetComponent<UnityEngine.UI.Text>().text = "textbook6";
                item6_Price.GetComponent<UnityEngine.UI.Text>().text = "$500";
                item6_Amount.GetComponent<UnityEngine.UI.Text>().text = numOfItems.ToString();
                item6_group.alpha = 1f;
                item6_group.interactable = true;
                item6_group.blocksRaycasts = true;
                itemsInCart++;
                totalCost += 500;
                break;
            default:
                Debug.Log("h");
                break;
        }
        total_cost.GetComponent<UnityEngine.UI.Text>().text = totalCost.ToString();


    }

    public void removeItem()
    {
        if(itemsInCart > 0)
        {
            switch (itemsInCart)
            {
                case 1:
                    
                    item1_group.alpha = 0f;
                    item1_group.interactable = false;
                    item1_group.blocksRaycasts = false;
                    itemsInCart--;
                    totalCost -= 500;       //delete price of item
                    break;
                case 2:

                    item2_group.alpha = 0f;
                    item2_group.interactable = false;
                    item2_group.blocksRaycasts = false;
                    itemsInCart--;
                    totalCost -= 500;       //delete price of item
                    break;
                case 3:

                    item3_group.alpha = 0f;
                    item3_group.interactable = false;
                    item3_group.blocksRaycasts = false;
                    itemsInCart--;
                    totalCost -= 500;       //delete price of item
                    break;
                case 4:

                    item4_group.alpha = 0f;
                    item4_group.interactable = false;
                    item4_group.blocksRaycasts = false;
                    itemsInCart--;
                    totalCost -= 500;       //delete price of item
                    break;
                case 5:

                    item5_group.alpha = 0f;
                    item5_group.interactable = false;
                    item5_group.blocksRaycasts = false;
                    itemsInCart--;
                    totalCost -= 500;       //delete price of item
                    break;
                case 6:

                    item6_group.alpha = 0f;
                    item6_group.interactable = false;
                    item6_group.blocksRaycasts = false;
                    itemsInCart--;
                    totalCost -= 500;       //delete price of item
                    break;
                default:
                    Debug.Log("h");
                    break;
            }
            total_cost.GetComponent<UnityEngine.UI.Text>().text = totalCost.ToString();

        }

    }

    public void addAmountItem1()
    {
        Debug.Log("add amount");
        if (numOfItems >= 1)
        {
            numOfItems += 1;
            
            item1_Amount.GetComponent<UnityEngine.UI.Text>().text = numOfItems.ToString();
            totalCost += 500;
            total_cost.GetComponent<UnityEngine.UI.Text>().text = totalCost.ToString();
        }
    }

    public void removeAmount()
    {
        Debug.Log("remove amount");
        if (numOfItems > 1)
        {
            numOfItems -= 1;
            
            item1_Amount.GetComponent<UnityEngine.UI.Text>().text = numOfItems.ToString();
            totalCost -= 500;
            total_cost.GetComponent<UnityEngine.UI.Text>().text = totalCost.ToString();
        }
    }
}
