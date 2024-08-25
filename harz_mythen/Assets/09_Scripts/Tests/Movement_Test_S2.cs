using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement_Test_S2 : MonoBehaviour
{
    //---WASD-VARIANTE---//
    PlayerInput cameraInput;
    InputAction moveAction;
    public float rotationSpeed;
    //public GameObject objectRotate;


    private void Start()
    {
        //---WASD-VARIANTE---//
        cameraInput = GetComponent<PlayerInput>();
        moveAction = cameraInput.actions.FindAction("Move_S2");
        Debug.Log(cameraInput.actions.FindAction("Move_S2"));
    }

    void Update()
    {
        Rotation();
    }

    public void Rotation()
    {
        Vector2 direction = moveAction.ReadValue<Vector2>();
        rotationSpeed = 30f;
        transform.eulerAngles += new Vector3(direction.x, direction.y, 0) * rotationSpeed * Time.deltaTime;

        if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S))
        {
            rotationSpeed = 0f;
        }

        /*if (Input.GetKey(KeyCode.D))
        {
            rotationSpeed = 30f;
            objectRotate.transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A))
        {
            rotationSpeed = 30f;
            objectRotate.transform.Rotate(Vector3.down, rotationSpeed * Time.deltaTime);
        }*/
    }
}
