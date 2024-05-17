using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCylinder : MonoBehaviour {
    
    public iTween.EaseType easeType; 
    public iTween.LoopType loopType; 

    void Start() {
//        int randZ = 10 * Random.Range(-15, -4);
 //       Vector3 initPosn= new Vector3(0, 0, randZ);
  //      this.gameObject.transform.position = initPosn;
        iTween.RotateBy(this.gameObject, iTween.Hash("z", -0.2222, "time", 5f, "easetype", easeType, "looptype", loopType));
    }

}
