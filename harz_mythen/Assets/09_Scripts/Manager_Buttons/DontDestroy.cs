using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroy : MonoBehaviour
{
    private static GameObject[] persistentObjects = new GameObject[3];
    public int objectIndex;

    void Awake() 
    {
        if (persistentObjects[objectIndex] == null) //&& Main_Menu.MainMenuIsActivated == false) // evtl. ausgeführt, wenn Objekte noch nicht existieren in anderer Szene
        {
            persistentObjects[objectIndex] = gameObject;
            DontDestroyOnLoad(gameObject);
            Debug.Log("(persistentObjects[objectIndex] == null)");
        }
        else if (persistentObjects[objectIndex] != gameObject) //&& Main_Menu.MainMenuIsActivated == false) // Löschen/Ersetzen des anderen Gameobjects
        {
            Destroy(gameObject);
            Debug.Log("(persistentObjects[objectIndex] != gameObject)");
        }
    }
}
