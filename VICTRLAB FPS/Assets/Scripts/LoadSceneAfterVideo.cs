using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class LoadSceneAfterVideo : MonoBehaviour
{
    public VideoPlayer VideoPlayer;
    public string SceneName;

    void Start()
    {
        VideoPlayer.loopPointReached += LoadNewScene;
    }

    void LoadNewScene(VideoPlayer vp)
    {
        SceneManager.LoadScene(SceneName);
    }


}
