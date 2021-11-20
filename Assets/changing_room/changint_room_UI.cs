using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;


public class changint_room_UI : MonoBehaviour
{
    [SerializeField]
    private GameObject clothing_row;
    [SerializeField]
    //private List<changing_test> my_clothing_list;
   // [SerializeField]
    private MeshRenderer clothes;
    private List<GameObject> clothing_list;
    private GameObject store_row;
    private int i;


    // Start is called before the first frame update
    void Start()
    {
        i = 0;
        //my_clothing_list = new List<changing_test>();

        clothing_list = new List<GameObject>();
        //clothing_list.Add(GameObject.Find("/henry_outfit/long-sleeve").GetComponent<MeshRenderer>());
        //clothing_list.Add(GameObject.Find("/henry_outfit/tshirt"));
      //  clothes = GameObject.Find("/henry_outfit/long-sleeve").GetComponent<MeshRenderer>();
      //  clothes.enabled = true;
        
      //  clothes = GameObject.Find("/henry_outfit/tshirt").GetComponent<MeshRenderer>();
      //  clothes.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

    }
    
    public void add_FAQ_to_list(int i)
    {
        //for(int i = 0; i < my_clothing_list.Count; i++)
        //{
      //  if (my_clothing_list[i].clothing == null)
      //  {
      //      print("question or answer null");
      //  }
      //  else
      //  {
      //      //store_row = Instantiate(clothing_row, transform);
            //store_row.transform.Find("Question").GetComponent<Text>().text = my_clothing_list[i].question;
      //      clothing_list.Add(store_row);
      //  }
        //}
    }


    public void try_shirt()
    {
        clothes = GameObject.Find("/henry_outfit/long-sleeve").GetComponent<MeshRenderer>();
        clothes.enabled = false;
        clothes = GameObject.Find("/henry_outfit/tshirt").GetComponent<MeshRenderer>();
        clothes.enabled = true;
    }
}
