using UnityEngine;
using System.Collections;

public class Example : MonoBehaviour {

    public GameObject bloodSplatter1;
    public GameObject bloodSplatter2;
    public GameObject bloodSplatter3;
    public GameObject bloodSplatter4;
    
    //UGUI button functions
    
    public void Blood1(){
    Instantiate(bloodSplatter1);
    }
    
    public void Blood2(){
    Instantiate(bloodSplatter2);
    }
    
    public void Blood3(){
    Instantiate(bloodSplatter3);
    }
    
    public void Blood4(){
    Instantiate(bloodSplatter4);
    }
    
    void Update(){
    //Swing the camera for Demo scene
    this.transform.Rotate(new Vector3(0,0.25f,0) * Mathf.Sin(Time.time)); 
    }
}
