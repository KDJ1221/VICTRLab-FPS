using UnityEngine;
using System.Collections;

public class Blood_Splatter : MonoBehaviour {

public Texture2D bloodTexture;
public Color startColor = new Color(1,1,1,1);
public Color endColor = new Color(1,1,1,0);
public float duration = 1.0f;
private float t;
internal Color currentColor;

	void Start () {
	t = Time.time;
	currentColor = startColor;
	Destroy(gameObject,duration+1);
	}

	void OnGUI()
{
	GUI.depth = -1;
	GUI.color = currentColor;
	GUI.DrawTexture(new Rect(0,0,Screen.width,Screen.height), bloodTexture);	
}

	void Update () {
	currentColor = Color.Lerp(startColor, endColor,(Time.time-t)/duration);
	}
}
