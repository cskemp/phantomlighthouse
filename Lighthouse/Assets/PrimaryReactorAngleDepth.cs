using System.Collections;
using UnityEngine;

public class PrimaryReactorAngleDepth : MonoBehaviour
{
    public PrimaryButtonWatcher watcher;
    public bool IsPressed = false; // used to display button state in the Unity Inspector window
    //public Vector3 zInc= new Vector3(5, 0, 0);
    public Vector3 angleVector = new Vector3(0f, 0f, 0.2f); 
    public Vector3 currentEulerAngles;


    void Start()
    {
        watcher.primaryButtonPress.AddListener(onPrimaryButtonEvent);
        Debug.Log("Started watching!");
    }

    public void onPrimaryButtonEvent(bool pressed)
    {
        IsPressed = pressed;

        Quaternion currentRotation = this.transform.rotation;

        if (pressed) 
            //this.transform.rotation += zInc;
            this.transform.rotation = currentRotation * Quaternion.Euler(angleVector);
        
        Debug.Log("Button Pressed!");

    }
    
}
