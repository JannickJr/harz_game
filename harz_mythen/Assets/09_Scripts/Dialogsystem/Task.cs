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
    [SerializeField] private TMP_Text text_2;

    public void OnEnable()
    {
        Dialog.OnLoadScene += Activation;
        Change_Scene_CS.OnLoadScene += Activation;
        StartFading();
    }

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

    public void StartFading()
    {
        StartCoroutine(FadeOut());
        TaskVoting();
    }

    public void TaskVoting()
    {
        if (GameObject.Find("03_Scene_01"))
        {
            text.text = "Finde Romars Geschenk für Ruma.";
            text_2.text = "Finde Romars Geschenk für Ruma.";
        }
        if (GameObject.Find("05_Scene_02"))
        {
            text.text = "Lass Ruma aus der Höhle entkommen.";
            text_2.text = "Lass Ruma aus der Höhle entkommen.";
        }
        if (GameObject.Find("07_Scene_03"))
        {
            text.text = "Vereine die beiden Liebenden.";
            text_2.text = "Vereine die beiden Liebenden.";
        }
    }

    public void OnDestroy()
    {
        Dialog.OnLoadScene -= Activation;
        Change_Scene_CS.OnLoadScene -= Activation;
    }
}
