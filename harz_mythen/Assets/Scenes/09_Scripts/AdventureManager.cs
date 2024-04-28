using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdventureManager : MonoBehaviour
{
    public Vector3 mousePos;
    public Camera mainCamera;
    public Vector3 mousePosWorld;
    public float forceSize;

    private Rigidbody rb;


    // RaycastHit hit;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        MouseClick();
        MouseRay();

    }

    public void MouseClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Linke Maustaste wurde gedrückt.");
            mousePos = Input.mousePosition;
            Debug.Log("Screen Space :" + mousePos);
            mousePosWorld = mainCamera.ScreenToWorldPoint(mousePos);
            Debug.Log("World Space :" + mousePosWorld);
            Debug.DrawRay(transform.position, mousePos - transform.position, Color.red);

            // Raycast --> Treffer abspeichern
            //hit = Physics.Raycast(mousePosWorld, out RaycastHit hitInfo);

            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                if (hit.transform.gameObject == gameObject)
                {
                    Debug.Log("Treffer");
                    Debug.DrawRay(transform.position, mousePos - transform.position, Color.red);
                }
                
            }

            /*if (Physics.Raycast(ray, out RaycastHit hitInfo))
            {
                if (hitInfo.collider.gameObject.GetComponent<Target>() != null)
                {
                    Vector3 distanceToTarget = hitInfo.point - transform.position;
                    Vector3 forceDirection = distanceToTarget.normalized;

                    rb.AddForce(forceDirection * forceSize, ForceMode.Impulse);
                }
            }*/
        }


        if (Input.GetMouseButtonDown(1))
        {
            Debug.Log("Rechte Maustaste wurde gedrückt.");
        }
    }

    public void MouseRay()
    {

    }

    
}
