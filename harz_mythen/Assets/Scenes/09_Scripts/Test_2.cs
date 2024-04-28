using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_2 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            if (hit.transform.gameObject == gameObject)
            {
                Debug.Log("Treffer 2");
                //Debug.DrawRay(transform.position, mousePos - transform.position, Color.red);
            }

        }
    }
}
