using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEditor;

public class MinimapController : MonoBehaviour
{
    public Canvas minimapObject;
    GraphicRaycaster hit;
    EventSystem eventSystem;
    PointerEventData eventData;
    public GameObject firstPerson;

    public float checkRadius = 1f;


    // Update is called once per frame
    private void Start()
    {
        minimapObject = GetComponent<Canvas>();
        hit = GetComponent<GraphicRaycaster>();
        eventSystem = GetComponent<EventSystem>();
    }

    private Vector2 ConvertToCoords(Vector3 newPos)
    {
        Vector2 toReturn;
        string[] res = UnityStats.screenRes.Split('x');
        float screenW = int.Parse(res[0]);
        float screenH = int.Parse(res[1]);

        Vector2 origin = new Vector2(screenW / 2, screenH / 2);
        float canvasSize = screenH;

        toReturn.x = (newPos.x - origin.x) / canvasSize * 100;
        toReturn.y = (newPos.y - origin.y) / canvasSize * 100;

        return toReturn;
    }

    private bool CheckSurrounding(Vector3 center)
    {
        int layerMask = 1 << 9;
        layerMask = ~layerMask;
        bool isOccupied = false;
        Collider[] hitColliders = Physics.OverlapSphere(center, checkRadius, layerMask);
        if (hitColliders.Length != 0)
        {
            Debug.Log("Location Occupied");
            isOccupied = true;
        }
        return isOccupied;
    }
    void Update()
    {
        if (Input.GetKeyDown("m"))
        {
            minimapObject.enabled = !minimapObject.enabled;
        }

        if (minimapObject.enabled)
        {
            if (Input.GetMouseButtonDown(0))
            {
                eventData = new PointerEventData(eventSystem);
                eventData.position = Input.mousePosition;

                List<RaycastResult> result = new List<RaycastResult>();

                hit.Raycast(eventData, result);
                
                foreach (RaycastResult element in result)
                {
                    //Debug.Log(ConvertToCoords(eventData.position));
                    Vector3 temp;
                    temp.x = ConvertToCoords(eventData.position).x;
                    temp.z = ConvertToCoords(eventData.position).y;
                    temp.y = firstPerson.transform.position.y;

                    if (CheckSurrounding(temp) == false)
                        firstPerson.transform.position = temp;
                }
            }
        }
    }
}
