using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    [SerializeField] GameObject wallConnection;

    private void OnEnable()
    {
        InventoryManager.OnWallActivation += OnWallActivation;
        InventoryManager.OnWallDeactivation += OnWallDeactivation;
    }

    public void OnWallActivation()
    {
        wallConnection.SetActive(true);
    }

    public void OnWallDeactivation()
    {
        wallConnection.SetActive(false);
    }

    private void OnDestroy() 
    {
        InventoryManager.OnWallActivation -= OnWallActivation;
        InventoryManager.OnWallDeactivation -= OnWallDeactivation;
    }
}
