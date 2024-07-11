using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdventureManager : MonoBehaviour
{
    public Vector3 mousePos;
    public Camera mainCamera;
    public Vector3 mousePosWorld;
    //public float forceSize;

    //private Rigidbody rb;

    public InventoryObject inventory;

    // RaycastHit hit;

    private void Start()
    {
        //rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        MouseClick();
       

    }

    /* funktioniert, aber gerade nicht gewollt
    public void OnMouseEnter()    // nur Berührung
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); // funktioniert super, aber nur, wenn Script auf anzuklickendem Objekt 
                                                                    
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            //if (hit.transform.gameObject == gameObject)
            
            if (hit.collider.gameObject.GetComponent<Item>() != null)
            {
                var item = gameObject.GetComponent<Item>();
                if (item)
                {
                    Debug.Log("Treffer z2");
                    inventory.AddItem(item.item, 1);
                    Destroy(gameObject);
                    Debug.Log("weg x2");
                }
            }
        }
    }
    */

    public void MouseClick()    // Klick
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Linke Maustaste wurde gedrückt.");
            mousePos = Input.mousePosition;
            Debug.Log("Screen Space :" + mousePos);
            mousePosWorld = mainCamera.ScreenToWorldPoint(mousePos);
            Debug.Log("World Space :" + mousePosWorld);
            //Debug.DrawRay(transform.position, mousePos - transform.position, Color.red);

            // Raycast --> Treffer abspeichern
            //hit = Physics.Raycast(mousePosWorld, out RaycastHit hitInfo);

            
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

            // funktioniert super (sogar für einzelnes Objekt)
            if (Physics.Raycast(ray, out RaycastHit hit)) // funktioniert super
            {                                               // funktioniert nur, wenn Script auf anzuklickendem Objekt liegt
                if (hit.transform.gameObject == gameObject)
                {
                    Debug.Log("Treffer"); // funktioniert
                    /*Debug.DrawRay(transform.position, mousePos - transform.position, Color.red);*/
                    var item = gameObject.GetComponent<Item>();
                    if (item)
                    {
                        inventory.AddItem(item.item, 1);
                        Debug.Log("Plus"); // funktioniert (sogar für einzelnes Objekt)
                        Destroy(gameObject);
                        Debug.Log("weg"); // funktioniert (sogar für einzelnes Objekt)
                    }
            }   
    }

            /* // funktioniert (nimmt aber alle Items gleichzeitig mit)
            if (Physics.Raycast(ray, out RaycastHit hitInfo)) // funktioniert (nimmt aber alle Items gleichzeitig mit)
            {
                if (hitInfo.collider.gameObject.GetComponent<Item>() != null)
                {
                    Debug.Log("Treffer x"); // f
                    //Debug.DrawRay(transform.position, mousePos - transform.position, Color.red);
                    //if (hit.transform.tag == "Fisch")
                    
                        var item = gameObject.GetComponent<Item>();
                        Debug.Log("Treffer y"); // f
                                                //if (hit.collider.gameObject.tag == "Fisch")
                                                //{
                        if (item)
                        {
                            Debug.Log("Treffer z"); // f // funktioniert nur, wenn Script auf anzuklickendem Objekt liegt und aktiviert ist
                            inventory.AddItem(item.item, 1);
                            Destroy(gameObject);
                            Debug.Log("weg x"); // f
                        }
                        //}
                    


                    /*Vector3 distanceToTarget = hitInfo.point - transform.position;
                            Vector3 forceDirection = distanceToTarget.normalized;

                            rb.AddForce(forceDirection * forceSize, ForceMode.Impulse);*/
            //}
            //}
        }



        if (Input.GetMouseButtonDown(1))
        {
            Debug.Log("Rechte Maustaste wurde gedrückt.");
        }
    }

    

    
}
