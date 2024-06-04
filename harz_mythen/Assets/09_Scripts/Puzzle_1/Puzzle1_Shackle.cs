using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle1_Shackle : MonoBehaviour
{

    [Header(" Animation Settings ")]
    [SerializeField] private float yMovement;
    [SerializeField] private float yMovementDuration;
    [SerializeField] private float rotationAngle;
    [SerializeField] private float rotationDuration;

    public void Open()
    {
        //Open the shackle
        LeanTween.moveLocalY(gameObject, yMovement, yMovementDuration).setEase(LeanTweenType.easeOutBack).setOnComplete(
            () => LeanTween.rotateAroundLocal(gameObject, Vector3.up, rotationAngle, rotationDuration).setEase(LeanTweenType.easeOutBack));
    }
   
}
