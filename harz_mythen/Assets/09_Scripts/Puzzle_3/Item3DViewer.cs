using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Item3DViewer : MonoBehaviour, IDragHandler
{
    [SerializeField] OpenItem3DViewer item3DViewer;
    
    private void RotateOnDrag(PointerEventData eventData, Transform itemPrefab)
    {
        itemPrefab.eulerAngles += new Vector3(-eventData.delta.y, -eventData.delta.x);
        Debug.Log("rotating");
    }
    
    public void OnDrag(PointerEventData eventData)
    {

        RotateOnDrag(eventData, item3DViewer.itemPrefab);

}
}
