
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
    [SerializeField]
    private Button item2_addAmount;
    [SerializeField]
    private Button item2_removeAmount;
    [SerializeField]
    private Button item3_addAmount;
    [SerializeField]
    private Button item3_removeAmount;
    [SerializeField]
    private Button item4_addAmount;
    [SerializeField]
    private Button item4_removeAmount;
    [SerializeField]
    private Button item5_addAmount;
    [SerializeField]
    private Button item5_removeAmount;
    [SerializeField]
    private Button item6_addAmount;
    [SerializeField]
    private Button item6_removeAmount;


    private int itemsInCart = 0;
    private int totalCost = 0;
    private int numOfItems1 = 1;
    private int numOfItems2 = 1;
    private int numOfItems3 = 1;
    private int numOfItems4 = 1;
    private int numOfItems5 = 1;
    private int numOfItems6 = 1;

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
        

        Button btn13 = item2_addAmount.GetComponent<Button>();
        Button btn14 = item2_removeAmount.GetComponent<Button>();

        Button btn5 = item3_addAmount.GetComponent<Button>();
        Button btn6 = item3_removeAmount.GetComponent<Button>();

        Button btn7 = item4_addAmount.GetComponent<Button>();
        Button btn8 = item4_removeAmount.GetComponent<Button>();

        Button btn9 = item5_addAmount.GetComponent<Button>();
        Button btn10 = item5_removeAmount.GetComponent<Button>();

        Button btn11 = item6_addAmount.GetComponent<Button>();
        Button btn12 = item6_removeAmount.GetComponent<Button>();
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
                item1_Amount.GetComponent<UnityEngine.UI.Text>().text = numOfItems1.ToString();
                item1_group.alpha = 1f;
                item1_group.interactable = true;
                item1_group.blocksRaycasts = true;
                itemsInCart++;
                totalCost += 500;       //add price of item
                break;
            case 1:
                item2_Name.GetComponent<UnityEngine.UI.Text>().text = "textbook2";
                item2_Price.GetComponent<UnityEngine.UI.Text>().text = "$500";
                item2_Amount.GetComponent<UnityEngine.UI.Text>().text = numOfItems2.ToString();
                item2_group.alpha = 1f;
                item2_group.interactable = true;
                item2_group.blocksRaycasts = true;
                itemsInCart++;
                totalCost += 500;
                break;
            case 2:
                item3_Name.GetComponent<UnityEngine.UI.Text>().text = "textbook3";
                item3_Price.GetComponent<UnityEngine.UI.Text>().text = "$500";
                item3_Amount.GetComponent<UnityEngine.UI.Text>().text = numOfItems3.ToString();
                item3_group.alpha = 1f;
                item3_group.interactable = true;
                item3_group.blocksRaycasts = true;
                itemsInCart++;
                totalCost += 500;
                break;
            case 3:
                item4_Name.GetComponent<UnityEngine.UI.Text>().text = "textbook4";
                item4_Price.GetComponent<UnityEngine.UI.Text>().text = "$500";
                item4_Amount.GetComponent<UnityEngine.UI.Text>().text = numOfItems4.ToString();
                item4_group.alpha = 1f;
                item4_group.interactable = true;
                item4_group.blocksRaycasts = true;
                itemsInCart++;
                totalCost += 500;
                break;
            case 4:
                item5_Name.GetComponent<UnityEngine.UI.Text>().text = "textbook5";
                item5_Price.GetComponent<UnityEngine.UI.Text>().text = "$500";
                item5_Amount.GetComponent<UnityEngine.UI.Text>().text = numOfItems5.ToString();
                item5_group.alpha = 1f;
                item5_group.interactable = true;
                item5_group.blocksRaycasts = true;
                itemsInCart++;
                totalCost += 500;
                break;
            case 5:
                item6_Name.GetComponent<UnityEngine.UI.Text>().text = "textbook6";
                item6_Price.GetComponent<UnityEngine.UI.Text>().text = "$500";
                item6_Amount.GetComponent<UnityEngine.UI.Text>().text = numOfItems6.ToString();
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

    public void addAmount1()
    {
        Debug.Log("add amount");
        if (numOfItems1 >= 1)
        {
            numOfItems1 += 1;
            
            item1_Amount.GetComponent<UnityEngine.UI.Text>().text = numOfItems1.ToString();
            totalCost += 500;
            total_cost.GetComponent<UnityEngine.UI.Text>().text = totalCost.ToString();
        }
    }

    public void removeAmount1()
    {
        Debug.Log("remove amount");
        if (numOfItems1 > 1)
        {
            numOfItems1 -= 1;
            
            item1_Amount.GetComponent<UnityEngine.UI.Text>().text = numOfItems1.ToString();
            totalCost -= 500;
            total_cost.GetComponent<UnityEngine.UI.Text>().text = totalCost.ToString();
        }
    }

    public void addAmount2()
    {
        Debug.Log("add amount");
        if (numOfItems2 >= 1)
        {
            numOfItems2 += 1;

            item2_Amount.GetComponent<UnityEngine.UI.Text>().text = numOfItems2.ToString();
            totalCost += 500;
            total_cost.GetComponent<UnityEngine.UI.Text>().text = totalCost.ToString();
        }
    }

    public void removeAmount2()
    {
        Debug.Log("remove amount");
        if (numOfItems2 > 1)
        {
            numOfItems2 -= 1;

            item2_Amount.GetComponent<UnityEngine.UI.Text>().text = numOfItems2.ToString();
            totalCost -= 500;
            total_cost.GetComponent<UnityEngine.UI.Text>().text = totalCost.ToString();
        }
    }

    
    public void addAmount3()
    {
        Debug.Log("add amount");
        if (numOfItems3 >= 1)
        {
            numOfItems3 += 1;

            item3_Amount.GetComponent<UnityEngine.UI.Text>().text = numOfItems3.ToString();
            totalCost += 500;
            total_cost.GetComponent<UnityEngine.UI.Text>().text = totalCost.ToString();
        }
    }

    public void removeAmount3()
    {
        Debug.Log("remove amount");
        if (numOfItems3 > 1)
        {
            numOfItems3 -= 1;

            item3_Amount.GetComponent<UnityEngine.UI.Text>().text = numOfItems3.ToString();
            totalCost -= 500;
            total_cost.GetComponent<UnityEngine.UI.Text>().text = totalCost.ToString();
        }
    }

    public void addAmount4()
    {
        Debug.Log("add amount");
        if (numOfItems4 >= 1)
        {
            numOfItems4 += 1;

            item4_Amount.GetComponent<UnityEngine.UI.Text>().text = numOfItems4.ToString();
            totalCost += 500;
            total_cost.GetComponent<UnityEngine.UI.Text>().text = totalCost.ToString();
        }
    }

    public void removeAmount4()
    {
        Debug.Log("remove amount");
        if (numOfItems4 > 1)
        {
            numOfItems4 -= 1;

            item4_Amount.GetComponent<UnityEngine.UI.Text>().text = numOfItems4.ToString();
            totalCost -= 500;
            total_cost.GetComponent<UnityEngine.UI.Text>().text = totalCost.ToString();
        }
    }

    public void addAmount5()
    {
        Debug.Log("add amount");
        if (numOfItems5 >= 1)
        {
            numOfItems5 += 1;

            item5_Amount.GetComponent<UnityEngine.UI.Text>().text = numOfItems5.ToString();
            totalCost += 500;
            total_cost.GetComponent<UnityEngine.UI.Text>().text = totalCost.ToString();
        }
    }

    public void removeAmount5()
    {
        Debug.Log("remove amount");
        if (numOfItems5 > 1)
        {
            numOfItems5 -= 1;

            item5_Amount.GetComponent<UnityEngine.UI.Text>().text = numOfItems5.ToString();
            totalCost -= 500;
            total_cost.GetComponent<UnityEngine.UI.Text>().text = totalCost.ToString();
        }
    }

    public void addAmount6()
    {
        Debug.Log("add amount");
        if (numOfItems6 >= 1)
        {
            numOfItems6 += 1;

            item6_Amount.GetComponent<UnityEngine.UI.Text>().text = numOfItems6.ToString();
            totalCost += 500;
            total_cost.GetComponent<UnityEngine.UI.Text>().text = totalCost.ToString();
        }
    }

    public void removeAmount6()
    {
        Debug.Log("remove amount");
        if (numOfItems6 > 1)
        {
            numOfItems6 -= 1;

            item6_Amount.GetComponent<UnityEngine.UI.Text>().text = numOfItems6.ToString();
            totalCost -= 500;
            total_cost.GetComponent<UnityEngine.UI.Text>().text = totalCost.ToString();
        }
    }
}
