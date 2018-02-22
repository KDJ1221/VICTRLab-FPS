using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Screenshot : MonoBehaviour {

	void Update () {
		if(Input.GetKeyDown(KeyCode.K))
        {
            ScreenCapture.CaptureScreenshot(("C:\\Users\\Jeffrey\\Documents\\GitHub\\VICTRLab-FPS\\VICTRLAB FPS\\Screenshots" + System.DateTime.Now.ToString("__yyyy-MM-dd") + ".png"));
        }
	}
}
