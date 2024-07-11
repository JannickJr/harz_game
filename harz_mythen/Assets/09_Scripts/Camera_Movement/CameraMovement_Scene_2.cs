using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement_Scene_2 : MonoBehaviour
{
    // Variante 1:
    float rotationX = 0f;
    float rotationY = 0f;
    public float sensitivity = 5f;

    // Variante 2: // kein 360°-Blick
    /*private float x;
    private float y;
    public float sensitivity_2 = -1f;
    private Vector3 rotate;*/


    void Update()
    {
        // Variante 1: // 360°-Blick
        rotationY += Input.GetAxis("Mouse X") * sensitivity;
        rotationY += Input.GetAxis("Mouse Y") * -1 * sensitivity;
        transform.localEulerAngles = new Vector3(rotationX, rotationY, 0);

        // Variante 2: // kein 360°-Blick
        /*y = Input.GetAxis("Mouse Y");
        x = Input.GetAxis("Mouse X");
        rotate = new Vector3(x, y * sensitivity_2, 0);
        transform.eulerAngles = transform.eulerAngles - rotate;*/
    }
}
