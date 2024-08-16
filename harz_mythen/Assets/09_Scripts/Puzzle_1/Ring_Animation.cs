using _09_Scripts._Dialogsystem;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ring_Animation : MonoBehaviour
{
    private Animator animator;

    public Camera cam2;

    public static event Action VictoryToDialog;
    //public static event Action OnMarkedItems;
    //public static event Action OnDemarkedItems;

    private void OnEnable() // Eventmanagement fuer Animation
    {
        Puzzle1_Camera.animationVictory += VictoryAnimation;
        Dialog.OnRing += Destroy;
    }

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        MouseClick();
    }

    public void VictoryAnimation() // Eventmanagement fuer Animation
    {
        animator.Play("Ring");
    }

    // Eventmanagement fuer Dialog 2
    public void MouseClick()    // Was beim Anklicken des Rings passiert.
    {
        if (Input.GetMouseButtonDown(0)) 
        {
            Ray ray = cam2.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                if (hit.transform.gameObject.CompareTag("Ring"))
                {
                    Debug.Log("Hit Ring");
                    VictoryToDialog(); // Eventmanagement fuer Dialog 2
                }
                else
                {
                    return;
                }
            }
        }
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }

    /*public void OnMouseEnter()
    {
        OnMarkedItems();
    }

    public void OnMouseExit()
    {
        OnDemarkedItems();
    }*/

    private void OnDestroy()
    {
        Puzzle1_Camera.animationVictory -= VictoryAnimation;
        Dialog.OnRing -= Destroy;
    }
}
