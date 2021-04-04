using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InspectController : MonoBehaviour
{
    [SerializeField] private GameObject objectNameBG;
    [SerializeField] private Text objectNameUI;

    //[SerializeField] private float onScreenTimer;
    [SerializeField] private Text extraInfoUI;
    [SerializeField] private GameObject extraInfoBG;
    //[HideInInspector] public bool startTimer;
    private float timer;

    private void Start()
    {
        objectNameBG.SetActive(false);
        extraInfoBG.SetActive(false);
    }
    /*
    private void Update()
    {
        if (startTimer)
        {
            timer -= Time.deltaTime;

            if (timer <= 0)
            {
                timer = 0;
                ClearAdditionalInfo();
                startTimer = false;
            }
        }
    }
    */
    public void ShowName(string objectName)
    {
        objectNameBG.SetActive(true);
        objectNameUI.text = objectName;
    }

    public void HideName()
    {
        objectNameBG.SetActive(false);
        objectNameUI.text = "";
    }

    public void ShowAdditionalInfo(string newInfo)
    {
        //timer = onScreenTimer;
        //startTimer = true;
        extraInfoBG.SetActive(true);
        extraInfoUI.text = newInfo;
    }

    public void ClearAdditionalInfo()
    {
        extraInfoBG.SetActive(false);
        extraInfoUI.text = "";
    }
}
