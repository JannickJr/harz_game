using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Dial : MonoBehaviour
{
    [Header(" Settings ")]
    [SerializeField] private float animationDuration;
    private bool isRotating = false;
    private int currentIndex;

    [Header(" Events ")]
    [SerializeField] private UnityEvent<Dial> onDialRotated;

    // Start is called before the first frame update
    void Start()
    {
        //Setup a random     starting index and rotate the renderer accordingly
        currentIndex = Random.Range(0, 10);
        transform.localRotation = Quaternion.Euler(currentIndex * -90, 0, 0);
    }

    public void Rotate()
    {
        //If the dial is already rotating, escape from this method
        if (isRotating)
            return;

        //Otherwise set the dial as isRotating to prevent rotating twice
        isRotating = true;

        //Increase the current dial index / number
        currentIndex++;

        //If the number is greater than 4 it's not what we want, reset (later change to 10 when assets exist)
        if (currentIndex >= 4)
            currentIndex = 0;

        /* Cancel the previous tween on this gameobject, if any, and rotate
         * 360Åã / 4 numbers = 90Åã, we rotate 90 degrees around the local right Axis
         * After rotation call the "RotationCompleteCallback " method */
        LeanTween.cancel(gameObject);
        LeanTween.rotateAroundLocal(gameObject, Vector3.right, -90, animationDuration).setOnComplete(RotationCompleteCallback);
    }

    private void RotationCompleteCallback()
    {
        //Trigger the "onDialRotated" event to let the combination lock that this specific dial has rotated
        onDialRotated?.Invoke(this);
    }

    public int GetNumber()
    {
        //Return the current number on the dial
        return currentIndex;
    }

    public void Lock()
    {
        //Prevents the dial from rotating
        isRotating = true;
    }

    public void Unlock()
    {
        //Allow the dial to rotate
        isRotating = false;
    }

}
