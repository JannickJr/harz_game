using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveStars : MonoBehaviour
{
    private Vector3 mOffset;
    private void OnMouseDrag()
    {
        transform.position = GetMouseWorldPos() + mOffset;
    }

    private void OnMouseDown()
    {
        mOffset = gameObject.transform.position - GetMouseWorldPos();
    }

    private Vector3 GetMouseWorldPos() //although working with a Vector 3 we only get the x and y values since the z value won't be needed for the puzzle
    {
        Vector3 mousePoint = Input.mousePosition;

        return Camera.main.ScreenToWorldPoint(mousePoint);
    }
}
