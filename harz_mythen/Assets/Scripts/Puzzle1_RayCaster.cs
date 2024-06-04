using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle1_RayCaster : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        //Manage the player input every frame
        ManageInput();
    }

    private void ManageInput()
    {
        //Whenever we click down on the mouse, call the Raycast method
        if (Input.GetMouseButtonDown(0))
            Raycast();
    }

    private void Raycast()
    {
        //Store the raycast data in "hit"
        RaycastHit hit;
        Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 5);

        //If we did not hit anything just get back to whatever we were doing
        if (hit.collider == null)
            return;

        //Otherwise store the Dial component to use it
        Dial dial = hit.collider.GetComponent<Dial>();

        //Does the collider we hit really have a dial component attached to it?
        if (dial == null)
            return;

        //If we hit a dial gently tell him to rotate lol
        dial.Rotate();
    }
}
