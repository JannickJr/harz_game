using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenItem3DViewer : MonoBehaviour
{
    [SerializeField] private GameObject item3DViewerPrefab;
    [SerializeField] private Transform prefab;

    public Transform itemPrefab;

    [SerializeField] private Camera mainCamera;

    private void OnMouseDown() //Klick
    {
        item3DViewerPrefab.SetActive(true);

        if (itemPrefab != null)
        {
            Destroy(itemPrefab.gameObject);
        }

        itemPrefab = Instantiate(prefab, new Vector3(1000, 1000, 1000), Quaternion.identity);
        //itemPrefab.transform.position = mainCamera.transform.position + mainCamera.transform.forward * 2;     old approach w/o 2nd camera


    }

}
