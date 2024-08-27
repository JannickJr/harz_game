using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardStart : MonoBehaviour
{
    [SerializeField] private GameObject card;

    private void OnMouseDown()
    {
        card.SetActive(true);
    }

    public void Back()
    {
        card.SetActive(false);
    }
}
