using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ModifySceneText : MonoBehaviour
{
    public TMP_Text sceneText;
    
    // Start is called before the first frame update
    void Start()
    {
        if (MainManager.Instance.illusionType== "AdjustDemo" && !MainManager.Instance.Adjust) 
        { 
            sceneText.text = "Which sphere looks bigger?" ;
        } else if (MainManager.Instance.illusionType == "AdjustDemo" && MainManager.Instance.Adjust) 
        {
            sceneText.text = "Use the A and B buttons to adjust the scene until the two spheres look identical in size.\n\nWhen you're done, press Next to continue." ;
        } else if (MainManager.Instance.illusionType == "Phantom" && !MainManager.Instance.Adjust) 
        {
            sceneText.text = "Do you think the source of the beam is behind you or in front of you?" ;
        } else if (MainManager.Instance.illusionType == "Phantom" && MainManager.Instance.Adjust) 
        {
            sceneText.text = "Use the A and B buttons to adjust the scene until the beam looks as if it is sweeping horizontally over your head.\n\nWhen you're done, press Next to continue." ;
        } else if (MainManager.Instance.illusionType == "BentBeam" && !MainManager.Instance.Adjust) 
        {
            sceneText.text = "Is the beam tilted up or down?\n\nCheck the guide near your waist to see what it means for a beam to be tilted up or down.";
        } else if (MainManager.Instance.illusionType == "BentBeam" && MainManager.Instance.Adjust) 
        {
            sceneText.text = "Use the A and B buttons to adjust the scene until the beam looks horizontal.\n\nWhen you're done, press Next to continue." ;
        } else if (MainManager.Instance.illusionType == "BentBeamDepth" && !MainManager.Instance.Adjust) 
        {
            sceneText.text = "Is the beam tilted towards you or away from you?\n\nCheck the guide at your feet to see what it means for a beam to be tilted towards or away from you.";
        } else if (MainManager.Instance.illusionType == "BentBeamDepth" && MainManager.Instance.Adjust) 
        {
            sceneText.text = "Use the A and B buttons to adjust the scene until the beam is parallel to the middle line at your feet (neither tilted towards you nor away from you).\n\nWhen you're done, press Next to continue.";
        }
    }

}
