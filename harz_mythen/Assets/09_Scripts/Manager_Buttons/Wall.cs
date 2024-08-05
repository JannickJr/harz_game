using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    private void OnEnable()
    {
        InventoryManager.OnWallActivation += OnWallActivation;
        InventoryManager.OnWallDeactivation += OnWallDeactivation;
    }

    public void OnWallActivation()
    {
        gameObject.SetActive(true);
    }

    public void OnWallDeactivation()
    {
        gameObject.SetActive(false);
    }

    private void OnDestroy()
    {
        InventoryManager.OnWallActivation -= OnWallActivation;
        InventoryManager.OnWallDeactivation -= OnWallDeactivation;
    }
}
