using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerScript : MonoBehaviour
{
    public void LoadScene(string currentScene)
    {
        string iString = JsonUtility.ToJson(MainManager.Instance.IData);
        Debug.Log(Application.persistentDataPath);
        // System.IO.File.WriteAllText(Application.persistentDataPath + "/illusionData.json", iString);
        System.IO.File.WriteAllText(Application.persistentDataPath + "/" + MainManager.Instance.IData.name + ".json", iString);

        MainManager.Instance.sceneCounter++;
        Debug.Log("SceneCounter: " + MainManager.Instance.sceneCounter);
        Debug.Log("IllusionType: " + MainManager.Instance.illusionType);

        if (string.Equals(currentScene, "Instructions") ) {
            if (string.Equals(MainManager.Instance.illusionType, "End") )
            {
                Debug.Log("Quitting");
                //Application.Quit();
            } else
            {
                SceneManager.LoadScene(MainManager.Instance.illusionType);
            }
        } else {
            if ( (MainManager.Instance.illusionType ==  "AdjustDemo" && MainManager.Instance.sceneCounter == 2 * MainManager.TRIALS_PER_DEMO) ||
                 (MainManager.Instance.illusionType !=  "AdjustDemo" && !MainManager.Instance.Adjust && MainManager.Instance.sceneCounter == 2 * MainManager.TRIALS_PER_STAIRCASE) ||
                 (MainManager.Instance.illusionType !=  "AdjustDemo" && MainManager.Instance.Adjust  && MainManager.Instance.sceneCounter == 2 * MainManager.TRIALS_PER_ADJUST) ) 
             {  // move to next illusion
                MainManager.Instance.illusionCounter++;
                MainManager.Instance.sceneCounter = 0;
                MainManager.Instance.Adjust = MainManager.Instance.IData.adjustFlag[MainManager.Instance.illusionCounter];
                MainManager.Instance.illusionType = MainManager.Instance.IData.illusions[MainManager.Instance.illusionCounter];
                MainManager.Instance.currResponse = MainManager.Instance.allResponse[MainManager.Instance.illusionCounter];
            } 
            SceneManager.LoadScene("Instructions");
        }
    }
}