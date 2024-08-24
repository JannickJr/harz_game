using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TestMovement : MonoBehaviour
{
    PlayerInput cameraInput;
    InputAction moveAction;

    [SerializeField] private float movementSpeedCamera;

    [SerializeField] private Transform leftWall;
    [SerializeField] private Transform rightWall;

    void Start()
    {
        cameraInput = GetComponent<PlayerInput>();
        moveAction = cameraInput.actions.FindAction("Move");
        //Szene 1
        moveAction = cameraInput.actions.FindAction("Move_S1");
        //Szene 3
        //moveAction = cameraInput.actions.FindAction("Move_S3");
    }

    void Update()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
        Debug.Log(moveAction.ReadValue<Vector2>());
        Vector2 direction = moveAction.ReadValue<Vector2>();
        //Szene 1
        transform.position += new Vector3(direction.x, 0, direction.y) * movementSpeedCamera * Time.deltaTime;
        //Szene 3
        //transform.position += new Vector3(direction.x, direction.y, 0) * movementSpeedCamera * Time.deltaTime;

        if (transform.position.x <= leftWall.position.x) // links
        {
            Debug.Log("Es ist soweit."); 
            transform.position = leftWall.position;
        }
        else if (transform.position.x >= rightWall.position.x) // rechts
        {
            transform.position = rightWall.position;
        }
    }
}
