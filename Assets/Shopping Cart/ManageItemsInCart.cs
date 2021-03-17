using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManageItemsInCart : MonoBehaviour
{
/*    Collider[] inCart;*/
    public GameObject cart;
    public Collider[] inCart; 
    void CountObj(Vector3 center, float radius)
    {
        inCart = Physics.OverlapSphere(center, radius);
        foreach (var hitCollider in inCart)
        {
            if (hitCollider.tag == "TestObj")
            {
                Debug.Log(hitCollider.name);
            }
        }

    }


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        CountObj(cart.transform.position, 1f);
    }
}
