using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.XR;
using UnityEngine.UI;

public class billing_ui_script : MonoBehaviour
{
    public Panel currentPanel = null;
    private Panel currentPane2 = null;
    private Panel currentPane3 = null;
    public Panel mainPanel;
    public GameObject CheckoutButton = null;
    private List<Panel> panelHistory = new List<Panel>();

    /*
    public GameObject mainMenu,instructionMenu, optionsMenu, creditsMenu;
    public GameObject instructionButton, optionsButton, creditButton, exitButton;
    public GameObject first_back_button;
    public GameObject toggle_button, second_back_button;
    public GameObject third_back_button;
    */

    private Canvas menuCanvas;

    //Controller Input Detection
    private InputDevice device;
    private bool buttonPress;

    private void Start()
    {
        menuCanvas = GetComponent<Canvas>();
        menuCanvas.enabled = false;
        device = InputDevices.GetDeviceAtXRNode(XRNode.LeftHand);
        buttonPress = false;
        SetupPanels();
        CheckoutButton.gameObject.SetActive(false);
    }

    private void SetupPanels()
    {
        Panel[] panels = GetComponentsInChildren<Panel>();
        foreach (Panel panel in panels)
            panel.Setup(this.gameObject);
        currentPanel.Show();
    }

    private void Update()
    {
        //Click on MenuButton on LeftHand Controller to open the MenuUI
        if ((device.TryGetFeatureValue(CommonUsages.menuButton, out buttonPress) && buttonPress) || Input.GetKeyDown("x"))
        {
            menuCanvas.enabled = true;
            Pause();
        }

       
    }

    public void Pause()
    {
        SetCurrentWithHistory(mainPanel);
        currentPanel.Show();
    }

    //Click Exit button to exit the MenuUI
    public void Exit()
    {
        currentPanel.Hide();
        panelHistory.RemoveAt(0);
        menuCanvas.enabled = false;
    }

    public void GoToPrevious()
    {
        if (panelHistory.Count == 0)
        {

        }
        else
        {
            int lastIndex = panelHistory.Count - 1;
            SetCurrent(panelHistory[lastIndex]);
            panelHistory.RemoveAt(lastIndex);
        }


    }

    public void SetCurrentWithHistory(Panel newPanel)
    {
        panelHistory.Add(currentPanel);
        SetCurrent(newPanel);

    }

    public void SetCurrent(Panel newPanel)
    {
        currentPanel.Hide();

        currentPanel = newPanel;
        currentPanel.Show();
    }

    public void show_sub_panel(Panel newPanel)
    {
        if (currentPane2 != null)
        {
            currentPane2.Hide();
        }


        currentPane2 = newPanel;
        currentPane2.Show();
    }

    public void show_sub_sub_panel(Panel newPanel)
    {

        currentPane2.Hide();
        currentPane3 = newPanel;
        currentPane3.Show();


    }

    public void set_button_active(GameObject button)
    {
        button.gameObject.SetActive(true);
    }
    public void set_button_inactive(GameObject button)
    {
        button.gameObject.SetActive(false);
    }

    public void check_card_type(Text card_num)
    {

    }
}
