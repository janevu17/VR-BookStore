using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.XR;

public class MenuManager : MonoBehaviour
{
    public Panel currentPanel = null;
    public Panel mainPanel;
    private List<Panel> panelHistory = new List<Panel>();
    /*
    public GameObject mainMenu,instructionMenu, optionsMenu, creditsMenu;
    public GameObject instructionButton, optionsButton, creditButton, exitButton;
    public GameObject first_back_button;
    public GameObject toggle_button, second_back_button;
    public GameObject third_back_button;
    */

    private Canvas menuCanvas;
    public Canvas miniMapUI;
    public Canvas checkoutUI;

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
    }

    private void SetupPanels()
    {
        Panel[] panels = GetComponentsInChildren<Panel>();
        foreach (Panel panel in panels) 
            panel.Setup(this);
        currentPanel.Show();    
    }

    private void Update()
    {
        //Click on MenuButton on LeftHand Controller to open the MenuUI
        
        if ((device.TryGetFeatureValue(CommonUsages.menuButton, out buttonPress) && buttonPress) || Input.GetKeyDown("x"))
        {
            menuCanvas.enabled = true;
            miniMapUI.enabled = false;
            checkoutUI.enabled = false;
            Pause();
        }
        
        /*
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseUnpause();

        }
        */

        /*
        if (Input.GetMouseButton(0))
        {
            GoToPrevious();
        }
        */
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
}
