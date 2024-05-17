using System.Collections;
using UnityEngine;

public class SecondaryReactorSize: MonoBehaviour
{
    public SecondaryButtonWatcher watcher;
    public bool IsPressed = false; // used to display button state in the Unity Inspector window
    public Vector3 scaleInc= new Vector3(0.909090909f, 0.909090909f, 0.909090909f);


    void Start()
    {
        watcher.secondaryButtonPress.AddListener(onSecondaryButtonEvent);
    }

    public void onSecondaryButtonEvent(bool pressed)
    {
        IsPressed = pressed;
        Vector3 currentScale= this.transform.localScale;

        if (pressed) 
            this.transform.localScale = new Vector3(currentScale.x * scaleInc.x, currentScale.y * scaleInc.y, currentScale.z * scaleInc.z );
            MainManager.Response click = new MainManager.Response();
            click.time = Time.fixedTime;
            click.data = this.transform.localScale.x;
            MainManager.Instance.IData.demoResponse.Add(click);
        
    }
    
}
