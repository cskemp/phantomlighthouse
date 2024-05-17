using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitPhantom: MonoBehaviour {
    
    void Start() {

        MainManager.Instance.illusionObject  = this.gameObject;

        // integer division here because sceneCounter includes instruction screens
        int sCounter = MainManager.Instance.sceneCounter / 2;
        Debug.Log("sCounter: " + sCounter);

        MainManager.Response spacer_click = new MainManager.Response();

        // random initialization 

        int randZ = 10 * Random.Range(-15, -4);
        Vector3 initPosn= new Vector3(0, 30, randZ);
        this.gameObject.transform.position = initPosn;

        // first add spacer click
        spacer_click.time = 0;
        spacer_click.data = sCounter;
        MainManager.Instance.IData.phantomResponse.Add(spacer_click);

        MainManager.Response click = new MainManager.Response();
        click.time = Time.fixedTime;
        click.data = this.transform.position.z;

        MainManager.Instance.IData.phantomResponse.Add(click);

    }

}
