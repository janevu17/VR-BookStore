using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;

public class ApplyOutOfStock : MonoBehaviour
{
    public GameObject GO;
    public string dateVal;
    private TextMesh text;
    public Material material;
    Renderer rend;
    public bool outOfStock;

    // Start is called before the first frame update
    void Start()
    {
        if (outOfStock)
        {
            rend = GetComponent<Renderer>();
            rend.enabled = true;
            rend.sharedMaterial = material;
            Vector3 loc = transform.position;
            loc.y += 2.0f;
            Vector3 rote = transform.rotation.eulerAngles;
            spawnOOS(loc, rote);
            loc.y -= .5f;
            spawnBackIn(loc, rote);


            GetComponent<XRGrabInteractable>().enabled = false;
        }
    }

    private void spawnOOS(Vector3 spawnPosition, Vector3 rote)
    {
        GameObject oosLogo = Instantiate(GO, spawnPosition, Quaternion.identity);
        oosLogo.transform.Rotate(rote);
    }
    private void spawnBackIn(Vector3 spawnPosition, Vector3 rote)
    {
        Font arial;
        arial = (Font)Resources.GetBuiltinResource(typeof(Font), "Arial.ttf");

        GameObject oosBack = new GameObject();
        oosBack.AddComponent<TextMesh>();
        text = oosBack.GetComponent<TextMesh>();
        text.text = dateVal;
        text.font = arial;
        text.fontSize = 12;
        Vector3 changeVec = new Vector3(-0.07f, 0.07f, oosBack.transform.localScale.z);
        oosBack.transform.localScale -= new Vector3(1.0f,1.0f,1.0f);
        oosBack.transform.localScale += changeVec;
        oosBack.transform.position = spawnPosition;
        oosBack.transform.Rotate(rote);


    }
}
