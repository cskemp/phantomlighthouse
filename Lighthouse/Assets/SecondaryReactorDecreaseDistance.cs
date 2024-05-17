using System.Collections;
using UnityEngine;


public class SecondaryReactorDecreaseDistance : MonoBehaviour
{
    public SecondaryButtonWatcher watcher;
    public bool IsPressed = false; // used to display button state in the Unity Inspector window
    public Vector3 zInc= new Vector3(0, 0, -10);

    void Start()
    {
        watcher.secondaryButtonPress.AddListener(onSecondaryButtonEvent);
    }

    public void onSecondaryButtonEvent(bool pressed)
    {
        IsPressed = pressed;
        if (pressed) 
            this.transform.position += zInc;
        
        Debug.Log(this.transform.position.ToString());

    }
    
}