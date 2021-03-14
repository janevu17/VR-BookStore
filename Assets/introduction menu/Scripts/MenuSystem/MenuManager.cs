﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
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
    private void Start()
    {
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
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseUnpause();

        }
        /*
        if (Input.GetMouseButton(0))
        {
            GoToPrevious();
        }
        */
    }

   public void PauseUnpause()
   {
        if (panelHistory.Count == 0)
        {
            SetCurrentWithHistory(mainPanel);
            currentPanel.Show();
            
        }
        else
        {
            currentPanel.Hide();
            panelHistory.RemoveAt(0);
        }
        
           
        


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
