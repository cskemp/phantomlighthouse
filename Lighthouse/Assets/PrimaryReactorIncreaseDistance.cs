using System.Collections;
using UnityEngine;


public class PrimaryReactorIncreaseDistance : MonoBehaviour
{
    public PrimaryButtonWatcher watcher;
    public bool IsPressed = false; // used to display button state in the Unity Inspector window
    public Vector3 zInc= new Vector3(0, 0, 10);

    void Start()
    {
        watcher.primaryButtonPress.AddListener(onPrimaryButtonEvent);
    }

    public void onPrimaryButtonEvent(bool pressed)
    {
        IsPressed = pressed;
        if (pressed) 
            if (this.transform.position.z < -10)
                this.transform.position += zInc;
        
    }
    
}