using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Test_Scene_Change : MonoBehaviour
{
    [SerializeField] private GameObject Slider;
    [SerializeField] private GameObject Slider_2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SceneChange();
    }

    public void SceneChange()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            SceneManager.LoadScene(1);
            Slider.SetActive(false);
            Slider_2.SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.K))
            {
             SceneManager.LoadScene(0);
             Slider.SetActive(false);
             Slider_2.SetActive(true);
            }
        if (Input.GetKeyDown(KeyCode.L))
        {
            SceneManager.LoadScene(2);
            Slider.SetActive(false);
            Slider_2.SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.J))
        {
            SceneManager.LoadScene(3);
            Slider.SetActive(false);
            Slider_2.SetActive(true);
        }
    }
}
