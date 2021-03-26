using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimapController : MonoBehaviour
{
    public GameObject Canvas;
    // Update is called once per frame
    bool minimapOn = false;
    void Update()
    {

        if (Input.GetKey("m") && (!minimapOn))
        {
            minimapOn = true;
            Canvas.SetActive(true);
        }
            

        if (Input.GetKey("m") && (minimapOn))
        {
            minimapOn = false;
            Canvas.SetActive(false);
        }
            
        
    }
}
