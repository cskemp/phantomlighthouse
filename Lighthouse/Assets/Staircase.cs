using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Staircase : MonoBehaviour
{
    public GameObject thisObj; 
    public RectTransform rT;
    public float timeToWait; 
    public int prevResponse; 
    public int currResponse; 
    public int nInflection; 
    public int maxInflection; 
    public string illusionType; 
    public SceneManagerScript sceneScript;
    public StaircaseAdjust objAdjust;

    void Start()
    {
        thisObj = MainManager.Instance.illusionObject;
        timeToWait = MainManager.CLICK_DELAY;
        rT= GetComponent<RectTransform>();
        sceneScript = GetComponent<SceneManagerScript>();
        objAdjust = thisObj.GetComponent<StaircaseAdjust>();
        prevResponse = 0;
        nInflection = 0;
        illusionType = MainManager.Instance.illusionType;
        maxInflection = MainManager.INFLECTIONS_PER_ILLUSION;
        if (illusionType == "AdjustDemo") 
        {
            maxInflection = MainManager.INFLECTIONS_PER_DEMO;
        }
    }

    public void ButtonPress(int pressValue)
    {
        currResponse = pressValue;
        bool changeStepSize = false;
        if (prevResponse * currResponse < 0) // inflection point
        {
            nInflection += 1;
            if (nInflection == 1 || nInflection == 3) {
                changeStepSize = true;
            }
        }
        prevResponse = currResponse;
        if (nInflection >= maxInflection)
        {
            // end of staircase
            objAdjust.Adjust(currResponse, changeStepSize);
            sceneScript.LoadScene(illusionType);
        } else
        {
            StartCoroutine(ButtonCoroutine(currResponse, changeStepSize));
        }
    }


    private IEnumerator ButtonCoroutine(int currResponse, bool changeStepSize)
    {
        Vector3 newPosition = rT.localPosition;
        float orig_y = newPosition.y;
        newPosition.y = -1000;
        rT.localPosition = newPosition;
        thisObj.SetActive(false);
        yield return new WaitForSeconds(timeToWait);
        // thisObj.transform.position += zDownInc;
        objAdjust.Adjust(currResponse, changeStepSize);
        thisObj.SetActive(true);
        newPosition.y = orig_y;
        rT.localPosition = newPosition;
    }
}
