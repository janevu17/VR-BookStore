using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class CartManager : XRBaseInteractor
{
    private List<GameObject> items = new List<GameObject>(); //list of items in the cart
    public item_list checkoutScript;

    private void OnTriggerEnter(Collider other)
    {
        //if collider is an item, then add item
        if (other.CompareTag("TestObj"))
        {
            checkoutScript.addItem(other.gameObject);
            items.Add(other.gameObject);
            print("Added: " + other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        //if collider is an item, then remove item
        if (other.CompareTag("TestObj"))
        {
            checkoutScript.removeItem(other.gameObject);
            items.Remove(other.gameObject);
            print("Removed: " + other.gameObject);
        }
    }

    //Trigger Area can hover item that is hovering and not selected
    public override bool CanHover(XRBaseInteractable interactable)
    {
        return base.CanHover(interactable) && !interactable.isSelected;
    }

    //Trigger Area can't select item
    public override bool CanSelect(XRBaseInteractable interactable)
    {
        return false;
    }

    public override void GetValidTargets(List<XRBaseInteractable> validTargets)
    {
        throw new System.NotImplementedException();
    }
}
