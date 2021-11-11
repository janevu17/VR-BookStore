using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GoToBookStore : MonoBehaviour
{
    public GameObject camera;
    public void LoadGame()
    {
        camera.transform.position = new Vector3(47.21f, camera.transform.position.y, -26.07f);
    }
}
