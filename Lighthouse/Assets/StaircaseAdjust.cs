using System.Collections;
using UnityEngine;

public class StaircaseAdjust: MonoBehaviour
{
    //public Vector3 zInc= new Vector3(5, 0, 0);
    //public Vector3 angleVector = new Vector3(-0.5f, 0f, 0f); 
    //public Vector3 currentEulerAngles;

    public string illusionType;
    public Vector3 zUpPhantom;
    public Vector3 zDownPhantom;

    public Vector3 zUpSpheres;
    public Vector3 zDownSpheres;

    public Vector3 zUpBentBeam;
    public Vector3 zDownBentBeam;

    public Vector3 zUpBentBeamDepth;
    public Vector3 zDownBentBeamDepth;

    Quaternion undoBase = Quaternion.Inverse(Quaternion.Euler(new Vector3(90f, 90f, 0f)));

    void Start()
    {
        MainManager.Instance.illusionObject  = this.gameObject;
        illusionType = MainManager.Instance.illusionType;
    
        zUpSpheres= new Vector3(1.1f, 1.1f, 1.1f);
        zDownSpheres = new Vector3(0.909090909f, 0.909090909f, 0.909090909f);

        zUpPhantom = new Vector3(0f, 0f, 20f);
        zDownPhantom = new Vector3(0f, 0f, -20f);

        zUpBentBeam = new Vector3(4f, 0f, 0f);
        zDownBentBeam = new Vector3(-4f, 0f, 0f);

        zUpBentBeamDepth = new Vector3(0f, 0f, -4f);
        zDownBentBeamDepth = new Vector3(0f, 0f,  4f);

        // integer division here because sceneCounter includes instruction screens
        int sCounter = MainManager.Instance.sceneCounter / 2;

        // first add spacer click
        MainManager.Response spacer_click = new MainManager.Response();
        spacer_click.time = 0;
        spacer_click.data = sCounter;
        MainManager.Instance.currResponse.Add(spacer_click);

        // now add initialization click
        MainManager.Response click = new MainManager.Response();
        click.time = Time.fixedTime;

        // initialize key object
        if (illusionType == "AdjustDemo")
        {
            float sphScale = MainManager.Instance.IData.demoInit[sCounter];
            this.transform.localScale = new Vector3( sphScale, sphScale, sphScale);  
            click.data = sphScale;

        } else if (illusionType == "Phantom")    
        {
            //int randZ = 10 * Random.Range(-15, -4);
            //Vector3 initPosn= new Vector3(0, 30, randZ);

            float separation = MainManager.Instance.IData.phantomInit[sCounter];
            this.gameObject.transform.position = new Vector3(0, MainManager.LIGHTHOUSE_HEIGHT, separation);
            click.data = separation;

        } else if (illusionType == "BentBeam")
        {
            //int randAngleInt = Random.Range(-10, 11);
            //float randAngle = randAngleInt * 1f;
            float initAngle = MainManager.Instance.IData.bentBeamInit[sCounter];
            Vector3 angleVector = new Vector3(initAngle, 0f, 0f);
            Vector3 baseRotation = new Vector3(90f, 90f, 0f);
            this.gameObject.transform.rotation = Quaternion.Euler(baseRotation) * Quaternion.Euler(angleVector);
            // Quaternion undone =  Quaternion.Inverse(Quaternion.Euler(baseRotation)) * this.gameObject.transform.rotation;  
            Quaternion undone =  undoBase * this.gameObject.transform.rotation;  
            click.data = undone.eulerAngles.x;
           // click.data = this.transform.rotation.x;

        } else if (illusionType == "BentBeamDepth")
        {
            //int randAngleInt = Random.Range(-10, 11);
            //float randAngle = randAngleInt * 1f;
            float initAngle = MainManager.Instance.IData.bentBeamDepthInit[sCounter];
            Vector3 angleVector = new Vector3(0f, 0f, initAngle);
            Vector3 baseRotation = new Vector3(90f, 90f, 0f);
            this.gameObject.transform.rotation= Quaternion.Euler(baseRotation) * Quaternion.Euler(angleVector);
            //Quaternion undone =  Quaternion.Inverse(Quaternion.Euler(baseRotation)) * this.gameObject.transform.rotation;  
            Quaternion undone =  undoBase * this.gameObject.transform.rotation;  
            click.data = undone.eulerAngles.z;
            //click.data = this.transform.rotation.z;
        }
            
        MainManager.Instance.currResponse.Add(click);
    }

    public void Adjust(int currResponse, bool changeStepSize)
    {

       MainManager.Response click = new MainManager.Response();
       click.time = Time.fixedTime;

       if (illusionType == "AdjustDemo")
       {
           Vector3 currentScale= this.transform.localScale;
           if (currResponse > 0)
           {
               this.transform.localScale  = new Vector3(currentScale.x*zUpSpheres.x, currentScale.y*zUpSpheres.y, currentScale.z*zUpSpheres.z);    
           } else
           {
               this.transform.localScale  = new Vector3(currentScale.x*zDownSpheres.x, currentScale.y*zDownSpheres.y, currentScale.z*zDownSpheres.z);    
           }
           click.data = this.transform.localScale.x;

       } else if (illusionType == "Phantom")
       {
           if (currResponse > 0)
           {
               Vector3 newPosn = this.gameObject.transform.position + zUpPhantom;
               if (newPosn.z > -1)  // don't allow source to actually be in front!
               {
                newPosn.z = 0.5f * this.gameObject.transform.position.z;
               }
               this.gameObject.transform.position = newPosn;
           } else
           {
               this.gameObject.transform.position += zDownPhantom;
           }
           click.data = this.gameObject.transform.position.z;
           Debug.Log("newPosn: " + this.gameObject.transform.position.z);
           if (changeStepSize)
           {
                zUpPhantom.z = 0.5f * zUpPhantom.z;
                zDownPhantom.z = 0.5f * zDownPhantom.z;
           }

       } else if (illusionType == "BentBeam")
       {
           Quaternion currentRotation = this.transform.rotation;
           if (currResponse > 0)
           {
               this.gameObject.transform.rotation = currentRotation * Quaternion.Euler(zUpBentBeam);
           } else
           {
               this.gameObject.transform.rotation = currentRotation * Quaternion.Euler(zDownBentBeam);
           }

           Quaternion undone =  undoBase * this.gameObject.transform.rotation;  
           click.data = undone.eulerAngles.x;
           //click.data = this.gameObject.transform.rotation.x;
           if (changeStepSize)
           {
                zUpBentBeam.x = 0.5f * zUpBentBeam.x;
                zDownBentBeam.x = 0.5f * zDownBentBeam.x;
           }
       } else if (illusionType == "BentBeamDepth")
       {    
           Quaternion currentRotation = this.transform.rotation;
           if (currResponse > 0)
           {
               this.gameObject.transform.rotation = currentRotation * Quaternion.Euler(zUpBentBeamDepth);
           } else
           {
               this.gameObject.transform.rotation = currentRotation * Quaternion.Euler(zDownBentBeamDepth);
           }
           Quaternion undone =  undoBase * this.gameObject.transform.rotation;  
           click.data = undone.eulerAngles.z;
           //click.data = this.gameObject.transform.rotation.z;
           if (changeStepSize)
           {
                zUpBentBeamDepth.z = 0.5f * zUpBentBeamDepth.z;
                zDownBentBeamDepth.z = 0.5f * zDownBentBeamDepth.z;
           }

       }
       MainManager.Instance.currResponse.Add(click);
    }
}
