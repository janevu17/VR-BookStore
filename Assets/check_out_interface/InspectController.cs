using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR;

/*
 * IMPORTANT: Have to disable script in ItemPrefab, then enable in Database script
 * ItemObject needs to be created with ObjectController script first
 * Then enable InspectController script in order to initialize object details based on ItemObject properties
 */

/*
 * Manages and Updates ItemInspection UI
 * Displays Item name, price, and info
 * Attached to all purchasable items
 */
public class InspectController : MonoBehaviour
{
    //Controller Input Source
    public XRNode inputSource;

    //ItemInspection UI Elements
    [SerializeField] private GameObject itemUI;
    [SerializeField] private Text objectNameText;
    [SerializeField] private Text objectPriceText;
    [SerializeField] private GameObject objectInfoUI;
    [SerializeField] private Text objectInfoText;

    //Item Details (should be set to private later when Database is implemented)
    public string objectName;
    public float objectPrice;
    [TextArea]
    public string objectInfo;

    //Script and GameObject with Item Details
    private ObjectController objController;
    private ItemObject item;

    //Controller Input Detection
    private InputDevice device;
    private bool gripPress;
    private bool lastButtonPress;

    private void Start()
    {
        //Initialize device based on Input Source
        device = InputDevices.GetDeviceAtXRNode(inputSource);

        //Disable ItemInspection UI 
        //itemUI.SetActive(false);
        //objectInfoUI.SetActive(false);

        //Initialize ObjectController script
        objController = GetComponent<ObjectController>();

        //Remove this later. Should be called in Database
        //objController.CreateItemObject(objectName, "randomID", objectInfo, objectPrice, 1);

        //Initialize ItemObject
        item = objController.GetItemObject();

        //Set text variable for all Text compements in ItemInspection UI
        //SetNameUI(item.GetName());
        //SetPriceUI(item.GetPrice());
        //SetInfoUI(item.GetInfo());

        //Initialize booleans for input detection
        gripPress = false;
        lastButtonPress = false;
    }

    //Setters for setting text of all Text components in ItemInpection UI
    public void SetNameUI(string name)
    {
        objectName = name;
    }
    public void SetPriceUI(float price)
    {
        objectPrice = price;
    }

    public void SetInfoUI(string info)
    {
        objectInfo = info;
    }

    //If User is grabbing an item, then show/hide item name and description on button hold (A)
    private void Update()
    {
        if (gripPress && device.TryGetFeatureValue(CommonUsages.primaryButton, out bool buttonPress))
        {
            if (buttonPress != lastButtonPress)
            {
                objectInfoUI.SetActive(!objectInfoUI.activeSelf);
            }

            lastButtonPress = buttonPress;
        }
    }

    //XR Grab Interactable: Interactable Events
    //OnHoverEntered
    //Update and show object name and price
    public void ShowName()
    {
        objectNameText.text = objectName;
        objectPriceText.text = objectPrice.ToString();
        itemUI.SetActive(true);
    }

    //OnHoverExited
    //Hide object name and price
    public void HideName()
    {
        itemUI.SetActive(false);
    }

    //OnSelectEntered
    //Update object info and gripPress
    public void GrabbedObject()
    {
        objectInfoText.text = objectInfo;
        gripPress = true; //User is holding object
    }

    //OnSelectExited
    //Update gripPress
    public void DroppedObject()
    {
        gripPress = false; //User dropped object
        //Uncomment below statement if they don't hide automatically after releasing object
        //itemUI.SetActive(false);
        //objectInfoUI.SetActive(false); 
    }
}