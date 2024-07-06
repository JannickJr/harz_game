using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main_Menu : MonoBehaviour
{
    public static bool MainMenuIsActivated;
    
    // Start is called before the first frame update
    void Start()
    {
        MainMenuIsActivated = true;
        Debug.Log(MainMenuIsActivated);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
