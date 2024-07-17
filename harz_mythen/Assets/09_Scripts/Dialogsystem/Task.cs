using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Task : MonoBehaviour
{
    [SerializeField] private Image box;
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private GameObject task_1;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(FadeOut());
    }

    IEnumerator FadeOut()
    {
        yield return new WaitForSeconds(3f);
        box.CrossFadeAlpha(0, 2, false);
        text.CrossFadeAlpha(0, 2, false);
        yield return new WaitForSeconds(2f);
        StopAllCoroutines();
        task_1.SetActive(false);
    }
}
