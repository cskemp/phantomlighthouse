using System.Collections;
using UnityEngine;

public class SecondaryReactorAll: MonoBehaviour
{
    public SecondaryButtonWatcher watcher;
    public bool IsPressed = false; // used to display button state in the Unity Inspector window
    public bool AdjustPhase; 
    public string illusionType;

    public Vector3 zDownSpheres; 
    public Vector3 zDownPhantom; 
    public Vector3 zDownBentBeam;
    public Vector3 zDownBentBeamDepth; 
    Quaternion undoBase = Quaternion.Inverse(Quaternion.Euler(new Vector3(90f, 90f, 0f)));

    void Start()
    {
        // Secondary reactor is button B -- so more natural to think of this as up button
        zDownSpheres = new Vector3(1.1f, 1.1f, 1.1f);
        zDownPhantom = new Vector3(0, 0, -10);
        zDownBentBeam = new Vector3(0.5f, 0f, 0f); 
        zDownBentBeamDepth = new Vector3(0f, 0f, -0.5f);

        int iCtr = MainManager.Instance.illusionCounter;
        illusionType = MainManager.Instance.illusionType;
        AdjustPhase = MainManager.Instance.Adjust;
        
        if (AdjustPhase) {
            watcher.secondaryButtonPress.AddListener(onSecondaryButtonEvent);
        }
    }

    public void onSecondaryButtonEvent(bool pressed)
    {
        IsPressed = pressed;
        if (pressed && AdjustPhase) 
        {
           MainManager.Response click = new MainManager.Response();
           click.time = Time.fixedTime;

            if (illusionType == "AdjustDemo")
               {
                   Vector3 currentScale= this.transform.localScale;
                   this.transform.localScale  = new Vector3(currentScale.x*zDownSpheres.x, currentScale.y*zDownSpheres.y, currentScale.z*zDownSpheres.z);
                   click.data = this.transform.localScale.x;

               } else if (illusionType == "Phantom")
               {
                   this.gameObject.transform.position += zDownPhantom;
                   click.data = this.gameObject.transform.position.z;
               } else if (illusionType == "BentBeam")
               {
                   Quaternion currentRotation = this.transform.rotation;
                   this.gameObject.transform.rotation = currentRotation * Quaternion.Euler(zDownBentBeam);
                   Quaternion undone =  undoBase * this.gameObject.transform.rotation;  
                   click.data = undone.eulerAngles.x;
                   //click.data = this.gameObject.transform.rotation.x;
               } else if (illusionType == "BentBeamDepth")
               {
                   Quaternion currentRotation = this.transform.rotation;
                   this.gameObject.transform.rotation = currentRotation * Quaternion.Euler(zDownBentBeamDepth);
                   Quaternion undone =  undoBase * this.gameObject.transform.rotation;  
                   click.data = undone.eulerAngles.z;
                   //click.data = this.gameObject.transform.rotation.z;
               }
               MainManager.Instance.currResponse.Add(click);
        }
    }
}
