using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitSpheres: MonoBehaviour {
    
    void Start() {
        MainManager.Instance.illusionObject  = this.gameObject;

        // integer division here because sceneCounter includes instruction screens
        int sCounter = MainManager.Instance.sceneCounter / 2;
        Debug.Log("sCounter: " + sCounter);

        MainManager.Response spacer_click = new MainManager.Response();

        // random initialization if required

        // first add spacer click
        spacer_click.time = 0;
        spacer_click.data = sCounter;
        MainManager.Instance.IData.demoResponse.Add(spacer_click);

        MainManager.Response click = new MainManager.Response();
        click.time = Time.fixedTime;
        click.data = this.transform.localScale.x;

        MainManager.Instance.IData.demoResponse.Add(click);

    }

}
