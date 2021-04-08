using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class CheckoutController : MonoBehaviour
{
    private Canvas checkoutCanvas;

    //Controller Input Detection
    private InputDevice device;
    private bool buttonPress;

    // Start is called before the first frame update
    void Start()
    {
        checkoutCanvas = transform.GetComponent<Canvas>();
        checkoutCanvas.enabled = false;

        device = InputDevices.GetDeviceAtXRNode(XRNode.RightHand);
        buttonPress = false;
    }

    //If Exit button is clicked on CheckoutUI, then close CheckoutUI
    public void CloseCheckout()
    {
        checkoutCanvas.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        //If B button on Oculus is pressed, then open CheckoutUI
        if ((device.TryGetFeatureValue(CommonUsages.secondaryButton, out buttonPress) && buttonPress) || Input.GetKeyDown("c"))
        {
            checkoutCanvas.enabled = true;
        }
    }
}
