using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class Change_Scene_CS : MonoBehaviour
{

    [SerializeField] private RawImage rawImage;
    [SerializeField] private VideoPlayer videoPlayer;


    private void Awake()
    {
        //videoPlayer.Play();
        videoPlayer.loopPointReached += ChangeSceneWhenVideoFinish; // delegate

    }
    // Start is called before the first frame update
    void Start()
    {
        //StartVideo();
        //videoPlayer.Play();
        //videoPlayer.loopPointReached += ChangeSceneWhenVideoFinish; // delegate
    }

    public void ChangeSceneWhenVideoFinish(VideoPlayer vp)
    {
        Debug.Log("fertig");
        SceneManager.LoadScene("03_Scene_1");
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    /*public void StartVideo()
    {
        StartCoroutine(PlayVideo());
    }

    IEnumerator PlayVideo()
    {
        videoPlayer.Prepare();
        //WaitForSeconds waitForSeconds = new WaitForSeconds(1);
        while (!videoPlayer.isPrepared)
        {
            yield return null;
        }
    
        rawImage.texture = videoPlayer.texture;
        videoPlayer.Play();
        Debug.Log("Playing Video");
        while (videoPlayer.isPlaying)
        {
            Debug.LogWarning("Video Time: " + Mathf.FloorToInt((float)videoPlayer.time));
            yield return null;
        }

        Debug.Log("Done Playing Video");
        
    }

    // Update is called once per frame
    /*void Update()
    {
        VideoReady();
    }

    public void VideoReady()
    {
        if (!videoPlayer.isPlaying)
        {
            SceneManager.LoadScene("03_Scene_1");
        } 
    }*/
}
