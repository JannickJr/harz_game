using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroy : MonoBehaviour
{
    private static GameObject[] persistentObjects = new GameObject[3];
    public int objectIndex;

    void Awake()
    {
        if (persistentObjects[objectIndex] == null) //&& Main_Menu.MainMenuIsActivated == false)
        {
            persistentObjects[objectIndex] = gameObject;
            DontDestroyOnLoad(gameObject);
        }
        else if (persistentObjects[objectIndex] != gameObject) //&& Main_Menu.MainMenuIsActivated == false)
        {
            Destroy(gameObject);
        }
    }
}
