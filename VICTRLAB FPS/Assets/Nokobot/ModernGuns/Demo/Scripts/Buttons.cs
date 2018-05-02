using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour 
{
	int currentSet;

	public GameObject[]	weaponSet;

	void Start()
	{
		currentSet = 0;
		weaponSet [currentSet].SetActive (true);
	}

	public void Next()
	{
		weaponSet [currentSet].SetActive (false);
		currentSet++;
		if (currentSet >= weaponSet.Length)
			currentSet = 0;
//		if (next == weaponSet.Length-1)
//			return;
		weaponSet [currentSet].SetActive (true);
	}

	public void Back()
	{
		weaponSet [currentSet].SetActive (false);
		currentSet--;
		if (currentSet < 0)
			currentSet = weaponSet.Length - 1;
//		if (next == currentSet)
//			return;
		weaponSet [currentSet].SetActive (true);
	}
}
