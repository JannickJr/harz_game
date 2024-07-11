using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Test_Scene_Change : MonoBehaviour
{
    // in Benutzung
    [SerializeField] private GameObject Slider;
    [SerializeField] private GameObject Slider_2;


    void Update()
    {
        SceneChange();
    }

    public void SceneChange() // Szenenwechsel
    {
        if (Input.GetKeyDown(KeyCode.M)) // mit M
        {
            SceneManager.LoadScene(1);
            Slider.SetActive(false);
            Slider_2.SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.K)) // mit K
            {
             SceneManager.LoadScene(0);
             Slider.SetActive(false);
             Slider_2.SetActive(true);
            }
        if (Input.GetKeyDown(KeyCode.L)) // mit L
        {
            SceneManager.LoadScene(2);
            Slider.SetActive(false);
            Slider_2.SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.J)) // mit J
        {
            SceneManager.LoadScene(3);
            Slider.SetActive(false);
            Slider_2.SetActive(true);
        }
    }
}
