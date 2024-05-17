using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PhantomStaircaseButton: MonoBehaviour
{
    public Vector3 zUpInc= new Vector3(0, 0, 10);
    public Vector3 zDownInc= new Vector3(0, 0, -10);

    public GameObject thisObj; 
    public RectTransform rT;
    public float timeToWait; 
    public int prevResponse; 
    public int currResponse; 
    public int nInflection; 
    public SceneManagerScript sceneScript;

    void Start()
    {
        thisObj = MainManager.Instance.illusionObject;
        timeToWait = MainManager.CLICK_DELAY;
        rT= GetComponent<RectTransform>();
        sceneScript = GetComponent<SceneManagerScript>();
        // get from elsewhere
        prevResponse = -1;
        nInflection = 0;

    }

    public void ButtonLeft()
    {
        currResponse = -1;
        if (prevResponse * currResponse < 0)
        {
            nInflection += 1;
        }
        prevResponse = currResponse;
        if (nInflection >= MainManager.INFLECTIONS_PER_ILLUSION)
        {
            // end of staircase
            sceneScript.LoadScene("Phantom");
        } else {
        StartCoroutine(ButtonLeftCoroutine());
        }
    }

    private IEnumerator ButtonLeftCoroutine()
    {
        Vector3 newPosition = rT.localPosition;
        float orig_y = newPosition.y;
        newPosition.y = -1000;
        rT.localPosition = newPosition;
        thisObj.SetActive(false);
        yield return new WaitForSeconds(timeToWait);
        thisObj.transform.position += zDownInc;
        thisObj.SetActive(true);
        newPosition.y = orig_y;
        rT.localPosition = newPosition;
    }

    public void ButtonRight()
    {
        currResponse = 1;
        if (prevResponse * currResponse < 0)
        {
            nInflection += 1;
        }
        prevResponse = currResponse;
        if (nInflection >= MainManager.INFLECTIONS_PER_ILLUSION)
        {
            // end of staircase
            sceneScript.LoadScene("Phantom");
        } else {
            StartCoroutine(ButtonRightCoroutine());
        }
    }

    private IEnumerator ButtonRightCoroutine()
    {
        Vector3 newPosition = rT.localPosition;
        float orig_y = newPosition.y;
        newPosition.y = -1000;
        rT.localPosition = newPosition;
        thisObj.SetActive(false);
        yield return new WaitForSeconds(timeToWait);
        if (thisObj.transform.position.z < -10)
                thisObj.transform.position += zUpInc;
        thisObj.SetActive(true);
        newPosition.y = orig_y;
        rT.localPosition = newPosition;
    }
}
