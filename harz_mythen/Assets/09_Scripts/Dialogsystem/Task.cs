using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using _09_Scripts._Dialogsystem;

public class Task : MonoBehaviour
{
    [SerializeField] private Image box;
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private GameObject task_1;

    public void OnEnable()
    {
        Dialog.OnLoadScene += Activation;
        Change_Scene_CS.OnLoadScene += Activation;
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(FadeOut()); // hier auch auf Text zugreifen
    }

    IEnumerator FadeOut()
    {
        yield return new WaitForSeconds(3f);
        box.CrossFadeAlpha(0, 2, false);
        text.CrossFadeAlpha(0, 2, false);
        yield return new WaitForSeconds(2f);
        task_1.SetActive(false);
        box.CrossFadeAlpha(1, 0, false);
        text.CrossFadeAlpha(1, 0, false);
        StopAllCoroutines();
    }

    public void Activation()
    {
        task_1.SetActive(true);
        /*Debug.Log("Fading!");
        StartCoroutine(FadeOut());*/ // anders verknüpfen, nämlich nach Dialog; und auch auf Text zugreifen
    }

    public void OnDestroy()
    {
        Dialog.OnLoadScene -= Activation;
        Change_Scene_CS.OnLoadScene -= Activation;
    }
}
