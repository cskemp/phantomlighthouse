using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonHideNoAdjust: MonoBehaviour
{

    public RectTransform rT;

    // Start is called before the first frame update
    void Start()
    {
        rT= GetComponent<RectTransform>();
        bool adjustFlag = MainManager.Instance.Adjust;

        if (!adjustFlag)
        {
            Vector3 newPosition = rT.localPosition;
            newPosition.y = -10000;
            newPosition.z = -10000;
            rT.localPosition = newPosition;
        }
        
    }

}
