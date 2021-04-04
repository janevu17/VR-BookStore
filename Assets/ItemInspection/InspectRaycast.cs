using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InspectRaycast : MonoBehaviour
{
    [SerializeField] private int rayLength = 5;
    [SerializeField] private LayerMask layerMaskInteract;
    private ObjectController raycastedObj;

    [SerializeField] private Image crosshair;
    private bool crosshairActive;
    private bool doOnce;

    // Update is called once per frame
    private void Update()
    {
        RaycastHit hit;
        Vector3 fwd = transform.TransformDirection(Vector3.forward);

        if (Physics.Raycast(transform.position, fwd , out hit, rayLength, layerMaskInteract.value))
        {
            if (hit.collider.CompareTag("TestObj"))
            {
                if (!doOnce)
                {
                    raycastedObj = hit.collider.gameObject.GetComponent<ObjectController>();
                    raycastedObj.ShowObjectName(); 
                    CrosshairChange(true);
                }

                crosshairActive = true;
                doOnce = true;

                if (Input.GetMouseButtonDown(0)) // key pressed I
                {
                    raycastedObj.ShowExtraInfo();
                }
            }
        }
        else
        {
            if (crosshairActive)
            {
                raycastedObj.HideObjectName();
                raycastedObj.HideExtraInfo();
                CrosshairChange(false);
                doOnce = false;
            }
        }
        
    }

    void CrosshairChange(bool on)
    {
        if (on && !doOnce)
            crosshair.color = Color.red;
        else
        {
            crosshair.color = Color.white;
            crosshairActive = false;
        }

    }
}
