using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonHideFinal: MonoBehaviour
{

    public RectTransform rT;

    // Start is called before the first frame update
    void Start()
    {
        rT= GetComponent<RectTransform>();
        int iCtr = MainManager.Instance.illusionCounter;

        //if (iCtr == 8)
        if (MainManager.Instance.illusionType== "End") 
        {
            Vector3 newPosition = rT.localPosition;
            newPosition.y = -10000;
            newPosition.z = -10000;
            rT.localPosition = newPosition;
        }
        
    }

}
