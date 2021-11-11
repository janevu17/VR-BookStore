using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToChangingRoom : MonoBehaviour
{
    public GameObject camera;
    public void LoadGame()
    {
        camera.transform.position = new Vector3(-101.0f, camera.transform.position.y, 6.85f);
    }

}
