using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitVerticalTilt: MonoBehaviour {
    
    void Start() {
        int randAngleInt = Random.Range(-10, 11);
        float randAngle = randAngleInt * 1f;
        Vector3 angleVector = new Vector3(randAngle, 0f, 0f); 
        Vector3 baseRotation = new Vector3(90f, 90f, 0f);

        this.gameObject.transform.rotation= Quaternion.Euler(baseRotation) * Quaternion.Euler(angleVector); 
    }

}