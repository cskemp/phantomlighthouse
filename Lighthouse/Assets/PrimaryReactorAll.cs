using System.Collections;
using UnityEngine;

public class PrimaryReactorAll: MonoBehaviour
{
    public PrimaryButtonWatcher watcher;
    public bool IsPressed = false; // used to display button state in the Unity Inspector window
    public bool AdjustPhase; 
    public string illusionType;

    public Vector3 zUpSpheres; 
    public Vector3 zUpPhantom; 
    public Vector3 zUpBentBeam;
    public Vector3 zUpBentBeamDepth; 

    Quaternion undoBase = Quaternion.Inverse(Quaternion.Euler(new Vector3(90f, 90f, 0f)));

    void Start()
    {
        // Primary reactor is button A -- so more natural to think of this as down button
        zUpSpheres = new Vector3(0.909090909f, 0.909090909f, 0.909090909f);
        zUpPhantom = new Vector3(0, 0, 10);
        zUpBentBeam = new Vector3(-0.5f, 0f, 0f);
        zUpBentBeamDepth = new Vector3(0f, 0f, 0.5f); 

        int iCtr = MainManager.Instance.illusionCounter;
        illusionType = MainManager.Instance.illusionType;
        AdjustPhase = MainManager.Instance.Adjust;
        
        if (AdjustPhase) {
            watcher.primaryButtonPress.AddListener(onPrimaryButtonEvent);
        }
    }

    public void onPrimaryButtonEvent(bool pressed)
    {
        IsPressed = pressed;
        if (pressed && AdjustPhase) 
        {
           MainManager.Response click = new MainManager.Response();
           click.time = Time.fixedTime;

            if (illusionType == "AdjustDemo")
               {
                    Vector3 currentScale= this.transform.localScale;
                    this.transform.localScale  = new Vector3(currentScale.x*zUpSpheres.x, currentScale.y*zUpSpheres.y, currentScale.z*zUpSpheres.z);
                    click.data = this.transform.localScale.x;

               } else if (illusionType == "Phantom")
               {
                    Vector3 newPosn = this.gameObject.transform.position + zUpPhantom;
                    // if (this.gameObject.transform.position.z < -10)  // don't allow source to actually be in front
                    // {
                    //     this.gameObject.transform.position += zUpPhantom;
                    // }
                    if (newPosn.z > -1)  // don't allow source to actually be in front
                    {
                        newPosn.z = 0.5f * this.gameObject.transform.position.z;
                    }
                    this.gameObject.transform.position = newPosn;
                    click.data = this.gameObject.transform.position.z;
               } else if (illusionType == "BentBeam")
               {
                    Quaternion currentRotation = this.transform.rotation;
                    this.gameObject.transform.rotation = currentRotation * Quaternion.Euler(zUpBentBeam);
                    Quaternion undone =  undoBase * this.gameObject.transform.rotation;  
                    click.data = undone.eulerAngles.x;
                   //click.data = this.gameObject.transform.rotation.x;
               } else if (illusionType == "BentBeamDepth")
               {
                    Quaternion currentRotation = this.transform.rotation;
                    this.gameObject.transform.rotation = currentRotation * Quaternion.Euler(zUpBentBeamDepth);
                    Quaternion undone =  undoBase * this.gameObject.transform.rotation;  
                    click.data = undone.eulerAngles.z;
                    //click.data = this.gameObject.transform.rotation.z;
               }
               MainManager.Instance.currResponse.Add(click);
        }
    }
}
