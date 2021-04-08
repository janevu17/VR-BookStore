using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEditor;
using UnityEngine.XR;

public class MinimapController : MonoBehaviour
{
    private Canvas minimapObject;            // Reference to the minimap cnavas in Hierarchy

    //GraphicRaycaster hit;                   // Graphic raycaster from mouse to minimap canvas
    //EventSystem eventSystem;                // Event System
    //PointerEventData eventData;             // Event Data for mouse raycast
    public GameObject XRRig;          // Reference to FirstPersonMinimap object in Hierarchy

    public float checkRadius = 1f;          // public changeable radius of checking for collision when teleporting

    private CharacterController characterController;

    private InputDevice device; //Oculus input controls

    private GameObject teleportButtons;

    // Update is called once per frame
    private void Start()
    {
        minimapObject = transform.GetComponent<Canvas>();         // Get the Canvas component of the minimap canvas

        //hit = GetComponent<GraphicRaycaster>();         // Get Graphic raycaster component of the minimap canvas
        //eventSystem = GetComponent<EventSystem>();
        minimapObject.enabled = false;
        characterController = XRRig.GetComponent<CharacterController>();

        device = InputDevices.GetDeviceAtXRNode(XRNode.LeftHand);

        foreach (Transform child in transform)
        {
            if (child.name == "TeleportButtons")
            {
                teleportButtons = child.gameObject;
            }
        }
        teleportButtons.SetActive(false); //disable TeleportButtons
    }
    /*
    // Convert from pixel (mouse position on screen) to Scene coordinates
    // Take in new position of where you want to teleport to w.r.t the game screen (in pixels) Vector3 (x, y, z)
    // Return the new position of where you want to teleport to w.r.t to scene (in scene coordinates) Vector2 of just x and z
    private Vector2 ConvertToCoords(Vector3 newPos)
    {
        Vector2 toReturn;

        // Get the resolution of the game screen and get the width and height
        string[] res = UnityStats.screenRes.Split('x');
        float screenW = int.Parse(res[0]);
        float screenH = int.Parse(res[1]);

        // Find the origin on the screen 
        Vector2 origin = new Vector2(screenW / 2, screenH / 2);

        // Canvas size is a square and the dimension is always scaled to height of game screen
        float canvasSize = screenH;

        // mathematical equations for conversion
        toReturn.x = (newPos.x - origin.x) / canvasSize * 100;
        toReturn.y = (newPos.y - origin.y) / canvasSize * 100;

        return toReturn;
    }

    // Check a location and see if there's any collision around
    private bool CheckSurrounding(Vector3 center)
    {
        // Do check for coolision with ground (ground layer is number 9)
        int layerMask = 1 << 9;
        layerMask = ~layerMask;
        bool isOccupied = false;

        // Pass in any object that collides in a adjustable radius
        Collider[] hitColliders = Physics.OverlapSphere(center, checkRadius, layerMask);

        // If any object in there, don't teleport
        if (hitColliders.Length != 0)
        {
            Debug.Log("Location Occupied");
            isOccupied = true;
        }
        return isOccupied;
    }
    */

    public void Teleport(buttonController button)
    {
        Vector3 temp;
        temp.x = button.correspondingCoordinates.x;
        temp.z = button.correspondingCoordinates.y;
        temp.y = XRRig.transform.position.y;

        characterController.enabled = false;
        XRRig.transform.position = temp;
        characterController.enabled = true;
    }

    //Click on Exit button on minimap to close it
    public void CloseMap()
    {
        minimapObject.enabled = false;
        teleportButtons.SetActive(false);
    }

    void Update()
    {
        // Press m to open and close minimap
        //if (Input.GetKeyDown("m"))
        //Press X to open minimap
        bool buttonPress;
        if ((device.TryGetFeatureValue(CommonUsages.primaryButton, out buttonPress) && buttonPress) || Input.GetKeyDown("m"))
        {
            minimapObject.enabled = true;
            teleportButtons.SetActive(true);
        }
        //if (minimapObject.enabled)
        //{
        //    // Left click to get position of mouse
        //    if (Input.GetMouseButtonDown(0))
        //    {
        //        eventData = new PointerEventData(eventSystem);
        //        eventData.position = Input.mousePosition;

        //        // Raycast from mouse position to minimap canvas
        //        List<RaycastResult> result = new List<RaycastResult>();
        //        hit.Raycast(eventData, result);

        //        // Only do these things if mouse click was registered on minimap canvas
        //        foreach (RaycastResult element in result)
        //        {
        //            if (element.gameObject.tag == "button")
        //            {
        //                Debug.Log("current pos:" + firstPerson.transform.position);
        //                Vector3 temp;
        //                temp.x = element.gameObject.GetComponent<buttonController>().correspondingCoordinates.x;
        //                temp.z = element.gameObject.GetComponent<buttonController>().correspondingCoordinates.y;
        //                temp.y = firstPerson.transform.position.y;
        //                Debug.Log("new pos: " + temp);
        //                firstPerson.transform.position = temp;
        //                Debug.Log("after move: " + firstPerson.transform.position);
        //            }
        //            /*
        //            Vector3 temp;
        //            // Do conversion
        //            temp.x = ConvertToCoords(eventData.position).x;
        //            temp.z = ConvertToCoords(eventData.position).y;
        //            temp.y = firstPerson.transform.position.y;

        //            // Check surrounding
        //            if (CheckSurrounding(temp) == false)
        //                firstPerson.transform.position = temp;
        //            */
        //        }
        //    }
        //}
    }
}