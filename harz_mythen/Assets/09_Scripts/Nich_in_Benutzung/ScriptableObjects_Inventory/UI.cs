using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI : MonoBehaviour // Ist nur ein Test-Script
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Item>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
