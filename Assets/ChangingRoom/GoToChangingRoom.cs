using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToChangingRoom : MonoBehaviour
{
    
    public void LoadGame()
    {
        SceneManager.LoadScene(1);
    }
    void Start()
    {
        Debug.Log("LOADING ROOM");
        SceneManager.LoadScene(1);
    }
}
