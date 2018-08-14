using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneSwitch : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        
    }

    void Update()
    {
        SceneManager.LoadScene("Opening1");
    }
}
